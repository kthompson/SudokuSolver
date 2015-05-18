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

        private readonly Dictionary<string, TextBox> _textBoxes = new Dictionary<string, TextBox>();

        public Sudoku()
        {
            InitializeComponent();

            var temp = "120 600 040\n" +
                       "700 000 009\n" +
                       "000 008 600\n" +

                       "000 030 050\n" +
                       "005 186 300\n" +
                       "010 020 000\n" +

                       "007 500 000\n" +
                       "500 000 004\n" +
                       "030 004 087\n";


            temp = "573 006 019\n" +
                   "002 010 306\n" +
                   "100 000 000\n" +

                   "000 967 050\n" +
                   "200 030 007\n" +
                   "060 524 000\n" +

                   "000 000 001\n" +
                   "708 040 600\n" +
                   "630 800 742\n";

            _grid = new Grid();

            foreach (var cell in _grid.Cells)
            {
                cell.ValueChanged += OnCellValueChanged;
                cell.Locked += OnCellLocked;
            }

            for (var x = 0; x < 9; x++)
                for (var y = 0; y < 9; y++)
                    CreateTextBox(x, y);

            this.chkEntryMode.Checked = false;
            _grid.Apply(temp);
            
        }



        private void OnCellValueChanged(object sender, EventArgs e)
        {
            var cell = sender as Cell;
            if (cell == null)
                return;

            var pos = cell.Id;
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

            var pos = cell.Id;
            var tb = _textBoxes[pos];

            if (cell.IsLocked)
                tb.ForeColor = Color.Black;
        }

        static readonly char[] rowIds = new[] { 'A', 'B', 'C', 
                                             'D', 'E', 'F',
                                             'G', 'H', 'I'};

        private void CreateTextBox(int x, int y)
        {
            var w = 24;
            var h = 20;
            var pad = 6;
            var index = x + y * 9;
            var bx = x/3;
            var by = y/3;
            var textBox = new TextBox();
            textBox.Click += textBox_Click;
            textBox.ForeColor = Color.Green;
            textBox.Location = new Point(12 + (w + pad) * x + bx * pad * 2,
                                         12 + (h + pad) * y + by * pad * 2);

            textBox.Name = "textBox"+index;
            textBox.Size = new Size(w, h);
            textBox.TabIndex = index+3;
            textBox.Tag = index;
            textBox.TextAlign = HorizontalAlignment.Center;
            textBox.TextChanged += textBox_TextChanged;

            this._textBoxes.Add(rowIds[x] + (y+1).ToString(), textBox);

            this.Controls.Add(textBox);
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null)
                return;

            var index = (int)tb.Tag;
            toolTip1.SetToolTip(tb, _grid.Cells[index].ToString());
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
            _grid.Accept(new NakedSolver(2));
            _grid.Accept(new HiddenPairs());
            _grid.Accept(new NakedSolver(3));
            _grid.Accept(new NakedSolver(4));
            _grid.Accept(new NakedSolver(5));
            _grid.Accept(new NakedSolver(6));
            _grid.Accept(new NakedSolver(7));
            _grid.Accept(new NakedSolver(8));
        }
    }
}
