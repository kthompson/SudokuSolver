using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    public class NakedPairs : BaseSolver
    {
        private Dictionary<Pair, int> _pairCounts = new Dictionary<Pair, int>();

        public override void Visit(Region region)
        {
            _pairCounts.Clear();
            region.ForEach(AddPair);

            var pairs = from kv in _pairCounts
                        where kv.Value == 2
                        select kv.Key;

            foreach (var pair in pairs)
            {
                foreach (var cell in region)
                {
                    var options = cell.Options;
                    if (options.Count == 0) continue;
                    if (options.Count == 2 && options.Contains(pair.Option1) && options.Contains(pair.Option2)) continue;

                    options.Remove(pair.Option1);
                    options.Remove(pair.Option2);
                }
            }
        }


        private void AddPair(Cell cell)
        {
            if (cell.Options.Count != 2)
                return;

            var pair = new Pair(cell.Options[0], cell.Options[1]);
            if (_pairCounts.ContainsKey(pair))
                _pairCounts[pair]++;
            else
                _pairCounts.Add(pair, 1);
        }
    }
}
