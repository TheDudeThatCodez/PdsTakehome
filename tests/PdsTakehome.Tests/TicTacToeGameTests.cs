using Xunit;
using PdsTakehome.Services;

namespace PdsTakehome.Tests
{
    public class TicTacToeGameTests
    {
        private readonly TicTacToeGame _game;

        public TicTacToeGameTests()
        {
            _game = new TicTacToeGame();
            _game.StartGame();  
        }

        [Fact]
        public void StartGame_InitializesBoard()
        {
        }

        [Fact]
        public void MakeValidMove_UpdatesBoard()
        {

        }

        [Fact]
        public void CheckWinner_ReturnsFalseAtGameStart()
        {
            bool hasWinner = _game.CheckWinner();
            Assert.False(hasWinner);
        }

        [Fact]
        public void CheckTie_ReturnsFalseAtGameStart()
        {
            bool isTie = _game.CheckTie();
            Assert.False(isTie);
        }

    }
}
