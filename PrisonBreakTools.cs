using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    public static class PrisonBreakTools
    { 
        public static int[,] getNewMaze(int n, Random rand) 
        {
            int[,] maze = new int [n,n];
           

            for(int i=0; i<n; i++)
            {
                for(int j=0; j<n; j++)
                {
                    int typeRand = rand.Next(1, 100);
                    if(typeRand <= 45)
                    {
                        maze[i, j] = TileTypes.EMPTY;
                    }
                    else if(typeRand <= 90)
                    {
                        maze[i, j] = TileTypes.WALL;
                    }
                    else
                    {
                        maze[i, j] = TileTypes.DOOR;
                    }
                }
            }

            return maze;

        }
    }
}
