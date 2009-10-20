using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    public interface ISolver
    {
        void Visit(Grid grid);
        void Visit(List<Region> regions);
        void Visit(Region region);
        void Visit(Cell cell);
    }
}