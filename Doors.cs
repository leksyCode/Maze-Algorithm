using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Doors
    {
        public static Stack<int> lastDoor = new Stack<int>();
        public static int randCloseX; public static int randCloseY;
        public static int doorX, doorY;
        static Random rand = new Random(DateTime.Now.Millisecond);

        public static int[,] setFirstClose(int[,] board)
        {
            do
            {
                randCloseX = rand.Next(1, Program.BOARD_SIZE);
                randCloseY = rand.Next(1, Program.BOARD_SIZE);
            } while (board[randCloseY, randCloseX] != TileTypes.DOOR);
            board[randCloseY, randCloseX] = TileTypes.CLOSEDOOR;
            lastDoor.Push(randCloseX); lastDoor.Push(randCloseY);
            return board;
        }


        public static bool checkOnClose(int[,]board, int x, int y, int randDir)
        {
            bool closeOneMore;
                //it allows to create a closed door
                if (board[y, x + 1] == TileTypes.DOOR && randDir == 1)
                {
                doorY = y; doorX = x + 1;
                closeOneMore = true;
                }
                else if (board[y, x - 1] == TileTypes.DOOR && randDir == 2)
                {
                doorY = y; doorX = x - 1;
                closeOneMore = true;
                }
                else if (board[y + 1, x] == TileTypes.DOOR && randDir == 3)
                {
                doorY = y + 1; doorX = x;
                closeOneMore = true;
                }
                else if (board[y - 1, x] == TileTypes.DOOR && randDir == 4)
                {
                doorY = y - 1; doorX = x;
                closeOneMore = true;
                }
                else
                {
                    closeOneMore = false;
                }
            return closeOneMore;
        }
       
        public static int[,] Close(int[,] board)
        {
            int lastDoorX = doorX, lastDoorY = doorY;
           // Close door after throwing
           board[lastDoorY, lastDoorX] = TileTypes.CLOSEDOOR;


            if (lastDoor.Count != 0)
            {
                // removes the last closed doors
               
                    board[lastDoor.Pop(), lastDoor.Pop()] = TileTypes.DOOR;
  
            }
            //remembered last door
            lastDoor.Push(lastDoorX); lastDoor.Push(lastDoorY);
            return board;
        }
    }
}

