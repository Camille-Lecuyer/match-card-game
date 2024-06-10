using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace match_src
{
    public class InputManagement
    {
        public int numberOfDecks { get; set; }
        public int selectedMatchCondition { get; set; }

        Dictionary<int, string> matchConditionPair = new Dictionary<int, string>();

        public InputManagement()
        {
            matchConditionPair.Add(1, "Suit");
            matchConditionPair.Add(2, "Value");
            matchConditionPair.Add(3, "Suit and Value");
        }

        public void AskInput()
        {
            numberOfDecks = askDeckNumber();
            selectedMatchCondition = matchCondition();
            Console.WriteLine("The game will now start!");
            Console.WriteLine($"It will contain {numberOfDecks} deck(s) and use the {matchConditionPair[selectedMatchCondition]} match condition!");
        }

        int askDeckNumber()
        {
            int numberOfDecks = 0;
            string confirmDeckNumber = "";
            while (confirmDeckNumber != "yes") { 
                Console.WriteLine("How many decks would you like for the game?");
                try
                {
                    numberOfDecks = Convert.ToInt32(Console.ReadLine());
                    if (numberOfDecks < 1 || numberOfDecks > 100) {
                        Console.WriteLine("Please choose a number between 1 and 100");
                        continue;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number");
                }

                Console.WriteLine($"The game will contain {numberOfDecks} decks of cards, is this correct?");
                confirmDeckNumber = Console.ReadLine()?.ToLower() ?? string.Empty;
            }
            return numberOfDecks;
        }

        int matchCondition()
        {
            int input = 0;
            string confirmMatchCondition = "";
            string availableSelection = numberOfDecks > 1 ? "1, 2 or 3" : "1 or 2";
            
            while (confirmMatchCondition != "yes")
            {
                Console.WriteLine("Which match condition would you like?");
                Console.WriteLine("Type 1 for Suit matching (ex: 3 of hearts and 5 of hearts match)");
                Console.WriteLine("Type 2 for Value matching (ex: 3 of hearts and 3 of clubs match)");

                if (numberOfDecks > 1)
                {
                    Console.WriteLine("Type 3 for Suit AND Value matching (ex: only 3 of hearts and 3 of hearts match)");

                }
                Console.WriteLine($"Please enter {availableSelection}");


                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if((numberOfDecks > 1 && input != 1 && input != 2 && input != 3) || (numberOfDecks == 1 && input != 1 && input != 2))
                    {
                        Console.WriteLine($"Please enter {availableSelection}");
                        continue;
                    }

                }
                catch (Exception) {
                    Console.WriteLine("Please enter a number");              
                }

                Console.WriteLine($"The game will use the {matchConditionPair[input]} match condition, is this correct?");
                confirmMatchCondition = Console.ReadLine()?.ToLower() ?? string.Empty;
            }
            Console.WriteLine(confirmMatchCondition);
            return input;
        }

        public bool PlayAgain()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Want to play again? type 'yes' to do so");
            string playAgainChoice = Console.ReadLine()?.ToLower() ?? string.Empty;
            return playAgainChoice.ToLower() == "yes";
        }

    }
}
