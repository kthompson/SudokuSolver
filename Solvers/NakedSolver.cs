using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    public class NakedSolver : BaseSolver
    {
        public int Count { get; private set; }

        public NakedSolver(int count)
        {
            this.Count = count;
        }

        public override void Visit(Region region)
        {
            foreach (var cells in GetCombinations(region, this.Count))
            {
                if (cells.Any(cell => cell.HasValue))
                    continue;

                var options = cells.SelectMany(c => c.Options).Distinct().ToList();
                if (options.Count() != this.Count)
                    continue;
              
                foreach (var item in region)
                {
                    if (item.HasValue || cells.Contains(item))
                        continue;

                    foreach (var option in options)
                    {
                        if (item.Options.Contains(option))
                        {
                            item.Options.Remove(option);
                        }
                    }
                }
            }
            //base.Visit(region);
            //basically we need to try every cell with every other cell until we have an equal number of options and cells
        }
    }
}
