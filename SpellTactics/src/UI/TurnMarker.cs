using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpellTactics
{
    public class TurnMarker
    {
        public Sprite box;

        public TurnMarker(Color color)
        {
            box = new Sprite("Sprites/SelectorBox", Vector2.Zero);
            box.Tint = color;
        }

        public virtual void Update(Vector2 position)
        {
            box.Position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            box.Draw(spriteBatch);
        }
    }
}
