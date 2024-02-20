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
        public Wizard(int ownerId, Vector2 mapPosition) : base(ownerId, mapPosition)
        {
            Sprite = new AnimatedSprite("Sprites/Wizard", Position);
        }
    }
}
