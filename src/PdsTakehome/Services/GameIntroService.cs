using System;
using System.Threading;

namespace PdsTakehome.Services
{
    public class GameIntroService
    {
        public void ShowIntro()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine(@"
 _______ _        _______           _______         
|__   __(_)      |__   __|         |__   __|        
   | |   _  ___     | | __ _  ___     | | ___   ___ 
   | |  | |/ __|    | |/ _` |/ __|    | |/ _ \ / _ \
   | |  | | (__     | | (_| | (__     | | (_) |  __/
   |_|  |_|\___|    |_|\__,_|\___|    |_|\___/ \___|
");
            Console.ResetColor();
            ShowLoadingAnimation();
        }

        private void ShowLoadingAnimation()
        {
            Console.Write("\nLoading");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine("\n");
        }
    }
}
