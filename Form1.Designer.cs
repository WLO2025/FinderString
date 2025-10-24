namespace FinderString
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonContraction;
        private System.Windows.Forms.Button buttonUnification;

        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.CheckedListBox checkedListBoxExtensions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.buttonContraction = new System.Windows.Forms.Button();
            this.buttonUnification = new System.Windows.Forms.Button();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            this.checkedListBoxExtensions = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxExtensions.Location = new System.Drawing.Point(340, 30);
            this.checkedListBoxExtensions.Size = new System.Drawing.Size(100, 150);
            this.Controls.Add(this.checkedListBoxExtensions);


            // textBoxInput
            this.textBoxInput.Location = new System.Drawing.Point(30, 30);
            this.textBoxInput.Size = new System.Drawing.Size(300, 20);

            // textBoxOutput
            this.textBoxOutput.Location = new System.Drawing.Point(30, 60);
            this.textBoxOutput.Size = new System.Drawing.Size(300, 20);

            // buttonContraction
            this.buttonContraction.Location = new System.Drawing.Point(30, 100);
            this.buttonContraction.Size = new System.Drawing.Size(140, 30);
            this.buttonContraction.Text = "Contraction";
            this.buttonContraction.Click += new System.EventHandler(this.buttonContraction_Click);

            // buttonUnification
            this.buttonUnification.Location = new System.Drawing.Point(190, 100);
            this.buttonUnification.Size = new System.Drawing.Size(140, 30);
            this.buttonUnification.Text = "Unification";
            this.buttonUnification.Click += new System.EventHandler(this.buttonUnification_Click);

            // textBoxFolder
            this.textBoxFolder.Location = new System.Drawing.Point(30, 150);
            this.textBoxFolder.Size = new System.Drawing.Size(240, 20);

            // buttonBrowse
            this.buttonBrowse.Location = new System.Drawing.Point(280, 150);
            this.buttonBrowse.Size = new System.Drawing.Size(50, 20);
            this.buttonBrowse.Text = "...";
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);

            // textBoxKeyword
            this.textBoxKeyword.Location = new System.Drawing.Point(30, 180);
            this.textBoxKeyword.Size = new System.Drawing.Size(300, 20);

            // buttonSearch
            this.buttonSearch.Location = new System.Drawing.Point(30, 210);
            this.buttonSearch.Size = new System.Drawing.Size(300, 30);
            this.buttonSearch.Text = "Search Keyword";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            // listBoxResults
            this.listBoxResults.Location = new System.Drawing.Point(30, 250);
            this.listBoxResults.Size = new System.Drawing.Size(300, 100);

            // Form1
            this.ClientSize = new System.Drawing.Size(470, 400);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonContraction);
            this.Controls.Add(this.buttonUnification);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxKeyword);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listBoxResults);
            this.Text = "FinderString";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
