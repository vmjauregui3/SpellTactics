using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public class User : Player
    {
        public Sprite Wizard;

        public User()
        {
            Wizard = new Sprite("Sprites/Wizard", Vector2.Zero);
        }

        public override void Update(GameTime gameTime, World world)
        {
            base.Update(gameTime, world);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Wizard.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
