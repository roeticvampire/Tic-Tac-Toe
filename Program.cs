using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe__legendary_
{
    class Program
    {
        static char[,] Board;
        static int gridsize = 0;
        static bool turn=true; // true: Player 1(X), false: player 2(O)
        //static List<int, int> player1 = new List<,>();


        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of grid (1-26)");
            while (true)
            {
                gridsize = int.Parse(Console.ReadLine());
                if(gridsize<27&&gridsize>0)
                break;
                Console.WriteLine("Invalid Input. Please enter a number in (1-26)");
            }
            
            initialise();
            Display();
            for(int tot=gridsize*gridsize-1;tot>=0;tot--)
            {
                if (turn)
                {
                    //Player 1 (X)
                    string input = Console.ReadLine().ToUpper();
                    while (true)
                    {
                        if (input[0] >= 65 && input[0] < 65 + gridsize && input[1] >= 65 && input[1] < 65 + gridsize)
                            if (Board[input[1] - 65, input[0] - 65] == ' ')
                                break;
                        Console.WriteLine("Invalid Input! Please try again");
                        input = Console.ReadLine().ToUpper();
                    }
                    Board[input[1] - 65, input[0] - 65] = 'X';
                }
                else
                {
                    //Player 2 (O)
                    string input = Console.ReadLine().ToUpper();
                    while (true)
                    {
                        if (input[0] >= 65 && input[0] < 65 + gridsize && input[1] >= 65 && input[1] < 65 + gridsize)
                            if (Board[input[1] - 65, input[0] - 65] == ' ')
                                break;
                        Console.WriteLine("Invalid Input! Please try again");
                        input = Console.ReadLine().ToUpper();
                    }
                    Board[input[1] - 65, input[0] - 65] = 'O';

                }


                if (wincheck())
                {
                    Console.WriteLine("Aww Jeet gaye");
                    break;
                }
                turn = !turn;
                Display();
               



            }


            

            
            Display();


            Console.WriteLine("Jeet gaye");



        }

        private static bool wincheck()
        {
            char c = turn ? 'X' : 'O';
            int i = 0,j = 0;
            //first diagonal
            for (i = 0; i < gridsize; i++)
                if (Board[i, i] != c) i=gridsize+1;
            if (i == gridsize) return true;
            ///2nd diagonal
            for (i = 0; i < gridsize; i++)
                if (Board[gridsize-1-i, i] != c) i=gridsize+1;
            if (i == gridsize) return true;

            ///Rows
            for (i = 0; i < gridsize; i++)
            {
                for (j = 0; j < gridsize; j++)
                {
                    if (Board[i, j] != c) j = gridsize + 1;
                }
                if (j == gridsize) return true;
            }
            ///Rows
            for (i = 0; i < gridsize; i++)
            {
                for (j = 0; j < gridsize; j++)
                {
                    if (Board[j, i] != c) j=gridsize+1;
                }
                if (j == gridsize) return true;

            }
            return false;

        }

        static void initialise()
        {
            Board = new char[gridsize, gridsize];
            for (int i = 0; i < gridsize; i++)
            {
                for (int j = 0; j < gridsize; j++)
                {
                    Board[i, j] = ' ';
                }
            }

        }



        static void Display()
        { 
            Console.Clear();
            Console.Write("   ");
            for (int i = 0; i < gridsize; i++)
            Console.Write((char)(65 + i) + "   ");
            Console.Write("\n");


            int width = gridsize + (gridsize-1) * 3;
            for (int i = 0; i < gridsize-1; i++)
            {
                Console.Write((char)(65 + i) + "  ");
                for (int j = 0; j < gridsize-1; j++)
                {
                    Console.Write(Board[i, j] + " | ");
                }
                Console.Write(Board[i, gridsize-1] + "\n   ");
                for (int j = 0; j < width; j++)
                    Console.Write("-");
                Console.Write("\n");

            }

            Console.Write((char)(gridsize - 1 + 65) + "  ");
            for (int j = 0; j < gridsize - 1; j++)
            {
                Console.Write(Board[gridsize-1, j] + " | ");
            }
            Console.Write(Board[gridsize-1, gridsize - 1] + "\n\n\n\n\n");
            String currPlayer = turn ? "Player 1 (X)" : "Player 2 (O)";
            Console.WriteLine("Current Player: "+ currPlayer);
            Console.WriteLine("\n------------------------------------------------------\nTo Play, Enter [Column][Row]: eg. AB , BC, CA");
        }





    }
}
