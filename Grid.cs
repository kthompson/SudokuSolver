using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SudokuSolver.Solvers;

namespace SudokuSolver
{
    public class Grid
    {
        public List<Region> Blocks { get; private set; }
        public List<Region> Rows { get; private set; }
        public List<Region> Columns { get; private set; }

        public List<Cell> Cells { get; private set; }

        public Grid()
        {
            this.Blocks = new List<Region>();
            this.Columns = new List<Region>();
            this.Rows = new List<Region>();

            this.Cells = new List<Cell>();

            9.Times(i => this.Blocks.Add(new Region(i, RegionType.Block)));
            9.Times(i => this.Rows.Add(new Region(i, RegionType.Row)));
            9.Times(i => this.Columns.Add(new Region(i, RegionType.Column)));

            for (var y = 0; y < 9; y++)
            {
                var by = y/3;
                for (var x = 0; x < 9; x++)
                {
                    var bx = x/3;

                    var bindex = (bx) + 3*(by);

                    var block = this.Blocks[bindex];
                    var row = this.Rows[x];
                    var column = this.Columns[y];
                    var cell = new Cell(block, row, column);
                    block.Add(cell);
                    row.Add(cell);
                    column.Add(cell);

                    Cells.Add(cell);
                }
            }
        }

        public void Apply(int[][] grid)
        {
            Apply(grid, true);
        }

        public void Apply(int[][] grid, bool lockCell)
        {
            for (var x = 0; x < 9; x++)
            {
                for (var y = 0; y < 9; y++)
                {
                    if (grid[x][y] == 0) continue;

                    this.Rows[y][x].IsLocked = lockCell;
                    this.Rows[y][x].Value = grid[x][y];
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return this.Cells[x + y*9];
        }

        public void Accept(ISolver solver)
        {
            solver.Visit(this);
        }
    }
}
