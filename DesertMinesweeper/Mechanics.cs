using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesertMinesweeper
{
    class Mechanics
    {
        public static int [,]GenerateMap(int width, int height, int bombs, int click_x, int click_y){
        
            int[,] map = new int[width,height];
            map[click_x, click_y] = -1;
            Random rnd = new Random();
            int x;
            int y;

            for (int i = 0; i < bombs; i++)
            {
                
                bool placedBomb = false;
                while (!placedBomb)
                {
                    x = rnd.Next(width);
                    y = rnd.Next(height);
                    if (map[x, y] != -1)
                    {
                        map[x, y] = -1;
                        placedBomb = true;
                    }
                }
            }
            map[click_x, click_y] = 0;
        
            return AddNumbersToMap(map, width, height);
        }


        public static int[,] AddNumbersToMap(int[,] map, int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (map[i, j] != -1)
                    {
                        if (i > 0 && map[i - 1, j] == -1) { map[i, j]++; }
                        if (i < (width-1) && map[i + 1, j] == -1) { map[i, j]++; }
                        if (j > 0 && map[i, j - 1] == -1) { map[i, j]++; }
                        if (j < (height-1) && map[i, j + 1] == -1) { map[i, j]++; }
                        if (i > 0 && j > 0 && map[i - 1, j - 1] == -1) { map[i, j]++; }
                        if (i > 0 && j < (height-1) && map[i - 1, j + 1] == -1) { map[i, j]++; }
                        if (i < (width - 1) && j > 0 && map[i + 1, j - 1] == -1) { map[i, j]++; }
                        if (i < (width - 1) && j <(height-1) && map[i + 1, j + 1] == -1) { map[i, j]++; }
                    }
                }
            }
            return map;
        }


    }
}
