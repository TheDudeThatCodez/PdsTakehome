using PdsTakehome.Services;
using PdsTakehome.Models;

var gameIntroService = new GameIntroService();
var gameOptionsService = new GameOptionsService();

gameIntroService.ShowIntro();

bool playAgain = true;
while (playAgain)
{
    GameOptions options = gameOptionsService.PromptForOptions();
    TicTacToeGame game = new(options, new ResultDisplay());

    game.StartGame();

    playAgain = gameOptionsService.AskToPlayAgain();
}

Console.WriteLine("Thank you for playing! Goodbye!");
