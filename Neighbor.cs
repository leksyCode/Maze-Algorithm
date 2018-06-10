using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Neighbor
    {
        public static bool CheckNeighbor(int[,] board, int x, int y)
        {
                // if there is at least one empty cell
                if (board[y, x + 1] == TileTypes.EMPTY || board[y,x - 1] == TileTypes.EMPTY || board[y + 1, x] == TileTypes.EMPTY || board[y - 1, x] == TileTypes.EMPTY)
                {                  
                    return true;
                }
                else
                {
                    // if there is at least one door
                    if (board[y, x + 1] == TileTypes.DOOR || board[y, x - 1] == TileTypes.DOOR || board[y + 1, x] == TileTypes.DOOR || board[y - 1, x] == TileTypes.DOOR)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
        }
       
    }
}
