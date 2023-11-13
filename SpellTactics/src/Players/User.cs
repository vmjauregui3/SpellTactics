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
        public Wizard Wizard;

        public User(int id) : base(id)
        {
            Wizard = new Wizard(id);
        }

        public override void Update(GameTime gameTime, Player enemy, World world)
        {
            base.Update(gameTime, enemy, world);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Wizard.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
