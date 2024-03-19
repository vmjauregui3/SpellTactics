using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    // TODO: Requires Updated Stat Variables
    // TODO: Create an inherited Class that defines anything with agency in the game environment (such as indestructible buildings).
    public abstract class Destructible : GameObject
    {
        // Destructibles are objects that represent everything in the game that has hit points and can be destroyed.

        // Objects have health which determines when they get destroyed.
        protected VariableStat health;
        public VariableStat Health
        {
            get { return health; }
        }

        // isDead tracks when the object still needs to be updated and drawn.
        protected bool isDead;
        public bool IsDead
        {
            get { return isDead; }
        }

        protected bool isTurn;

        protected bool isLoaded;
        public bool IsLoaded
        {
            get { return isLoaded; }
        }

        // The constructor requires an ID to be created.
        public Destructible(int ownerId, Vector2 mapPosition) : base(ownerId, mapPosition)
        {
            isDead = false;
            isTurn = false;
            health = new VariableStat(10);
            MapPosition = mapPosition;
            //Position = MapPosToPos(mapPosition);
        }

        public void CheckIfDead()
        {
            if (health.Value <= 0)
            {
                isDead = true;
            }
        }

        public void SetIsLoaded(bool isLoaded)
        {
            this.isLoaded = isLoaded;
        }

        public virtual void EndTurn()
        {
            isTurn = false;
        }

        public virtual void StartTurn()
        {
            isTurn = true;
        }

        // UpdateHealth damages the object and checks its life status afterward.
        // TODO: Complicate the damage calculation using updated stats variables.
        public virtual void UpdateHealthModified(float damage)
        {
            UpdateHealth(damage);
        }

        public virtual void UpdateHealth(float damage)
        {
            health.AddValue(-damage);
            if (health.Value > health.ValueMax)
            {
                health.SetValue(health.ValueMax);
            }
            CheckIfDead();
        }
    }
}
