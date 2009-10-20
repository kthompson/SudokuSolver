using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    public class NakedSingle : BaseSolver
    {
        public override void Visit(Grid grid)
        {
            grid.Cells.ForEach(Visit);
        }

        public override void Visit(Cell cell)
        {
            if (cell.Options.Count == 1)
                cell.Value = cell.Options[0];
        }
    }
}