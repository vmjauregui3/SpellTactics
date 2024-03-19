using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;

namespace SpellTactics
{
    public abstract class Creature : Destructible
    {
        // Creature is an abstract grouping of destructibles that have some form of intelligence commanding them.



        protected VariableStat speed;
        public VariableStat Speed
        {
            get { return speed; }
        }
        protected VariableStat movement;
        public VariableStat Movement
        {
            get { return movement; }
        }


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

        public Creature(int ownerId, Vector2 mapPosition) : base(ownerId, mapPosition)
        {
            speed = new VariableStat(100);
            speed.SetValue(0);
            movement = new VariableStat(3);
            mana = new VariableStat(1000);
            manaRegen = new VariableStat(5);
            manaTimer = new MTimer(100);
            IsCasting = false;
        }

        public void ToggleCasting()
        {
            IsCasting = !IsCasting;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
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


        public void Move(Vector2 movement)
        {
            MapPosition += movement;
            Sprite.Position = Position;
            this.movement.AddValue(-1);
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

        public override void StartTurn()
        {
            base.StartTurn();
            movement.SetValue(movement.ValueMax);
        }
    }
}

