using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    public class HiddenPairs : BaseSolver
    {
        private readonly Dictionary<int, int> _optionCounts = new Dictionary<int, int>();

        public int Count { get; private set; }

        public HiddenPairs()
        {
            this.Count = 2;
        }

        public override void Visit(Region region)
        {
            _optionCounts.Clear();
            region.ForEach(AddOptions);

            var options = _optionCounts.Where(kv => kv.Value <= this.Count).Select(kv => kv.Key).ToList();

            if (options.Count < this.Count)
                return;
            //get two options
            foreach (var combo in GetCombinations(this.Count, options.Count))
            {
                var comboOptions = combo.Select(index => options[index]).ToList();
                foreach (var cell in GetUnsolvedCellsFromCellSets(region, comboOptions))
                {
                    for (var i = 0; i < cell.Options.Count; i++)
                    {
                        if (comboOptions.Contains(cell.Options[i])) 
                            continue;

                        cell.Options.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        private IEnumerable<Cell> GetUnsolvedCellsFromCellSets(Region region, List<int> comboOptions)
        {
            return from cellSet in GetCombinations(region, this.Count)
                   where !cellSet.Any(cell => cell.HasValue)
                   where comboOptions.All(option => cellSet.All(cell => cell.Options.Contains(option)))
                   from cell in cellSet 
                   select cell;
        }

        private void AddOptions(Cell cell)
        {
            if (cell.HasValue)
                return;

            foreach (var option in cell.Options)
            {
                if (_optionCounts.ContainsKey(option))
                    _optionCounts[option]++;
                else
                    _optionCounts.Add(option, 1);
            }
        }
    }
}
