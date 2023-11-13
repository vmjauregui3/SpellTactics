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
        public Wizard Wizard;

        private Vector2 mousePosition;

        public User(int id) : base(id)
        {
            Wizard = new Wizard(id, Vector2.Zero);
            GameCommands.PassDestructible(Wizard);
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

        public override void ControlMovements()
        {
            Wizard.Move(selectedPosition);
        }

        public override void Update(GameTime gameTime, Player enemy, World world)
        {
            mousePosition = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));

            base.Update(gameTime, enemy, world);
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
