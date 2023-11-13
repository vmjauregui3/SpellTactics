using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public class World
    {
        public Map Map;
        public User User;

        public World() 
        {
            Map = new Map("TileSheets/GroundTilesReduced", 5);
            User = new User();
        }

        public void Update(GameTime gameTime)
        {
            Camera.Instance.UpdatePosition(Vector2.Zero);

            User.Update(gameTime, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
            User.Draw(spriteBatch);
        }
    }
}
