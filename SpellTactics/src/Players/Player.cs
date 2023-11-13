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

        protected Destructible selectedObject;

        public Player(int id)
        {
            this.id = id;
            bool isTurn = false;
        }
        
        public virtual void ControlMovements()
        {
        }

        public void EndTurn()
        {
            isTurn = false;
            ControlMovements();
        }

        public Vector2 GetTile(Vector2 position)
        {
            return position / STConstants.TileSize;
        }

        public virtual void StartTurn()
        {
            isTurn = true;
        }


        public virtual void Update(GameTime gameTime, Player enemy, World world)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        
        }
    }
}
