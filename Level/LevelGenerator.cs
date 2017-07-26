using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWeek2017
{
    static class LevelGenerator
    {
        private static string _tileTextureName = "";

        // TODO: Should eventually be data driven
        //
        public static Tile[,] GenerateLevel(int width, int height, ContentManager manager)
        {
            Tile[,] level = new Tile[height, width];
            Texture2D tileTexture = manager.Load<Texture2D>(_tileTextureName);
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    level[i, j] = new Tile(tileTexture);
                }
            }

            return level;
        }
    }
}
