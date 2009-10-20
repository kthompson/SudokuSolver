using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    /// <summary>
    /// Hidden singles have only one place they can go. The extra candidates in the cell "hide" the single solution.
    /// </summary>
    public class HiddenSingle : BaseSolver
    {
        public Dictionary<int, int> Values { get; private set; }
        public List<int> HiddenSingles { get; private set; }

        public HiddenSingle()
        {
            this.Values = new Dictionary<int, int>();
            this.HiddenSingles = new List<int>();
        }

        public override void Visit(Region region)
        {
            this.Values.Clear();
            this.HiddenSingles.Clear();

            foreach (var cell in region)
            {
                if (cell.HasValue)
                {
                    CountValue(cell.Value);
                    continue;
                }

                foreach (var i in cell.Options)
                    CountValue(i);
            }

            foreach (var value in Values)
                if (value.Value == 1)
                    this.HiddenSingles.Add(value.Key);

            base.Visit(region);
        }

        public override void Visit(Cell cell)
        {
            foreach (var single in HiddenSingles)
                if (cell.Options.Contains(single))
                    cell.Value = single;
        }

        private void CountValue(int i)
        {
            if (this.Values.ContainsKey(i))
                this.Values[i]++;
            else
                this.Values.Add(i, 1);
        }
    }
}
