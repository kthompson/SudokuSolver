using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public static class Extensions
    {
        public static void Times(this int value, Action action)
        {
            for (var i = 0; i < value; i++)
                action();
        }

        public static void Times(this int value, Action<int> action)
        {
            for (var i = 1; i <= value; i++)
                action(i);
        }
    }
}
