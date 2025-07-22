using PdsTakehome.Models;
using PdsTakehome.Services;


Console.WriteLine("Welcome to Tic Tac Toe!");

TicTacToeGame game = new();
game.StartGame();

game.GetBoardDisplay();