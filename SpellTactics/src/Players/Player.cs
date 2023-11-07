using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public class Player
    {

        public Sprite Wizard;

        // Player id is used to organize Creatures under Player control.
        private int id;
        public int Id
        {
            get { return id; }
        }

        public Player()
        {
            Wizard = new Sprite("Sprites/Wizard", Vector2.Zero);
        }

        public virtual void Update(GameTime gameTime, World world)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Wizard.Draw(spriteBatch);
        }
    }
}
