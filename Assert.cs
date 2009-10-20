using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public static class Assert
    {
        [DebuggerHidden]
        public static void That(bool condition)
        {
            if (!condition)
                Break();
        }

        [DebuggerHidden]
        public static void Break()
        {
            if (Debugger.IsAttached)
                Debugger.Break();

            throw new ApplicationException();
        }
    }
}
