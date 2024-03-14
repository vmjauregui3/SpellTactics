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


        public TileHighlight(Vector2 position, Color color)
        {
            tile = new Sprite("Sprites/TileHighlight", position);
            tile.Tint = color;
        }

        public virtual void Update(Vector2 position)
        {
            tile.Position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            tile.Draw(spriteBatch);
        }
    }
}
