using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public class User : Player
    {
        public Vector2 CameraPosition;
        public int CameraSpeed;

        //private Vector2 RightClickHoldPos;
        private Vector2 rightClickPos;
        private bool waitingForClickRelease;
        //private Vector2 RightClickReleasePos;

        public Wizard Wizard;

        private Vector2 mousePosition;

        public User(int id) : base(id)
        {
            Wizard = new Wizard(id, Vector2.Zero);
            CameraSpeed = 10;
            waitingForClickRelease = false;
        }

        public void ControlInput(List<Destructible> destructibles)
        {
            if (MCursor.Instance.LeftClick())
            {
                if(selectedObject == null)
                {
                    SelectObject(mousePosition, destructibles);
                }
                else
                {
                    selectedPosition = mousePosition;
                }
            }
            if (MCursor.Instance.RightClick())
            {
                selectedObject = null;
            }

        }

        public void ControlCamera()
        {
            if (InputManager.Instance.KeyDown(Keys.W))
            {
                CameraPosition.Y -= CameraSpeed;
            }
            if (InputManager.Instance.KeyDown(Keys.S))
            {
                CameraPosition.Y += CameraSpeed;
            }
            if (InputManager.Instance.KeyDown(Keys.A))
            {
                CameraPosition.X -= CameraSpeed;
            }
            if (InputManager.Instance.KeyDown(Keys.D))
            {
                CameraPosition.X += CameraSpeed;
            }
            if (MCursor.Instance.RightClickHold())
            {
                if (waitingForClickRelease == false)
                {
                    rightClickPos = mousePosition;
                    waitingForClickRelease = true;
                }
            }
            if (MCursor.Instance.RightClickRelease())
            {
                CameraPosition -= (mousePosition - rightClickPos);
                waitingForClickRelease = false;
            }

        }

        public override void ControlMovements()
        {
            Wizard.Move(selectedPosition);
        }

        public override void Update(GameTime gameTime, World world)
        {
            ControlCamera();
            mousePosition = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));
            Camera.Instance.UpdatePosition(CameraPosition);

            base.Update(gameTime, world);
            if (isTurn)
            {
                ControlInput(world.Destructibles);
                if (InputManager.Instance.KeyPressed(Keys.Enter))
                {
                    EndTurn();
                    world.EndPlayerTurn();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Wizard.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
