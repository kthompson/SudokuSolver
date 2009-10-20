using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public class Region : List<Cell>
    {
        public int Id { get; private set; }
        public RegionType Type { get; private set; }

        public Region(int id, RegionType type)
        {
            this.Id = id;
            this.Type = type;
        }

        public override string ToString()
        {
            return this.Type.ToString() + this.Id;
        }
    }

    public enum RegionType
    {
        Block, 
        Column,
        Row
    }
}
