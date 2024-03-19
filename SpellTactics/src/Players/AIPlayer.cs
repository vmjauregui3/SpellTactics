using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpellTactics
{
    public class AIPlayer : Player
    {
        // AIPlayer defines a collection of computer-controlled objects working toward an objective; typically seeks to restrict user agency.

        // Constructor uses id to create objects under AIPlayer control. Currently, this class is static and unflexible in the game.
        // TODO: Create method of defining AIPlayers that is flexible and replicable. Likely requires this class to become an inheritor class.
        public AIPlayer(int id) : base(id)
        {
            Controllables.Add(new Wizard(id, new Vector2(11, 11)));
            Controllables.Add(new Wizard(id, new Vector2(11, 12)));
            Controllables.Add(new Wizard(id, new Vector2(12, 11)));
            Controllables.Add(new Wizard(id, new Vector2(12, 12)));


            ObjectiveTiles.Add(new ObjectiveTile(id, new Vector2(5, 2)));
            ObjectiveTiles.Add(new ObjectiveTile(id, new Vector2(10, 2)));

            //SpawnPoints.Add(new Portal(new Vector2(1300, 100), id));

            //SpawnPoints.Add(new Portal(new Vector2(1300, 800), id));
            //SpawnPoints[SpawnPoints.Count - 1].SpawnTimer.AddToTimer(500);
        }

        // Updates their Player.
        public override void Update(GameTime gameTime, World world)
        {
            base.Update(gameTime, world);
            if (isTurn)
            {
                world.EndTurn();
            }
        }
    }
}
