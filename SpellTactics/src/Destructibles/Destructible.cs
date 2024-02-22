﻿using Microsoft.Xna.Framework;
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
    public abstract class Destructible
    {
        // Destructibles are objects that represent everything in the game that has hit points and can be destroyed.

        // Destructibles contain a sprite that represents them visiually and contains their game location.
        public AnimatedSprite Sprite;

        public Vector2 MapPosition;

        public Vector2 Position
        {
            get { return MapPosition * STConstants.TileSize; }
        }


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

        // ownerID determines how the object interacts with its surroundings.
        private int ownerId;
        public int OwnerId
        {
            get { return ownerId; }
        }

        protected bool isTurn;

        protected bool isLoaded;
        public bool IsLoaded
        {
            get { return isLoaded; }
        }

        // The constructor requires an ID to be created.
        public Destructible(int ownerId, Vector2 mapPosition)
        {
            this.ownerId = ownerId;
            isDead = false;
            isTurn = false;
            health = new VariableStat(10);
            MapPosition = mapPosition;
            //Position = MapPosToPos(mapPosition);
        }

        public Vector2 MapPosToPos(Vector2 mapPos)
        {
            return new Vector2(mapPos.X*STConstants.TileSize, mapPos.Y*STConstants.TileSize);
        }

        public void CheckIfDead()
        {
            if (health.Value <= 0)
            {
                isDead = true;
            }
        }

        public void Move(Vector2 movement)
        {
            MapPosition += movement;
            Sprite.Position = Position;
        }

        public void SetIsLoaded(bool isLoaded)
        {
            this.isLoaded = isLoaded;
        }

        public virtual void EndTurn()
        {
            isTurn = false;
            Sprite.Tint = Color.White;
        }

        public virtual void StartTurn()
        {
            isTurn = true;
            Sprite.Tint = Color.Black;
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

        // Updates the Sprite.
        public virtual void Update(GameTime gameTime, Player enemy)
        {
            Sprite.Update(gameTime);
        }

        // Draws the Sprite.
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch);
        }
    }
}
