﻿using Microsoft.Xna.Framework;
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
            User = new User(0);
        }

        public void Update(GameTime gameTime)
        {
            User.Update(gameTime, this);

            Camera.Instance.UpdatePosition(User.Wizard.Sprite.Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
            User.Draw(spriteBatch);
        }
    }
}
