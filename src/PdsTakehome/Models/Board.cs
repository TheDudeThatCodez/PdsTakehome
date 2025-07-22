namespace PdsTakehome.Models
{
    public class Board
    {
        public char[,] Cells { get; private set; }
        public readonly int Size;

        public Board(int size = 3)
        {
            if (size < 3)
                throw new ArgumentOutOfRangeException(nameof(size), "Board size must be 3 or greater.");
            Size = size;
            Cells = new char[size, size];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cells[i, j] = ' ';
                }
            }
        }

        public void DisplayBoard(int cellPadding = 1)
        {
            string pad = new string(' ', cellPadding);
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(pad + Cells[i, j] + pad);
                    if (j < Size - 1) Console.Write("|");
                }
                Console.WriteLine();
                if (i < Size - 1)
                    Console.WriteLine(new string('-', (Size * (cellPadding * 2 + 1)) + (Size - 1)));
            }
        }
    }
}