using PdsTakehome.Services;
using PdsTakehome.Models;


var gameOptionsService = new GameOptionsService();
GameOptions options = gameOptionsService.PromptForOptions();

TicTacToeGame game = new(options);
game.StartGame();