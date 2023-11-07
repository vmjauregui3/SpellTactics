using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Text;

namespace SpellTactics
{
    public class Map
    {
        private static int tileSize = 64;

        public int AmountOfTiles;
        protected Texture2D Texture;
        
        public int[,] tileMap;

        private List<Tile> tiles = new List<Tile>();

        public Map(string path, int tileCount) {
            Texture = SpellTactics.STContent.Load<Texture2D>(path);
            AmountOfTiles = tileCount;

            for (int i = 0; i < AmountOfTiles; i++)
            {
                Rectangle sourceRect = new Rectangle(tileSize * i, 0, tileSize, tileSize);
                tiles.Add(new Tile(Texture, sourceRect, tileSize));
            }

            tileMap = new int[5, 5];
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int j = 0; j < tileMap.GetLength(1); j++)
            {
                for (int i = 0; i < tileMap.GetLength(0); i++)
                {
                    tiles[tileMap[i, j]].Draw(spriteBatch, new Vector2(i * tileSize, j * tileSize));
                }
            }

        }
    }
}
