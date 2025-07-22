using Xunit;
using PdsTakehome.Services;
using PdsTakehome.Models;
using System;

namespace PdsTakehome.Tests
{
    public class TicTacToeGameTestsTest
    {
        private TicTacToeGame CreateGame()
        {
            var options = GameOptions.Standard();
            var resultDisplay = new ResultDisplay();
            return new TicTacToeGame(options, resultDisplay);
        }

        [Fact]
        public void CheckWinner_ReturnsFalseAtGameStart()
        {
            var game = CreateGame();
            Assert.False(game.CheckWinner());
        }

        [Fact]
        public void CheckTie_ReturnsFalseAtGameStart()
        {
            var game = CreateGame();
            Assert.False(game.CheckTie());
        }

        [Fact]
        public void UpdateBoard_WinningMove_Row_Wins()
        {
            var game = CreateGame();
            game.UpdateBoard(new Position(0, 0));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(1, 0));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(0, 1));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(1, 1));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(0, 2));
            Assert.True(game.CheckWinner());
        }

        [Fact]
        public void UpdateBoard_WinningMove_Column_Wins()
        {
            var game = CreateGame();
            game.UpdateBoard(new Position(0, 0));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(0, 1));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(1, 0));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(1, 1));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(2, 0));
            Assert.True(game.CheckWinner());
        }

        [Fact]
        public void UpdateBoard_WinningMove_Diagonal_Wins()
        {
            var game = CreateGame();
            game.UpdateBoard(new Position(0, 0));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(0, 1));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(1, 1));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(0, 2));
            game.SwitchPlayer();
            game.UpdateBoard(new Position(2, 2));
            Assert.True(game.CheckWinner());
        }

        [Fact]
        public void UpdateBoard_TieGame_CheckTieReturnsTrue()
        {
            var game = CreateGame();
            game.UpdateBoard(new Position(0, 0)); 
            game.SwitchPlayer();
            game.UpdateBoard(new Position(0, 1)); 
            game.SwitchPlayer();
            game.UpdateBoard(new Position(0, 2)); 
            game.SwitchPlayer();

            game.UpdateBoard(new Position(1, 1)); 
            game.SwitchPlayer();
            game.UpdateBoard(new Position(1, 0)); 
            game.SwitchPlayer();
            game.UpdateBoard(new Position(1, 2)); 
            game.SwitchPlayer();

            game.UpdateBoard(new Position(2, 1)); 
            game.SwitchPlayer();
            game.UpdateBoard(new Position(2, 0)); 
            game.SwitchPlayer();
            game.UpdateBoard(new Position(2, 2)); 
            game.GetBoardDisplay();

            Assert.True(game.CheckTie());
        }

        [Fact]
        public void UpdateBoard_OccupiedCell_ThrowsException()
        {
            var game = CreateGame();
            var pos = new Position(0, 0);
            game.UpdateBoard(pos);
            Assert.Throws<ArgumentException>(() => game.ValidateInput("1x1"));
        }

        [Fact]
        public void ValidateInput_InvalidFormat_ThrowsException()
        {
            var game = CreateGame();
            Assert.Throws<ArgumentException>(() => game.ValidateInput("abc"));
            Assert.Throws<ArgumentException>(() => game.ValidateInput("1"));
            Assert.Throws<ArgumentException>(() => game.ValidateInput("1x"));
        }

        [Fact]
        public void ValidateInput_OutOfBounds_ThrowsException()
        {
            var game = CreateGame();
            Assert.Throws<IndexOutOfRangeException>(() => game.ValidateInput("0x1"));
            Assert.Throws<IndexOutOfRangeException>(() => game.ValidateInput("1x0"));
            Assert.Throws<IndexOutOfRangeException>(() => game.ValidateInput("4x1"));
            Assert.Throws<IndexOutOfRangeException>(() => game.ValidateInput("1x4"));
        }

        [Fact]
        public void SwitchPlayer_AlternatesPlayers()
        {
            var game = CreateGame();
            var first = game.GetCurrentPlayer();
            game.SwitchPlayer();
            var second = game.GetCurrentPlayer();
            Assert.NotEqual(first.Symbol, second.Symbol);
        }

        [Fact]
        public void ParseInput_ValidInput_ReturnsCorrectPosition()
        {
            var game = CreateGame();
            var pos = game.ParseInput("2x3");
            Assert.Equal(1, pos.Row);
            Assert.Equal(2, pos.Column);
        }
    }
}
