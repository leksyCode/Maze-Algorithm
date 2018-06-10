using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Step
    {
        public static Random rand = new Random();
        public static bool mustClose;
        public static int[,] MakeStep(int[,] board, int x, int y, out int X, out int Y)       
        {
            X = x; Y = y;
            int randDir = rand.Next(1,5);

                // if in our direction the wall, the closed door or the old way dont step
                if (randDir == 1 && (board[Y, X + 1] == TileTypes.WALL || board[Y, X + 1] == TileTypes.MOVE || board[Y, X + 1] == TileTypes.CLOSEDOOR))
                {
                    return board;
                }
                else if (randDir == 2 && (board[Y, X - 1] == TileTypes.WALL || board[Y, X - 1] == TileTypes.MOVE || board[Y, X - 1] == TileTypes.CLOSEDOOR))
                {
                    return board;
                }
                else if (randDir == 3 && (board[Y + 1, X] == TileTypes.WALL || board[Y + 1, X] == TileTypes.MOVE || board[Y + 1, X] == TileTypes.CLOSEDOOR))
                {
                    return board;
                }
                else if (randDir == 4 && (board[Y - 1, X] == TileTypes.WALL || board[Y - 1, X] == TileTypes.MOVE || board[Y - 1, X] == TileTypes.CLOSEDOOR))
                {
                    return board;
                }

            // if we go through the door, open and close some doors
             mustClose = Doors.checkOnClose(board, X, Y, randDir);         

            // make a step
            if (randDir == 1)
            {
                X++;
                board[Y, X] = TileTypes.MOVE;
                Console.WriteLine($"x: {X} y: {Y}");
                Program.printMaze();     
            }
            else if (randDir == 2)
            {
                X--;
                board[Y, X] = TileTypes.MOVE;
                Console.WriteLine($"x: {X} y: {Y}");
                Program.printMaze();
            }
            else if (randDir == 3)
            {
                Y++;
                board[Y, X] = TileTypes.MOVE;
                Console.WriteLine($"x: {X} y: {Y}");
                Program.printMaze();
            }
            else if (randDir == 4)
            {              
                Y--;
                board[Y, X] = TileTypes.MOVE;
                Console.WriteLine($"x: {X} y: {Y}");
                Program.printMaze();
            }
            else
            {
                Console.WriteLine("No Path");
                return board;
            }
            x = X; y = Y;
            return board;
        }
    }
}
