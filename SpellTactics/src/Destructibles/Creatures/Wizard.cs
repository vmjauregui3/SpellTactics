using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpellTactics
{
    public class Wizard : Creature
    {
        public Wizard(int ownerId) : base(ownerId)
        {
            Sprite = new AnimatedSprite("Sprites/Wizard", Vector2.Zero);
        }
    }
}
