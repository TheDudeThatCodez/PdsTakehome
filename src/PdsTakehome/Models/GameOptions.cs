namespace PdsTakehome.Models
{
    public sealed class GameOptions
    {
        public GameType Mode { get; }
        public int Size { get; }   

        private GameOptions(GameType mode, int size)
        {
            Mode = mode;
            Size = size;
        }

        public static GameOptions Standard() => new(GameType.Standard, 3);

        public static GameOptions Custom(int size)
        {
            if (size < 3)
                throw new ArgumentOutOfRangeException(nameof(size), "Custom board size must be 3 or greater.");
            return new(GameType.Custom, size);
        }

        public bool IsStandard => Mode == GameType.Standard;
    }
}
