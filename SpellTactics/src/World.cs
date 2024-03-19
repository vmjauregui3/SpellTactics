using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{

    public class World
    {
        public Map Map;
        public User User;
        public AIPlayer AIPlayer;

        //public List<Player> Players;
        public Dictionary<int, Player> Players;

        public Creature CreatureTurn;

        public List<Destructible> Destructibles = new List<Destructible>();

        
        public void AddDestructible(Vector2 mapPos, object destructible)
        {
            Destructibles.Add((Destructible)destructible);
        }
        

        public LinkedList<Creature> Controllables = new LinkedList<Creature>();
        public void AddControllable(object controllable)
        {
            Controllables.AddLast((Creature)controllable);
        }

        public World(User user) 
        {
            //GameCommands.PassDestructible = AddDestructible;
            GameCommands.PassControllable = AddControllable;

            Map = new Map("TileSheets/GroundTilesReduced", 5);

            User = user;
            foreach( Creature controllable in User.Controllables)
            {
                AddControllable(controllable);
                AddDestructible(controllable.MapPosition, controllable);
            }
            AIPlayer = new AIPlayer(1);
            foreach (Creature controllable in AIPlayer.Controllables)
            {
                AddControllable(controllable);
                AddDestructible(controllable.MapPosition, controllable);
            }

            Players = new Dictionary<int, Player>
            {
                { 0, User },
                { 1, AIPlayer }
            };


            DetermineTurn();
        }

        public void DetermineTurn()
        {
            bool turnFound = false;
            while (!turnFound)
            {

                foreach (Creature controllable in Controllables)
                {
                    if ((controllable.Speed.Value.CompareTo(controllable.Speed.ValueMax) >= 0) && !turnFound)
                    {
                        controllable.Speed.AddValue(-controllable.Speed.ValueMax);
                        StartTurn(controllable);
                        //controllable.StartTurn();
                        //StartPlayerTurn(controllable.OwnerId);
                        turnFound = true;
                    }
                }
                if (!turnFound)
                {
                    foreach (Creature controllable in Controllables)
                    {
                        controllable.Speed.AddValue(controllable.Speed.ValueMax / 10);
                    }
                }
            }
        }

        public void StartTurn(Creature creatureTurn)
        {
            CreatureTurn = creatureTurn;
            creatureTurn.StartTurn();
            Players[creatureTurn.OwnerId].StartTurn();
        }

        public void EndTurn()
        {
            Players[CreatureTurn.OwnerId].EndTurn();
            CreatureTurn.EndTurn();
            DetermineTurn();
        }

        public void Update(GameTime gameTime)
        {
            Map.Update();
            foreach (var player in Players)
            {
                player.Value.Update(gameTime, this);
            }

            //Camera.Instance.UpdatePosition(User.Wizard.Sprite.Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
            AIPlayer.Draw(spriteBatch);
            User.Draw(spriteBatch);
        }
    }
}
