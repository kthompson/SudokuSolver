using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    public class HiddenPairs : BaseSolver
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
                    if (options.Contains(pair.Option1) && options.Contains(pair.Option2)) continue;

                    options.Clear();
                    options.Add(pair.Option1);
                    options.Add(pair.Option2);
                }
            }
        }

        private void AddPair(Cell cell)
        {
            if (cell.Options.Count < 2)
                return;

            for (var i = 0; i < cell.Options.Count - 1; i++)
                for (var j = i + 1; j < cell.Options.Count; j++)
                    AddPair(new Pair(cell.Options[i], cell.Options[j]));
        }

        private void AddPair(Pair pair)
        {
            if (_pairCounts.ContainsKey(pair))
                _pairCounts[pair]++;
            else
                _pairCounts.Add(pair, 1);
        }
    }
}
