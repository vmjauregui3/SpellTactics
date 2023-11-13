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

        public List<Player> players;
        private int playerTurn;

        public World() 
        {
            Map = new Map("TileSheets/GroundTilesReduced", 5);
            User = new User(0);
            AIPlayer = new AIPlayer(1);
            players = new List<Player>();
            playerTurn = 0;
            players.Add(User);
            players.Add(AIPlayer);
            StartPlayerTurn(playerTurn);
        }

        public void StartPlayerTurn(int player)
        {
            players[player].StartTurn();
        }

        public void EndPlayerTurn()
        {
            playerTurn++;
            if (playerTurn >= players.Count)
            {
                playerTurn = 0;
            }
            StartPlayerTurn(playerTurn);
        }

        public void Update(GameTime gameTime)
        {
            foreach(Player player in players)
            {
                player.Update(gameTime, AIPlayer, this);
            }

            Camera.Instance.UpdatePosition(User.Wizard.Sprite.Position);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Map.Draw(spriteBatch);
            User.Draw(spriteBatch);
            AIPlayer.Draw(spriteBatch);
        }
    }
}
