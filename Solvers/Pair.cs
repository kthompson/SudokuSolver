using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    struct Pair
    {
        public int Option1;
        public int Option2;

        public Pair(int option1, int option2)
        {
            if (option1 > option2)
            {
                this.Option1 = option2;
                this.Option2 = option1;
            }
            else
            {
                this.Option1 = option1;
                this.Option2 = option2;
            }
        }
    }
}
