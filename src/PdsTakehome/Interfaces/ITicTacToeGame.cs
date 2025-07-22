namespace PdsTakehome.Interfaces;
public interface ITicTacToeGame
{
    void StartGame();
    void GetPlayerInput();
    void ValidateInput(int input);
    void UpdateBoard(int position);
    bool CheckWinner();
    bool CheckTie();
}