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

        public Sprite Wizard;

        public World() 
        {
            Map = new Map("TileSheets/GroundTilesReduced", 5);

            Wizard = new Sprite("Sprites/Wizard", Vector2.Zero);
        }

        public void Update(GameTime gameTime)
        {
            Camera.Instance.UpdatePosition(Vector2.Zero);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
            Wizard.Draw(spriteBatch);
        }
    }
}
