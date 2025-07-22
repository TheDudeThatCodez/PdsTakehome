using PdsTakehome.Models;

namespace PdsTakehome.Interfaces
{
    public interface ITicTacToeGame
    {
        void StartGame();
        Position GetPlayerInput();
        void ValidateInput(string input);
        Position ParseInput(string input);
        void UpdateBoard(Position position);
        bool CheckWinner();
        bool CheckTie();
        void GetBoardDisplay();
    }
}