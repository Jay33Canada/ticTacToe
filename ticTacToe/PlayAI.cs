using System;
using System.Collections.Generic;

namespace ticTacToe
{

    class PlayAI
    {
        //call this method to play a game
        public void PlayAIMatch()
        {
            //start a new instance to play the game
            PlayAI aiGame = new PlayAI();
            //set winner to false for while loop
            bool winner = false;   
            //find out what difficulty they want to play
            string difficultyLevel = "easy";        
            Console.WriteLine("Which difficulty would you like to play on?\n1 easy\n2 hard");
            int chosenDifficulty = Convert.ToInt32(Console.ReadLine());
            //set the difficulty
            if (chosenDifficulty == 1)
            {
                difficultyLevel = "easy";
            }
            else if (chosenDifficulty == 2)
            {
                difficultyLevel = "hard";
            }
            Console.WriteLine("\nYou chose to play on {0}", difficultyLevel);
            //print instructions
            Program.Instructions();
            PrintBoard();
            //main loop for the game, regardless of the difficulty chosen
            do
            {
                //if someone has won, winner becomes true.  the program ends.
                //or, if the board if full and there are no more moves left, the game ends.
                if (Won() || BoardFull())
                {
                    winner = true;
                    Console.WriteLine("The game is over.");
                }
                else
                {
                    //x will be human
                    if (turn == "x")
                    { 
                        //get the humans next move and update the board
                        UpdateBoardHuman(GetPlayersMove());
                    }
                    //o will be AI
                    else if (turn == "o")
                    {
                        if (difficultyLevel == "easy")
                        {
                            AIEasyMove();
                        }
                        else if (difficultyLevel == "hard")
                        {
                            // DifficultAi();
                            DifficultAiMove();
                            //temperary
                            
                        }
                    }

                    
                }
            }
            while (winner == false);

        }
        //initial board values
        GridSlot one;
        GridSlot two;
        GridSlot three;

        GridSlot four;
        GridSlot five;
        GridSlot six;

        GridSlot seven;
        GridSlot eight;
        GridSlot nine;
        //variable to switch between who's turn it is
        string turn = "x";
        //list of all positions for AI to use. it needs a list to see what's taken and what's available.  then, it can make decisions from there
        LinkedList<GridSlot> AllPositions = new LinkedList<GridSlot>(); //{ one, two, three, four, five, six, seven, eight, nine };
       
