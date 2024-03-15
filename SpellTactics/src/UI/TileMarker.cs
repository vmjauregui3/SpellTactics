using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpellTactics
{
    public class TileMarker
    {
        public Sprite box;

        public bool Visible;

        public Vector2 MapPosition;

        public Vector2 Position
        {
            get { return MapPosition * STConstants.TileSize; }
        }

        public TileMarker()
        {
            box = new Sprite("Sprites/SelectorBox", Vector2.Zero);
            Visible = false;
        }

        public TileMarker(Color color)
        {
            box = new Sprite("Sprites/SelectorBox", Vector2.Zero);
            box.Tint = color;
            Visible = true;
        }

        public TileMarker(Color color, Vector2 mapPosition)
        {
            MapPosition = mapPosition;
            box = new Sprite("Sprites/SelectorBox", Position);
            box.Tint = color;
            Visible = true;
        }

        public virtual void Update(Vector2 mapPosition)
        {
            MapPosition = mapPosition;
            box.Position = Position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                box.Draw(spriteBatch);
            }
        }
    }
}
