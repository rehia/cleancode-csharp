using System.Collections.Generic;
using System.Linq;

namespace CleanCode.Nommage
{
    public class MineSweeperGame
    {
        private IList<int[]> gameBoard;
        private static readonly int CellStatus = 0;
        private static readonly int Flagged = 4;

        public MineSweeperGame(IList<int[]> gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public IList<int[]> GetFlaggedCells()
        {
            IList<int[]> flaggedCells = new List<int[]>();
            foreach (int[] cell in gameBoard)
                if (cell[CellStatus] == Flagged)
                    flaggedCells.Add(cell);
            return flaggedCells;
        }

        public void FlagCell(int id)
        {
            gameBoard[id][CellStatus] = Flagged;
        }
    }
}
