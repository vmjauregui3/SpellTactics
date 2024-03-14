﻿using Microsoft.Xna.Framework;
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
        protected bool isTurn;

        public List<Creature> Controllables = new List<Creature>();

        // Player id is used to organize Creatures under Player control.
        private int id;
        public int Id
        {
            get { return id; }
        }


        protected Destructible targetObject;
        protected Vector2 targetPosition;

        public Player(int id)
        {
            this.id = id;
            bool isTurn = false;
            targetPosition = Vector2.Zero;
        }
        
        public virtual void ControlMovements()
        {

        }

        public void EndTurn()
        {
            ControlMovements();
            isTurn = false;
        }

        public Vector2 GetTile(Vector2 position)
        {
            return new Vector2((int)(position.X / STConstants.TileSize), (int)(position.Y / STConstants.TileSize));
        }


        public void SelectObject(Vector2 mapPosition, Dictionary<Vector2, Destructible> destructibles)
        {
            if (destructibles.ContainsKey(mapPosition))
            {
                DeselectObject();
                targetObject = destructibles[mapPosition];
                destructibles[mapPosition].Sprite.Tint = Color.Red;
            }
            /*
            foreach(Destructible destructible in destructibles)
            {
                if (destructible.MapPosition.Equals(mapPosition))
                {
                    DeselectObject();
                    targetObject = destructible;
                    destructible.Sprite.Tint = Color.Red;
                }
            }
            */
        }

        public void DeselectObject()
        {
            if (targetObject != null)
            {
                targetObject.Sprite.Tint = Color.White;
            }
            targetObject = null;
        }

        public virtual void StartTurn()
        {
            isTurn = true;
        }

        public virtual void Update(GameTime gameTime, World world)
        {
            if (isTurn)
            {
                world.EndTurn();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Creature controllable in Controllables)
            {
                controllable.Draw(spriteBatch);
            }
        }
    }
}
