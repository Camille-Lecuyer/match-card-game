using System.Reflection.Metadata;
using match_src;

namespace match
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("MATCH GAME!");
            InputManagement inputManagement = new InputManagement();
            inputManagement.AskInput();

            Game game = new Game(inputManagement.numberOfDecks, inputManagement.selectedMatchCondition);
            game.StartGame();
            while (inputManagement.PlayAgain()) 
            {
                inputManagement.AskInput();
                game = new Game(inputManagement.numberOfDecks, inputManagement.selectedMatchCondition);
                game.StartGame();
            }
        }
    }
}
