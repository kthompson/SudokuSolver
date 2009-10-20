using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SudokuSolver.Solvers;

namespace SudokuSolver
{
    public partial class Sudoku : Form
    {
        private Grid _grid;

        private Dictionary<Point, TextBox> _textBoxes;

        public Sudoku()
        {
            InitializeComponent();
            _textBoxes = new Dictionary<Point, TextBox>();

            //var test = new[]
            //               {
            //                   new[]{1,5,0, 0,0,9, 3,0,0},
            //                   new[]{6,3,0, 0,0,0, 5,0,1},
            //                   new[]{7,0,0, 0,1,0, 0,6,0},

            //                   new[]{9,7,0, 0,0,6, 0,0,0},
            //                   new[]{0,0,4, 0,0,0, 2,0,0},
            //                   new[]{0,0,0, 1,0,0, 0,3,9},

            //                   new[]{0,2,0, 0,4,0, 0,0,6},
            //                   new[]{8,0,7, 0,0,0, 0,5,3},
            //                   new[]{0,0,6, 9,0,0, 0,8,2},

            //               };

            _grid = new Grid();

            foreach (var cell in _grid.Cells)
            {
                cell.ValueChanged += OnCellValueChanged;
                cell.Locked += OnCellLocked;
            }

            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                    CreateTextBox(x, y);

            //_grid.Apply(test);
            
        }

        private TextBox GetTextBox(int x, int y)
        {
            var name = "txt" + x.ToString() + y.ToString();

            var textBoxes = this.Controls.Find(name, false);
            if (textBoxes.Length == 0)
                return null;

            return textBoxes[0] as TextBox;
        }

        private void OnCellValueChanged(object sender, EventArgs e)
        {
            var cell = sender as Cell;
            if (cell == null)
                return;

            var pos = cell.Position;
            var tb = _textBoxes[pos];

            if (tb.Text != string.Empty)
                return;

            tb.Text = cell.Value.ToString();
        }

        private void OnCellLocked(object sender, EventArgs e)
        {
            var cell = sender as Cell;
            if (cell == null)
                return;

            var pos = cell.Position;
            var tb = _textBoxes[pos];

            if (cell.IsLocked)
                tb.ForeColor = Color.Black;
        }

        private void CreateTextBox(int x, int y)
        {
            var w = 24;
            var h = 20;
            var pad = 6;
            var index = x + y * 9;
            var bx = x/3;
            var by = y/3;
            var textBox = new TextBox();

            textBox.ForeColor = Color.Green;
            textBox.Location = new Point(12 + (w + pad) * x + bx * pad * 2,
                                         12 + (h + pad) * y + by * pad * 2);

            textBox.Name = "textBox"+index;
            textBox.Size = new Size(w, h);
            textBox.TabIndex = index+3;
            textBox.Tag = index;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.TextChanged += textBox_TextChanged;

            this._textBoxes.Add(new Point(x, y), textBox);

            this.Controls.Add(textBox);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if(tb == null)
                return;

            var index = (int)tb.Tag;
            _grid.Cells[index].IsLocked = this.chkEntryMode.Checked;
            _grid.Cells[index].Value = int.Parse(tb.Text);
            _grid.Accept(new OptionRemover());
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            this.chkEntryMode.Checked = false;

            _grid.Accept(new OptionRemover());
            _grid.Accept(new NakedSingle());
            _grid.Accept(new HiddenSingle());
            _grid.Accept(new NakedPairs());
            _grid.Accept(new HiddenPairs());
        }
    }
}