        public PlayAI()
        {
            //initalize the positions on the board
            one = new GridSlot();
            one.name = "one";
            two = new GridSlot();
            two.name = "two";
            three = new GridSlot();
            three.name = "three";
            four = new GridSlot();
            four.name = "four";
            five = new GridSlot();
            five.name = "five";
            six = new GridSlot();
            six.name = "six";
            seven = new GridSlot();
            seven.name = "seven";
            eight = new GridSlot();
            eight.name = "eight";
            nine = new GridSlot();
            nine.name = "nine";

            //add the gridslot instances to a list
            AllPositions.AddLast(one);
            AllPositions.AddLast(two);
            AllPositions.AddLast(three);
            AllPositions.AddLast(four);
            AllPositions.AddLast(five);
            AllPositions.AddLast(six);
            AllPositions.AddLast(seven);
            AllPositions.AddLast(eight);
            AllPositions.AddLast(nine);
        }
        public void PrintBoard()
        {
            Console.WriteLine("|{0}|{1}|{2}|", seven.placedCharacter, eight.placedCharacter, nine.placedCharacter);
            Console.WriteLine("|{0}|{1}|{2}|", four.placedCharacter, five.placedCharacter, six.placedCharacter);
            Console.WriteLine("|{0}|{1}|{2}|", one.placedCharacter, two.placedCharacter, three.placedCharacter);
        }
        public bool BoardFull()
        {
            bool full = false;
            if (one.placedCharacter != " " && two.placedCharacter != " " && three.placedCharacter != " " && four.placedCharacter != " " && five.placedCharacter != " " && six.placedCharacter != " " && seven.placedCharacter != " "
                && eight.placedCharacter != " " && nine.placedCharacter != " ")
            {
                Console.WriteLine("It's a draw!");
                full = true;
            }
            return full;
        }
        public bool Won()
        {
            bool hasWon = false;
            //x wins possibilities
            if (one.placedCharacter == "x" && two.placedCharacter == "x" && three.placedCharacter == "x" ||
                four.placedCharacter == "x" && five.placedCharacter == "x" && six.placedCharacter == "x" ||
                seven.placedCharacter == "x" && eight.placedCharacter == "x" && nine.placedCharacter == "x" ||
                one.placedCharacter == "x" && four.placedCharacter == "x" && seven.placedCharacter == "x" ||
                two.placedCharacter == "x" && five.placedCharacter == "x" && eight.placedCharacter == "x" ||
                three.placedCharacter == "x" && six.placedCharacter == "x" && nine.placedCharacter == "x" ||
                three.placedCharacter == "x" && five.placedCharacter == "x" && seven.placedCharacter == "x" ||
                one.placedCharacter == "x" && five.placedCharacter == "x" && nine.placedCharacter == "x")
            {
                Console.WriteLine("You won against the AI! You're so clever!");
                hasWon = true;
            }
            //o win possibilites
            else if (one.placedCharacter == "o" && two.placedCharacter == "o" && three.placedCharacter == "o" ||
                     four.placedCharacter == "o" && five.placedCharacter == "o" && six.placedCharacter == "o" ||
                     seven.placedCharacter == "o" && eight.placedCharacter == "o" && nine.placedCharacter == "o" ||
                     one.placedCharacter == "o" && four.placedCharacter == "o" && seven.placedCharacter == "o" ||
                     two.placedCharacter == "o" && five.placedCharacter == "o" && eight.placedCharacter == "o" ||
                     three.placedCharacter == "o" && six.placedCharacter == "o" && nine.placedCharacter == "o" ||
                     three.placedCharacter == "o" && five.placedCharacter == "o" && seven.placedCharacter == "o" ||
                     one.placedCharacter == "o" && five.placedCharacter == "o" && nine.placedCharacter == "o")
            {
                Console.WriteLine("You've been defeated by the AI.");
                hasWon = true;
            }
            return hasWon;
        }
        public int GetPlayersMove()
        {
            int input = 1;
            int[] acceptableInputs = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bool badInput = true;
            while (badInput)
            {
                //this try catch is just to overcome the crashing error if someone hits enter right away, instead of giving any input
                try
                {
                    Console.WriteLine("Please enter your move human: ");
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
            return input;
        }
        public bool IsSpotTaken(string pos)
        {
            bool free = true;
            if (pos == " ")
            {
                free = false;
            }
            return free;
        }
        public void UpdateBoardHuman(int pos)
        {
            bool goAgain = false;
            switch (pos)
            {
                case 1:
                    if(IsSpotTaken(one.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        one.placedCharacter = "x";
                        //this is where i am at ***********************************************************
                        //Console.WriteLine("******************************");
                        //foreach(GridSlot gs in AllPositions)
                        //{
                        //    Console.WriteLine(gs + " " + gs.name + " " + gs.placedCharacter);
                        //}
                        //Console.WriteLine("******************************");
                    }
                    break;
                case 2:
                    if (IsSpotTaken(two.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        two.placedCharacter = "x";
                    }
                    break;
                case 3:
                    if (IsSpotTaken(three.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        three.placedCharacter = "x";
                    }
                    break;
                case 4:
                    if (IsSpotTaken(four.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        four.placedCharacter = "x";
                    }
                    break;
                case 5:
                    if (IsSpotTaken(five.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        five.placedCharacter = "x";
                    }
                    break;
                case 6:
                    if (IsSpotTaken(six.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        six.placedCharacter = "x";
                    }
                    break;
                case 7:
                    if (IsSpotTaken(seven.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        seven.placedCharacter = "x";
                    }
                    break;
                case 8:
                    if (IsSpotTaken(eight.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        eight.placedCharacter = "x";
                    }
                    break;
                case 9:
                    if (IsSpotTaken(nine.placedCharacter))
                    {
                        Console.WriteLine("This position has already been used.  Please choose another");
                        goAgain = true;
                    }
                    else
                    {
                        nine.placedCharacter = "x";
                    }
                    break;
                default:
                    break;
            }
            if(goAgain)
            {
                turn = "x";
            }
            else
            {
                Console.WriteLine("\nYou chose {0}", pos);
                turn = "o";
            }            
            PrintBoard();
        }
        public void AIEasyMove()
        {
            //AllPositions.Find(one).Value.placedCharacter == "x"
            List<GridSlot> availableSpaceList = new List<GridSlot>();
            foreach (GridSlot pos in AllPositions)
            {                
                if (pos.placedCharacter == " ")
                {
                    availableSpaceList.Add(pos);
                }
            }
            if (availableSpaceList.Count > 0)
            {
                int listLength = availableSpaceList.Count;
                Random randomNumber = new Random();
                int whereToPlaceO = randomNumber.Next(1,listLength);
                availableSpaceList[whereToPlaceO - 1].placedCharacter = "o";//minus one to account for 0 based index of availableSpaceList
                string numberChoosen = availableSpaceList[whereToPlaceO - 1].name;
                Console.WriteLine("The AI chose {0}", numberChoosen);
            }
            turn = "x";
            PrintBoard();
        }
        public void DifficultAiMove()
        {
            //make a two dimensional array of GridSlot elements that stores all of the rows, columns, and diagnals to check.
            //what I'm checking for, is a way to win, and a way to block.
            GridSlot[,] checkForPossibleWin =
                {
                 { one, two, three},
                 { four, five, six},
                 { seven, eight, nine},
                 { one, four, seven},
                 { two, five, eight},
                 { three, six, nine},
                 { three, five, seven},
                 { one, five, nine}
                };

            //variable for name of the chosen spot to place a character for the AI
            string chosenName = "";
            //variable to break out of for loop if a win or block has happened.
            //this same variable is also used to tell me not to look for a best move, 
            //if i've already made a block or win move. (can't go twice in a row. that's cheating)
            bool foundWinOrBlock = false;
            //I want to iterate through this checkForPossibleWin array, one group at a time, and count the number of x's and o's
            for (int gridSlotSet = 0; gridSlotSet < checkForPossibleWin.GetLength(0); gridSlotSet++)
            {
                //Console.WriteLine(checkForPossibleWin.GetLength(0));
                //variables to count with
                int countX = 0;
                int countO = 0;
               
                
                for(int gridSlotCharacterCheck = 0; gridSlotCharacterCheck < checkForPossibleWin.GetLength(1); gridSlotCharacterCheck++)
                {
                    //Console.WriteLine(checkForPossibleWin.GetLength(1));
                    if (checkForPossibleWin[gridSlotSet, gridSlotCharacterCheck].placedCharacter == "x")
                    {
                        countX++;
                    }
                    else if (checkForPossibleWin[gridSlotSet, gridSlotCharacterCheck].placedCharacter == "o")
                    {
                        countO++;
                    }
                }
                //if the number of x's is == 2 and there are no o's, then, i should place an o in the empty spot to block
                if (countX == 2 && countO == 0)
                {
                    for (int gridSlotCharacterCheck = 0; gridSlotCharacterCheck < checkForPossibleWin.GetLength(1); gridSlotCharacterCheck++)
                    {
                        if (checkForPossibleWin[gridSlotSet,gridSlotCharacterCheck].placedCharacter == " ")
                        {
                            checkForPossibleWin[gridSlotSet, gridSlotCharacterCheck].placedCharacter = "o";
                            chosenName = checkForPossibleWin[gridSlotSet, gridSlotCharacterCheck].name;
                        }
                    }
                    foundWinOrBlock = true;
                }
                //if the number of o's is == 2 and there are no x's, then, add an o to win (in the blank space that's left)
                else if (countO == 2 && countX ==0)
                {
                    for (int gridSlotCharacterCheck = 0; gridSlotCharacterCheck < checkForPossibleWin.GetLength(1); gridSlotCharacterCheck++)
                    {
                        if (checkForPossibleWin[gridSlotSet, gridSlotCharacterCheck].placedCharacter == " ")
                        {
                            checkForPossibleWin[gridSlotSet, gridSlotCharacterCheck].placedCharacter = "o";
                            chosenName = checkForPossibleWin[gridSlotSet, gridSlotCharacterCheck].name;
                        }
                    }
                    foundWinOrBlock = true;
                }
                if(foundWinOrBlock)
                { 
                    break;
                }
            }
            //i'll also want to check for the best move if i can't win or block.
            //to do that, I will do one of three things
            //first, if the GridSlot five is has a placedCharacter value of " ", take it
            //otherwise, place an "o" in a corner.
            //second, i'll count the number of x's and o's in the diagnals.  
            //if there is two x's and one "o", then, place an "o" in spot two (any outter middle spot would work
            //lastly, if i've missed some other combination, place an "o" in a corner.  
            //at that point, the win and block will have been checked, then middle spot taken, and a check to block diagnals from a (indirect/ logical way to) win.


            //** impotant ** if foundWinOrBlock == true, we won't look for a move (can't let the AI go twice in a row. that's cheating)
            if (foundWinOrBlock == false)
            {
                //first, if the GridSlot five is has a placedCharacter value of " ", take it
                if (five.placedCharacter == " ")
                {
                    five.placedCharacter = "o";
                    chosenName = five.name;
                }
                //second, i'll count the number of x's and o's in the diagnals.  
                //if there is two x's and one "o", then, place an "o" in spot two (any outter middle spot would work
                else if (one.placedCharacter == "x" && five.placedCharacter == "o" && nine.placedCharacter == "x" ||
                         three.placedCharacter == "x" && five.placedCharacter == "o" && seven.placedCharacter == "x"
                        )
                {
                    two.placedCharacter = "o";
                }
                //lastly, if a corner is free and five is taken, take the a corner
                else
                {
                    GridSlot[] corners = { one, three, seven, nine };
                    foreach (GridSlot gs in corners)
                    {
                        if (gs.placedCharacter == " ")
                        {
                            gs.placedCharacter = "o";
                            chosenName = gs.name;
                            break;
                        }
                    }
                }
            }
            //second, i'll count the number of x's and o's in every row, column, and diagnal.  
            //if there is two x's and one "o", then if a corner is free, place an "o" there. 

            //this is to tell the player which spot the AI chose
            Console.WriteLine("The AI chose {0}", chosenName);
            PrintBoard();
            turn = "x";
        }
        
    }
    public class GridSlot
    {
        public string placedCharacter = " ";
        public string name;
    }

}
