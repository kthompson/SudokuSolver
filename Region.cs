using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public class Region : List<Cell>
    {
        public string Id { get; private set; }
        public RegionType Type { get; private set; }

        public Region(string id, RegionType type)
        {
            this.Id = id;
            this.Type = type;
        }

        public override string ToString()
        {
            return this.Type + this.Id;
        }
    }
}
