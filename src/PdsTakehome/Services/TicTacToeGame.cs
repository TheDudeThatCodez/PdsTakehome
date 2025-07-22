using PdsTakehome.Models;
using PdsTakehome.Interfaces;

namespace PdsTakehome.Services;

public class TicTacToeGame : ITicTacToeGame
{
    private readonly Board board;
    private Player currentPlayer;
    private readonly Player playerX;
    private readonly Player playerO;

    public TicTacToeGame()
    {
        board = new Board();
        playerX = new Player("Player X", 'X');
        playerO = new Player("Player O", 'O');
        currentPlayer = playerX;
    }

    public void StartGame()
    {
        while (true)
        {
            Console.Clear();
            GetBoardDisplay();
            Console.WriteLine($"\n{currentPlayer.Name}'s turn ({currentPlayer.Symbol}). Enter a position (row x col):");

            try
            {
                Position position = GetPlayerInput();
                UpdateBoard(position);
                
                if (CheckWinner())
                {
                    Console.Clear();
                    GetBoardDisplay();
                    Console.WriteLine($"\n{currentPlayer.Name} wins!");
                    Console.WriteLine("Press Enter to exit...");
                    Console.ReadLine();
                    break;
                }
                
                if (CheckTie())
                {
                    Console.Clear();
                    GetBoardDisplay();
                    Console.WriteLine("\nIt's a tie!");
                    Console.WriteLine("Press Enter to exit...");
                    Console.ReadLine();
                    break;
                }

                SwitchPlayer();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press Enter to try again...");
                Console.ReadLine();
            }
        }
    }

    public Position GetPlayerInput()
    {
        var input = Console.ReadLine();
        if (input == null)
            throw new ArgumentNullException(nameof(input), "Input cannot be null.");

        ValidateInput(input);
        Position position = ParseInput(input);
        return position;
    }

    public void ValidateInput(string input)
    {
        // Clean input to handle cases like "1x1", "1 X 1", etc.
        var cleanedInput = input.Split([' ', 'x', 'X'], StringSplitOptions.RemoveEmptyEntries);
        if (cleanedInput.Length < 2 || cleanedInput.Length > 2)
        {
            throw new ArgumentException("Invalid input format. Please enter in the format 'row x col'.");
        }

        var row = int.Parse(cleanedInput[0]) - 1;
        var col = int.Parse(cleanedInput[1]) - 1;
        if (row < 0 || row > board.Size || col < 0 || col > board.Size)
        {
            throw new ArgumentException("Invalid position. Please enter a valid row and column.");
        }
    }

    public Position ParseInput(string input) 
    {
        var cleanedInput = input.Split([' ', 'x', 'X'], StringSplitOptions.RemoveEmptyEntries);
        var row = cleanedInput.Length > 0 ? int.Parse(cleanedInput[0]) - 1 : -1;
        var col = cleanedInput.Length > 1 ? int.Parse(cleanedInput[1]) - 1 : -1;
        return new Position(row, col);
    }

    public void UpdateBoard(Position position)
    {
        board.Cells[position.Row, position.Column] = currentPlayer.Symbol;
    }

    public bool CheckWinner()
    {
        char s = currentPlayer.Symbol;
        var c = board.Cells;
        int size = board.Size;

        // Check rows
        for (int i = 0; i < size; i++)
        {
            bool rowWin = true;
            for (int j = 0; j < size; j++)
            {
                if (c[i, j] != s)
                {
                    rowWin = false;
                    break;
                }
            }
            if (rowWin) return true;
        }

        // Check columns
        for (int j = 0; j < size; j++)
        {
            bool colWin = true;
            for (int i = 0; i < size; i++)
            {
                if (c[i, j] != s)
                {
                    colWin = false;
                    break;
                }
            }
            if (colWin) return true;
        }

        // Check main diagonal
        bool mainDiagWin = true;
        for (int i = 0; i < size; i++)
        {
            if (c[i, i] != s)
            {
                mainDiagWin = false;
                break;
            }
        }
        if (mainDiagWin) return true;

        // Check anti-diagonal
        bool antiDiagWin = true;
        for (int i = 0; i < size; i++)
        {
            if (c[i, size - 1 - i] != s)
            {
                antiDiagWin = false;
                break;
            }
        }
        if (antiDiagWin) return true;

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

    public void GetBoardDisplay()
    {
        board.DisplayBoard();
    }

    public Player GetCurrentPlayer()
    {
        return currentPlayer;
    }
}