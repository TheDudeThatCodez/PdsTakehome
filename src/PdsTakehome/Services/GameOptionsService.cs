using PdsTakehome.Models;
using PdsTakehome.Interfaces;

namespace PdsTakehome.Services
{
    public class GameOptionsService : IGameOptions 
    {

        public GameOptions PromptForOptions()
        {
            while (true)
            {
                Console.WriteLine("Select game type:");
                Console.WriteLine("1) Standard 3x3");
                Console.WriteLine("2) Custom size");
                Console.Write("Choice: ");

                string? choice = Console.ReadLine();
                if (choice == "1")
                {
                    return GameOptions.Standard();
                }
                else if (choice == "2")
                {
                    return GameOptions.Custom(PromptForCustomSize());
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.\n");
                }
            }
        }

        private int PromptForCustomSize()
        {
            while (true)
            {
                Console.Write("Enter board size (>=3): ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int size) && size >= 3)
                    return size;

                Console.WriteLine("Invalid size. Try again.");
            }
        }
        public bool AskToPlayAgain()
        {
            Console.Write("Do you want to play again? (y/n): ");
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input. Defaulting to 'no'.");
                return false;
            }

            return input == "y" || input == "yes";
        }
    }
}
