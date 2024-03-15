using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpellTactics
{
    public class TileHighlight
    {
        public Sprite tile;

        public Vector2 MapPosition;

        public Vector2 Position
        {
            get { return MapPosition * STConstants.TileSize; }
        }


        public TileHighlight(Vector2 position, Color color)
        {
            MapPosition = position;
            tile = new Sprite("Sprites/TileHighlight", Position);
            tile.Tint = color;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            tile.Draw(spriteBatch);
        }
    }
}
