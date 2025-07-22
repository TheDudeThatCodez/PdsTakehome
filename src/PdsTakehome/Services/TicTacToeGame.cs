using PdsTakehome.Models;
using PdsTakehome.Interfaces;

public class TicTacToeGame : ITicTacToeGame
{
    private Board board;
    private Player currentPlayer;
    private Player playerX;
    private Player playerO;

    public TicTacToeGame()
    {
        board = new Board();
        playerX = new Player("Player X", 'X');
        playerO = new Player("Player O", 'O');
        currentPlayer = playerX;
    }

    public void StartGame()
    {
        board = new Board();
        currentPlayer = playerX;
    }

    public void GetPlayerInput()
    {
        // This method would typically get input from the user interface.
        // For now, it's a placeholder.
    }

    public void ValidateInput(int input)
    {
        // Input should be between 1 and 9 and the cell should be empty
        if (input < 1 || input > 9)
            throw new ArgumentOutOfRangeException("Input must be between 1 and 9.");

        int row = (input - 1) / 3;
        int col = (input - 1) % 3;
        if (board.Cells[row, col] != ' ')
            throw new InvalidOperationException("Cell is already occupied.");
    }

    public void UpdateBoard(int position)
    {
        int row = (position - 1) / 3;
        int col = (position - 1) % 3;
        board.Cells[row, col] = currentPlayer.Symbol;
    }

    public bool CheckWinner()
    {
        char s = currentPlayer.Symbol;
        var c = board.Cells;

        // Check rows and columns
        for (int i = 0; i < 3; i++)
        {
            if ((c[i, 0] == s && c[i, 1] == s && c[i, 2] == s) ||
                (c[0, i] == s && c[1, i] == s && c[2, i] == s))
                return true;
        }
        // Check diagonals
        if ((c[0, 0] == s && c[1, 1] == s && c[2, 2] == s) ||
            (c[0, 2] == s && c[1, 1] == s && c[2, 0] == s))
            return true;

        return false;
    }

    public bool CheckTie()
    {
        foreach (var cell in board.Cells)
        {
            if (cell == ' ')
                return false;
        }
        return !CheckWinner();
    }

    public void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == playerX) ? playerO : playerX;
    }

    public void DisplayBoard()
    {
        board.DisplayBoard();
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }
}