using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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

        public List<Player> Players;
        private int playerTurn;

        public List<Destructible> Destructibles = new List<Destructible>();

        public void AddDestructible(object destructible)
        {
            Destructibles.Add((Destructible)destructible);
        }

        public List<Creature> Controllables = new List<Creature>();
        public void AddControllable(object controllable)
        {
            Destructibles.Add((Creature)controllable);
        }

        public World(User user) 
        {
            GameCommands.PassDestructible = AddDestructible;
            GameCommands.PassControllable = AddControllable;

            Map = new Map("TileSheets/GroundTilesReduced", 5);

            User = user;
            foreach( Creature controllable in User.Controllables)
            {
                AddControllable(controllable);
                AddDestructible(controllable);
            }
            AIPlayer = new AIPlayer(1);

            Players = new List<Player>
            {
                User,
                AIPlayer
            };

            playerTurn = 0;
            
            StartPlayerTurn(playerTurn);
        }

        public void DetermineTurn()
        {
            foreach (Creature controllable in Controllables)
            {
                controllable.Speed.AddValue(controllable.Speed.ValueMax / 10);
            }
        }

        public void StartPlayerTurn(int player)
        {
            Players[player].StartTurn();
        }

        public void EndPlayerTurn()
        {
            playerTurn++;
            if (playerTurn >= Players.Count)
            {
                playerTurn = 0;
            }
            StartPlayerTurn(playerTurn);
        }

        public void Update(GameTime gameTime)
        {
            Map.Update();
            foreach (Player player in Players)
            {
                player.Update(gameTime, this);
            }
            //Camera.Instance.UpdatePosition(User.Wizard.Sprite.Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
            User.Draw(spriteBatch);
            AIPlayer.Draw(spriteBatch);
        }
    }
}
