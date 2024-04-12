using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public class ObjectiveTile : GameObject
    {
        public bool IsCaptured;
        public ObjectiveTile(int ownerId, Vector2 mapPosition) : base(ownerId, mapPosition)
        {
            IsCaptured = false;

            String imagePath = "Sprites/ObjectiveTiles/RedObjective";
            if (ownerId == 1)
            {
                imagePath = "Sprites/ObjectiveTiles/BlueObjective";
            }
            Sprite = new AnimatedSprite(imagePath, Position);
        }

        public void GetCaptured()
        {
            IsCaptured = true;
            String imagePath = "Sprites/ObjectiveTiles/CapturedRedObjective";
            if (ownerId == 1)
            {
                imagePath = "Sprites/ObjectiveTiles/CapturedBlueObjective";
            }
            Sprite = new AnimatedSprite(imagePath, Position);
        }
    }
}
