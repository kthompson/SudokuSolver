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

        public IEnumerable<List<Cell>> GetCombinations(Region region, int indexCount)
        {
            return GetCombinations(indexCount, 9)
                .Select(@group => @group
                    .Select(index => region[index])
                    .ToList());
        }

        public IEnumerable<List<int>> GetCombinations(int indexCount, int maxCount)
        {
            var indices = new List<int>();
            for (var i = 0; i < indexCount; i++)
                indices.Add(i);

            while (true)
            {
                yield return indices.ToList();

                if (!Increment(indices, maxCount)) 
                    break;
            }
        }

        private bool Increment(IList<int> indices, int maxValue = 9)
        {
            var i = indices.Count - 1;
            var inc = false;
            while (i >= 0)
            {
                if (indices[i] == maxValue - indices.Count + i)
                {
                    i--;
                    inc = true;
                }
                else
                {
                    indices[i]++;
                    
                    if (!inc) 
                        return true;

                    for (var j = i + 1; j < indices.Count; j++)
                    {
                        indices[j] = indices[j - 1] + 1;
                    }
                    
                    return true;
                }
            }

            return false;
        }
    }
}