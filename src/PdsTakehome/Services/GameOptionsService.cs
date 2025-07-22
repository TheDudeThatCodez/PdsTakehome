using PdsTakehome.Models;

namespace PdsTakehome.Services
{
    public class GameOptionsService
    {
        public GameOptions PromptForOptions()
        {
            Console.WriteLine("Select game type:");
            Console.WriteLine("1) Standard 3x3");
            Console.WriteLine("2) Custom size");
            Console.Write("Choice: ");

            string? choice = Console.ReadLine();
            if (string.IsNullOrEmpty(choice) || (choice != "1" && choice != "2"))
            {
                Console.WriteLine("Invalid choice. Defaulting to Standard 3x3.");
                return GameOptions.Standard();
            }

            return (choice?.Trim() == "2")
                ? GameOptions.Custom(PromptForCustomSize())
                : GameOptions.Standard();
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
    }
}
