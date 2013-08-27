using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanCode.Nommage;
using NUnit.Framework;

namespace CleanCode.Tests
{
    [TestFixture]
    public class MineSweeperGameTests
    {
        private MineSweeperGame _mineSweeper;

        [SetUp]
        public void SetUp()
        {
            var gameBoard = InitializeGameBoard();
            _mineSweeper = new MineSweeperGame(gameBoard);
        }

        [Test]
        public void ShouldGetNoFlaggedCell()
        {
            var flaggedCells = _mineSweeper.GetFgdCells();

            Assert.That(flaggedCells, Is.Empty);
        }

        [Test]
        public void ShouldGetSomeFlaggedCells()
        {
            _mineSweeper.Flg(1);
            _mineSweeper.Flg(7);
            _mineSweeper.Flg(9);

            var flaggedCells = _mineSweeper.GetFgdCells();

            Assert.That(flaggedCells.Count, Is.EqualTo(3));
        }

        private static IList<int[]> InitializeGameBoard()
        {
            return new List<int[]>
                       {
                           new[]{ 1, 6, 5 },
                           new[]{ 3, 2, 1 },
                           new[]{ 1, 3, 1 },
                           new[]{ 3, 7, 4 },
                           new[]{ 1, 4, 5 },
                           new[]{ 3, 1, 6 },
                           new[]{ 1, 5, 3 },
                           new[]{ 1, 6, 2 },
                           new[]{ 1, 2, 7 },
                           new[]{ 1, 7, 6 },
                       };
        }
    }
}
