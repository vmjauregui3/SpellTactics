using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpellTactics
{
    public abstract class Creature : Destructible
    {
        // Creature is an abstract grouping of destructibles that have some form of intelligence commanding them.

        // Creatures have mana which determines when what abilities they can use and when.
        protected VariableStat mana;
        public VariableStat Mana
        {
            get { return mana; }
        }
        protected VariableStat manaRegen;
        public VariableStat ManaRegen
        {
            get { return mana; }
        }
        protected MTimer manaTimer;

        public bool IsCasting;

        public Creature(int ownerId, Vector2 position) : base(ownerId, position)
        {
            movement = new Stat(3);
            mana = new VariableStat(1000);
            manaRegen = new VariableStat(5);
            manaTimer = new MTimer(100);
            IsCasting = false;
        }

        public void ToggleCasting()
        {
            IsCasting = !IsCasting;
        }

        public override void Update(GameTime gameTime, Player enemy)
        {
            base.Update(gameTime, enemy);
        }

        // UpdateHealth damages the object and checks its life status afterward.
        // TODO: Complicate the damage calculation using updated stats variables.
        public virtual void UpdateMana(int manaCost)
        {
            mana.AddValue(-manaCost);
            if (mana.Value > mana.ValueMax)
            {
                mana.SetValue(mana.ValueMax);
            }
        }

        public override void UpdateHealthModified(float damage)
        {
            float finalDamage = damage;

            UpdateHealth(finalDamage);
        }

        public bool HasMana(int manaCost)
        {
            bool hasMana = true;
            if (manaCost > mana.Value)
            {
                hasMana = false;
            }
            return hasMana;
        }
    }
}

