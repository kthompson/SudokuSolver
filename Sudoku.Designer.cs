namespace SudokuSolver
{
    partial class Sudoku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSolve = new System.Windows.Forms.Button();
            this.chkEntryMode = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(492, 12);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 0;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // chkEntryMode
            // 
            this.chkEntryMode.AutoSize = true;
            this.chkEntryMode.Checked = true;
            this.chkEntryMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEntryMode.Location = new System.Drawing.Point(487, 41);
            this.chkEntryMode.Name = "chkEntryMode";
            this.chkEntryMode.Size = new System.Drawing.Size(84, 17);
            this.chkEntryMode.TabIndex = 1;
            this.chkEntryMode.Text = "Puzzle Entry";
            this.chkEntryMode.UseVisualStyleBackColor = true;
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 376);
            this.Controls.Add(this.chkEntryMode);
            this.Controls.Add(this.btnSolve);
            this.Name = "Sudoku";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.CheckBox chkEntryMode;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

