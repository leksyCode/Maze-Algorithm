using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonBreak
{
    class Program
    {
        public static Random rand = new Random(DateTime.Now.Millisecond);
        public static readonly int BOARD_SIZE = 15;
        public static int[,] board;
        public static int clsDoorX, clsDoorY;

        public static void printMaze()
        {
         
            
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                { // chenge colors
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (board[i, j] == TileTypes.MOVE)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", board[i, j]);
                        Console.ResetColor();
                    }
                    else if(board[i,j] == TileTypes.CLOSEDOOR)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", board[i, j]);
                        Console.ResetColor();
                        clsDoorY = i; clsDoorX = j;
                    }
                    else
                    {  
                        Console.Write("{0} ", board[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Close door: {clsDoorY}, {clsDoorX} "); // REMAKE
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            bool noPath = false;
            bool back = false;
            do
            {
                Console.Clear();

                // Get random board
                board = PrisonBreakTools.getNewMaze(BOARD_SIZE, rand);

                // Get random starting point            
                int startX, startY;

                do
                {
                    startX = rand.Next(0, BOARD_SIZE);
                    startY = rand.Next(0, BOARD_SIZE);
                }
                while (board[startY, startX] != TileTypes.EMPTY || startX == 0 || startY == 0 || startX == BOARD_SIZE - 1 || startY == BOARD_SIZE - 1);
                Console.WriteLine("Start: {0} {1}", startY, startX);
                //////////////////////////// Your output goes here/////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////////

                int x = startX; int y = startY;
                int X; int Y;
                board[y, x] = TileTypes.MOVE;
                Stack<int> lastXY = new Stack<int>(); // for backtracking     

                Doors.setFirstClose(board);
                printMaze();

                while (x != 0 && y != 0 && x != BOARD_SIZE - 1 && y != BOARD_SIZE - 1)
                {
                    if (Neighbor.CheckNeighbor(board, x, y))
                    {
                        // remembered last x,y in stack     
                        lastXY.Push(x); lastXY.Push(y);
                        X = x; Y = y;
                        if (Step.mustClose)
                        {
                            Doors.Close(board);
                        }

                        Step.MakeStep(board, x, y, out X, out Y);

                        x = X; y = Y; // out X,Y after chenges 
                    }
                    else if (lastXY.Count != 0)
                    {
                        y = Convert.ToInt32(lastXY.Pop());
                        x = Convert.ToInt32(lastXY.Pop());
                        Console.WriteLine("BackTreking...");
                    }
                    else
                    {
                        Console.WriteLine("No Path!");
                        noPath = true;
                        break;
                    }
                }
                if (noPath == false)
                {
                    Console.WriteLine($"Exit: {y}, {x}");
                }             
                back = Convert.ToBoolean(Convert.ToInt16(Console.ReadLine()));
            } while (back);
            Environment.Exit(0);
        }
    }
}

