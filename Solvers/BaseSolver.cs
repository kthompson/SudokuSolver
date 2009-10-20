using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    //http://www.sudokuessentials.com/sudoku_tips.html
    public abstract class BaseSolver : ISolver
    {
        #region ISolver Members

        public virtual void Visit(Grid grid)
        {
            this.Visit(grid.Blocks);
            this.Visit(grid.Rows);
            this.Visit(grid.Columns);
        }

        public virtual void Visit(List<Region> regions)
        {
            foreach (var region in regions)
                this.Visit(region);
        }

        public virtual void Visit(Region region)
        {
            foreach (var cell in region)
                this.Visit(cell);    
        }

        public virtual void Visit(Cell cell)
        {
        }

        #endregion
    }
}