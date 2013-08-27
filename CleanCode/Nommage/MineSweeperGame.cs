using System.Collections.Generic;
using System.Linq;

namespace CleanCode.Nommage
{
    public class MineSweeperGame
    {
        private IList<int[]> theList;

        public MineSweeperGame(IList<int[]> theList)
        {
            this.theList = theList;
        }

        public IList<int[]> GetFgdCells()
        {
            IList<int[]> list1 = new List<int[]>();
            foreach (int[] x in theList)
                if (x[0] == 4)
                    list1.Add(x);
            return list1;
        }

        public void Flg(int id)
        {
            theList[id][0] = 4;
        }
    }
}
