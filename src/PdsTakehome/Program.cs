/*
 * Program.cs
 * 
 * Entry point for the PdsTakehome Tic-Tac-Toe game application.
 * 
 * This program initializes the game introduction and options services,
 * prompts the user for game options, and manages the main game loop,
 * allowing the user to play multiple rounds of Tic-Tac-Toe.
 * 
 * Author: Spencer Neveux
 * Repository: https://github.com/TheDudeThatCodez/PdsTakehome
 * 
 */

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
