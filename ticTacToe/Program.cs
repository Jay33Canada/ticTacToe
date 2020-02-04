using System;

namespace ticTacToe
{
    class Program
    {
        static bool chooseInput = true;
        static void Main(string[] args)
        {
            
            
            while (chooseInput)
            {
                //choose to play a human or ai
                Console.WriteLine("Welcome to tic-tac-toe!");
                Console.WriteLine("\nWould like you to play againts a Friend or AI? \nEnter: 1 (for Friend)\nEnter: 2 (for AI)");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (choice == 1)
                    {
                        Console.WriteLine("You chose to play against another player on the same computer");
                        PlayHuman humanGame = new PlayHuman();
                        humanGame.PlayAHuman();
                        chooseInput = false;
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("You chose to play against the AI");
                        PlayAI aiGame = new PlayAI();
                        aiGame.PlayAIMatch();
                        chooseInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter either a 1 or a 2\n");
                    }
                    //when the game is over, ask if they want to play again
                    if (chooseInput == false)
                    {
                        playAgain();
                    }
                }
                catch
                {
                    Console.WriteLine("Please Enter either a 1 or a 2\n");
                }
            }
            

        }
        public static void Instructions()
        {
            Console.WriteLine("\nInstructions:");
            Console.WriteLine("Use the number pad to choose a position");
            Console.WriteLine("|7|8|9|");
            Console.WriteLine("|4|5|6|");
            Console.WriteLine("|1|2|3|\n");
        }
        static void playAgain()
        {
            bool again = false;
            while (again == false)
            {

                try
                {
                    Console.WriteLine("\nDo you want to play again? ");
                    Console.WriteLine("1: yes\n2: no");
                    int playAgain = Convert.ToInt32(Console.ReadLine());
                    if (playAgain == 1)
                    {
                        again = true;
                        chooseInput = true;
                    }
                    else if (playAgain == 2)
                    {
                        again = true;
                        chooseInput = false;
                        Console.WriteLine("Thanks for playing tic-tac-toe!");
                    }
                    else
                    {
                        Console.WriteLine("Please enter a 1 or 2");
                    }
                }
                catch 
                {
                    Console.WriteLine("Please enter a 1 or 2");
                }
            }
        }
    }
}
