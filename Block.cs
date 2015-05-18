namespace SudokuSolver
{
    public class Block : Region
    {
        public Block()
            : base(string.Empty, RegionType.Block)
        {
        }

        public override string ToString()
        {
            return string.Format("[{0}]", this[0]);
        }
    }
}