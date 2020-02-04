using System;
using System.Collections.Generic;
using System.Text;

namespace ticTacToe
{
    class PlayHuman
    {
        public void PlayAHuman()
        {
            Program.Instructions();
            Board board = new Board();
            bool winner = false;
            do
            {
                //if someone has won, winner becomes true.  the program ends.
                if (board.Won() || board.BoardFull())
                {
                    winner = true;
                    Console.WriteLine("The game is over.");
                }
                else
                {
                    board.UpdateBoard(board.getMove());
                }
            }
            while (winner == false);

        }
        class Board
        {
            //initial board values
            private string one = " ";
            private string two = " ";
            private string three = " ";

            private string four = " ";
            private string five = " ";
            private string six = " ";

            private string seven = " ";
            private string eight = " ";
            private string nine = " ";
            //variable to switch between who's turn it is
            private string turn = "x";
            
            public void ChangeLetter()
            {
                if (turn == "o")
                {
                    turn = "x";

                }
                else
                {
                    turn = "o";
                }
            }
            public Board()
            {
                //arrange the board to match the number pad
                Console.WriteLine("|{0}|{1}|{2}|", seven, eight, nine);

                Console.WriteLine("|{0}|{1}|{2}|", four, five, six);

                Console.WriteLine("|{0}|{1}|{2}|", one, two, three);
            }
            //check to see if the board is full. If it is, the game is over. 
            public bool BoardFull()
            {
                bool full = false;
                if (one != " " && two != " " && three != " " && four != " " && five != " " && six != " " && seven != " "
                    && eight != " " && nine != " ")
                {
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine("There are no more spaces left to play.");
                    full = true;
                }
                return full;
            }
            public bool Won()
            {
                bool hasWon = false;
                //x wins possibilities
                if (one == "x" && two == "x" && three == "x" ||
                    four == "x" && five == "x" && six == "x" ||
                    seven == "x" && eight == "x" && nine == "x" ||
                    one == "x" && four == "x" && seven == "x" ||
                    two == "x" && five == "x" && eight == "x" ||
                    three == "x" && six == "x" && nine == "x" ||
                    three == "x" && five == "x" && seven == "x" ||
                    one == "x" && five == "x" && nine == "x")
                {
                    Console.WriteLine("x you won!");
                    hasWon = true;
                }
                //o win possibilites
                else if (one == "o" && two == "o" && three == "o" ||
                         four == "o" && five == "o" && six == "o" ||
                         seven == "o" && eight == "o" && nine == "o" ||
                         one == "o" && four == "o" && seven == "o" ||
                         two == "o" && five == "o" && eight == "o" ||
                         three == "o" && six == "o" && nine == "o" ||
                         three == "o" && five == "o" && seven == "o" ||
                         one == "o" && five == "o" && nine == "o")
                {
                    Console.WriteLine("o you won!");
                    hasWon = true;
                }
                return hasWon;
            }
            public bool IsTaken(string pos)
            {
                bool hasLetter = false;
                if (pos == " ")
                {
                    return hasLetter;
                }
                else
                {
                    hasLetter = true;
                    return hasLetter;
                }

            }
            public void UpdateBoard(int move)
            {

                switch (move)
                {
                    case 1:
                        if (IsTaken(one))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            one = turn;
                            ChangeLetter();
                        }
                        break;
                    case 2:
                        if (IsTaken(two))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            two = turn;
                            ChangeLetter();
                        }
                        break;
                    case 3:
                        if (IsTaken(three))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            three = turn;
                            ChangeLetter();
                        }
                        break;
                    case 4:
                        if (IsTaken(four))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            four = turn;
                            ChangeLetter();
                        }
                        break;
                    case 5:
                        if (IsTaken(five))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            five = turn;
                            ChangeLetter();
                        }
                        break;
                    case 6:
                        if (IsTaken(six))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            six = turn;
                            ChangeLetter();
                        }
                        break;
                    case 7:
                        if (IsTaken(seven))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            seven = turn;
                            ChangeLetter();
                        }
                        break;
                    case 8:
                        if (IsTaken(eight))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            eight = turn;
                            ChangeLetter();
                        }
                        break;
                    case 9:
                        if (IsTaken(nine))
                        {
                            Console.WriteLine("This spot is taken. Please select another.");
                        }
                        else
                        {
                            nine = turn;
                            ChangeLetter();
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a whole number between 1 and 9");
                        break;
                }
                PrintBoard();
            }
            public int getMove()
            {
                int input = 1;
                int[] acceptableInputs = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                bool badInput = true;
                while (badInput)
                {
                    //this try catch is just to overcome the crashing error if someone hits enter right away, instead of giving any input
                    try
                    {
                        Console.WriteLine("\"{0}\" please enter a number between 1 and 9", turn);
                        input = Convert.ToInt32(Console.ReadLine());
                        foreach (int num in acceptableInputs)
                        {
                            if (input == num)
                            {
                                badInput = false;
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                //ChangeLetter();
                return input;
            }
            public void PrintBoard()
            {
                Console.WriteLine("|{0}|{1}|{2}|", seven, eight, nine);
                Console.WriteLine("|{0}|{1}|{2}|", four, five, six);
                Console.WriteLine("|{0}|{1}|{2}|", one, two, three);
            }
        }

    }
}
