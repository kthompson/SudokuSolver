using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver.Solvers
{
    struct Triple
    {
        public int Option1;
        public int Option2;
        public int Option3;

        public Triple(int option1, int option2, int option3)
        {
            var array = new[] {option1, option2, option3};

            array = array.OrderBy(x => x).ToArray();

            this.Option1 = array[0];
            this.Option2 = array[1];
            this.Option3 = array[2];
            
        }
    }
}
