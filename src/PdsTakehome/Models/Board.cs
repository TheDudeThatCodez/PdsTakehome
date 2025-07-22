namespace PdsTakehome.Models
{
    public class Board
    {
        public char[,] Cells { get; private set; }

        public Board()
        {
            Cells = new char[3, 3];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Cells[i, j] = ' ';
                }
            }
        }

        public void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    System.Console.Write(Cells[i, j]);
                    if (j < 2) System.Console.Write("|");
                }
                System.Console.WriteLine();
                if (i < 2) System.Console.WriteLine("-----");
            }
        }
    }
}