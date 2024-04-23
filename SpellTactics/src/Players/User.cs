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

        public UI UI;


        public Sprite Cursor;
        private Vector2 mousePosition;

        //private Vector2 RightClickHoldPos;
        private Vector2 rightClickPos;
        private bool waitingForClickRelease;
        //private Vector2 RightClickReleasePos;


        public User(int id) : base(id)
        {
            Cursor = new Sprite("Sprites/Cursor", new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y));
            Controllables.Add(new Wizard(id, new Vector2(1,1)));
            Controllables.Add(new Wizard(id, new Vector2(1, 2)));
            Controllables.Add(new Wizard(id, new Vector2(2, 1)));
            Controllables.Add(new Wizard(id, new Vector2(2, 2)));

            ObjectiveTiles.Add(new ObjectiveTile(id, new Vector2(5, 15)));
            ObjectiveTiles.Add(new ObjectiveTile(id, new Vector2(10, 15)));

            UI = new UI();
            CameraSpeed = 10;
            waitingForClickRelease = false;
        }

        public void ControlInput(Creature creatureTurn, List<Destructible> destructibles)
        {
            if (MCursor.Instance.LeftClick())
            {
                SelectObject(GameFunctions.PosToMapPos(mousePosition), destructibles);
                UI.SelectMovementTile(GameFunctions.PosToMapPos(mousePosition), targetObject != null);
                if (UI.ShowingHighlight)
                {
                    UI.SelectSpellTargetTile(GameFunctions.PosToMapPos(mousePosition), targetObject == null);
                }
            }
            if (MCursor.Instance.RightClick())
            {
                UI.ClearSelectedTile();
                DeselectObject();
            }

            ControlMovements(creatureTurn, destructibles);


            if (InputManager.Instance.KeyPressed(Keys.C))
            {
                UI.HighlightRadius(destructibles, creatureTurn, (int)creatureTurn.Spell.Attributes["Range"]);
            }
            if (InputManager.Instance.KeyPressed(Keys.Space))
            {
                if (UI.ValidTarget)
                {
                    if (creatureTurn.HasMana(creatureTurn.Spell.Cost))
                    {
                        creatureTurn.CastSpell((Creature)targetObject);
                        UI.CastSpell();
                    }
                }
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

        public void ControlMovements(Creature creatureTurn, List<Destructible> destructibles)
        {
            if (InputManager.Instance.KeyPressed(Keys.Space))
            {
                if (UI.ValidMovement)
                {
                    creatureTurn.Move(UI.selectedTile.MapPosition-creatureTurn.MapPosition);
                    CheckCaptureObjective(creatureTurn);
                    UI.MoveCreature();
                }
            }
            if (InputManager.Instance.KeyPressed(Keys.M))
            {
                UI.HighlightMovement(destructibles, creatureTurn, (int)creatureTurn.Movement.Value);
            }
        }

        public void CheckCaptureObjective(Creature creatureTurn)
        {
            foreach (ObjectiveTile objectiveTile in ObjectiveTiles)
            {
                if (objectiveTile.MapPosition.Equals(creatureTurn.MapPosition))
                {
                    objectiveTile.GetCaptured();
                }
            }
        }

        public override void Update(GameTime gameTime, World world)
        {

            ControlCamera();
            Cursor.Position = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));
            mousePosition = Cursor.Position;
            Camera.Instance.UpdatePosition(CameraPosition);

            UI.Update(world.CreatureTurn);

            //base.Update(gameTime, world);
            if (isTurn)
            {
                if (InputManager.Instance.KeyPressed(Keys.Enter))
                {
                    world.EndTurn();
                    UI.EndTurn();
                }
                else
                {
                    ControlInput(world.CreatureTurn, world.Destructibles);
                }
            }

            base.Update(gameTime, world);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            UI.Draw(spriteBatch);
            Cursor.Draw(spriteBatch);
        }
    }
}
