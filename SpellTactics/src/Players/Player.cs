using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public class Player
    {
        protected bool isTurn;

        // Player id is used to organize Creatures under Player control.
        private int id;
        public int Id
        {
            get { return id; }
        }

        public Sprite Cursor;

        protected Destructible selectedObject;
        protected Vector2 selectedPosition;

        public Player(int id)
        {
            Cursor = new Sprite("Sprites/Cursor", new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y));
            this.id = id;
            bool isTurn = false;
            selectedPosition = Vector2.Zero;
        }
        
        public virtual void ControlMovements()
        {

        }

        public void EndTurn()
        {
            ControlMovements();
            isTurn = false;
        }

        public Vector2 GetTile(Vector2 position)
        {
            return position / STConstants.TileSize;
        }


        public void SelectObject(Vector2 position, List<Destructible> destructibles)
        {
            foreach(Destructible destructible in destructibles)
            {
                if (destructible.Position.Equals(position))
                {
                    selectedObject = destructible;
                }
            }
        }

        public virtual void StartTurn()
        {
            isTurn = true;
        }

        public virtual void Update(GameTime gameTime, World world)
        {
            Cursor.Position = Vector2.Transform(new Vector2(MCursor.Instance.newMousePos.X, MCursor.Instance.newMousePos.Y), Matrix.Invert(Camera.Instance.Transform));
            if (isTurn)
            {
                EndTurn();
                world.EndPlayerTurn();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Cursor.Draw(spriteBatch);
        }
    }
}
