using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    /// <summary>
    /// Removed invalid options
    /// </summary>
    public class OptionRemover : BaseSolver
    {
        public List<int> Values { get; private set; }
        public int OptionsRemoved { get; private set; }

        public OptionRemover()
        {
            this.Values = new List<int>();
        }

        public override void Visit(Grid grid)
        {
            int i;
            do
            {
                i = this.OptionsRemoved;
                base.Visit(grid);
                //continue as long as some additional options were removed
            } while (this.OptionsRemoved > i);
        }

        public override void Visit(Region region)
        {
            this.Values.Clear();

            foreach (var cell in region.Where(cell => cell.HasValue && !this.Values.Contains(cell.Value)))
                this.Values.Add(cell.Value);

            base.Visit(region);
        }

        public override void Visit(Cell cell)
        {
            foreach (var value in Values.Where(value => cell.Options.Remove(value)))
                this.OptionsRemoved++;
        }
    }
}
