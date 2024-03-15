using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public abstract class GameObject
    {
        // GameObjects contain a sprite that represents them visiually and contains their game location.
        public AnimatedSprite Sprite;

        public Vector2 MapPosition;

        public Vector2 Position
        {
            get { return MapPosition * STConstants.TileSize; }
        }

        public GameObject(Vector2 mapPosition)
        {
            MapPosition = mapPosition;
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Position = Position;
            Sprite.Update(gameTime);
        }

        // Draws the Sprite.
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
