using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public class Spell
    {
        protected int ownerId;
        public int OwnerId
        {
            get { return ownerId; }
        }

        private string name;
        public string Name
        {
            get { return name; }
        }

        private SpellType spellType;
        public SpellType SpellType
        {
            get { return spellType; }
        }

        private Dictionary<string, float> attributes = new Dictionary<string, float>();
        public Dictionary<string, float> Attributes
        {
            get { return attributes; }
        }

        private float cost;
        public int Cost
        {
            get { return (int)Math.Floor(cost); }
        }

        private float upkeep;
        public float Upkeep
        {
            get { return upkeep; }
        }

        private Vector2 targetDestination;
        public Vector2 TargetDestination
        {
            get { return targetDestination; }
        }

        private GameObject target;
        public GameObject Target
        {
            get { return target; }
        }

        public Spell(SpellType spellType, Dictionary<string, float> attributes) 
        { 
            this.spellType = spellType;
            this.attributes = attributes;
            CalculateCost();
        }

        public void CalculateCost()
        {
            cost = 1.0f;

            if(attributes.ContainsKey("Damage"))
            {
                cost += (int)Math.Floor(Math.Sqrt(attributes["Damage"]));
            }

            if (attributes.ContainsKey("Range"))
            {
                cost += (int)Math.Floor(attributes["Range"]) <= 5 ? 1 : (int)Math.Floor( (attributes["Range"]-5)/2 );
            }

            if (attributes.ContainsKey("Radius"))
            {
                cost += (int)Math.Floor(attributes["Radius"]);
            }
        }
    }
}
