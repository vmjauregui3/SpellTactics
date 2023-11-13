using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            Wizard = new Wizard(id, Vector2.Zero);
        }

        public void ControlInput()
        {

        }

        public override void ControlMovements()
        {
            Wizard.Move(new Vector2(0, 1));
        }

        public override void Update(GameTime gameTime, Player enemy, World world)
        {
            base.Update(gameTime, enemy, world);
            if (isTurn)
            {
                ControlInput();
                if (InputManager.Instance.KeyPressed(Keys.Enter))
                {
                    EndTurn();
                    world.EndPlayerTurn();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Wizard.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
