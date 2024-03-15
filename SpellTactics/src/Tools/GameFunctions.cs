using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellTactics
{
    public static class GameFunctions
    {
        public static Vector2 MapPosToPos(Vector2 mapPos)
        {
            return new Vector2(mapPos.X * STConstants.TileSize, mapPos.Y * STConstants.TileSize);
        }

        public static Vector2 PosToMapPos(Vector2 position)
        {
            return new Vector2((int)(position.X / STConstants.TileSize), (int)(position.Y / STConstants.TileSize));
        }

        // Does Nothing Currently

        public static int[,] CreateTileCircle( int radius)
        {
            int[,] tileArray = new int[2*radius+1,2*radius+1];



            return tileArray;
        }

    }
}
