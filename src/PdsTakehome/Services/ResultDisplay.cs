using PdsTakehome.Interfaces;

namespace PdsTakehome.Services
{
    public class ResultDisplay : IResultDisplay
    {
        public void DisplayWinner(string winnerName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{winnerName} wins the game!\n");
            Console.ResetColor();
        }

        public void DisplayTie()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThe game is a tie!\n");
            Console.ResetColor();
        }
    }
}