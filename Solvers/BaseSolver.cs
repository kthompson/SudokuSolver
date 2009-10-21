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

        public IEnumerable<Cell[]> GetCombinations(Region region, int indexCount)
        {
            var indices = new List<int>();
            for (int i = 0; i < indexCount; i++)
                indices.Add(i);

            while (true)
            {
                yield return indices.Select(index => region[index]).ToArray();
                if (!Increment(indices)) break;
            }
        }

        private bool Increment(List<int> indices)
        {
            var i = indices.Count - 1;
            var inc = false;
            while (i >= 0)
            {
                if (indices[i] == 9 - indices.Count + i)
                {
                    i--;
                    inc = true;
                }
                else
                {
                    indices[i]++;
                    if (inc == true)
                    {
                        inc = false;
                        for (int j = i + 1; j < indices.Count; j++)
                        {
                            indices[j] = indices[j - 1] + 1;
                        }
                    }
                    return true;
                }
            }

            return false;
        }
    }
}