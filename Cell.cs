using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public class Cell
    {
        public Cell(Region block, Region row, Region column, int value)
        {
            this.Block = block;
            this.Column = column;
            this.Row = row;
            this.Value = value;
            this.Options = new List<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        }

        public Cell(Region block, Region row, Region col)
            : this(block, row, col, 0)
        {
            
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                Assert.That(_value == 0 || !this.IsLocked);
                _value = value;
                if (_value != 0)
                    this.Options.Clear();

                OnValueChanged();
            }
        }

        public bool HasValue
        {
            get { return _value != 0; }
        }

        public Point Position
        {
            get
            {
                return new Point(this.Row.Id - 1, this.Column.Id - 1);
            }
        }

        public event EventHandler ValueChanged;
        private void OnValueChanged()
        {
            var handler = this.ValueChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public Region Block { get; private set; }
        public Region Column { get; private set; }
        public Region Row { get; private set; }

        public event EventHandler Locked;
        private void OnLocked()
        {
            var handler = this.Locked;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private bool _isLocked;
        public bool IsLocked
        {
            get { return _isLocked; }
            set
            {
                _isLocked = value;
                if (_isLocked)
                    OnLocked();
            }
        }

        public List<int> Options { get; private set; }

        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}]: {3}", this.Row.Id, this.Column.Id, this.Block.Id, this.Value);
        }
    }
}
