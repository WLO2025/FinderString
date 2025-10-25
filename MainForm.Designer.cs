namespace FinderString
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.CheckedListBox clbExtensions;
        private System.Windows.Forms.Button btnSelectAllExtensions;
        private System.Windows.Forms.Button btnClearExtensions;
        private System.Windows.Forms.ListBox lstExcludedFolders;
        private System.Windows.Forms.Button btnAddFolder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.clbExtensions = new System.Windows.Forms.CheckedListBox();
            this.btnSelectAllExtensions = new System.Windows.Forms.Button();
            this.btnClearExtensions = new System.Windows.Forms.Button();
            this.lstExcludedFolders = new System.Windows.Forms.ListBox();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtRootFolder
            this.txtRootFolder.Location = new System.Drawing.Point(20, 20);
            this.txtRootFolder.Size = new System.Drawing.Size(400, 23);

            // txtKeyword
            this.txtKeyword.Location = new System.Drawing.Point(20, 60);
            this.txtKeyword.Size = new System.Drawing.Size(400, 23);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(440, 20);
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.Text = "검색";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnSaveResults
            this.btnSaveResults.Location = new System.Drawing.Point(440, 60);
            this.btnSaveResults.Size = new System.Drawing.Size(100, 23);
            this.btnSaveResults.Text = "결과 저장";
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);

            // lstResults
            this.lstResults.Location = new System.Drawing.Point(20, 100);
            this.lstResults.Size = new System.Drawing.Size(520, 200);

            // clbExtensions
            this.clbExtensions.Location = new System.Drawing.Point(560, 20);
            this.clbExtensions.Size = new System.Drawing.Size(120, 100);

            // btnSelectAllExtensions
            this.btnSelectAllExtensions.Location = new System.Drawing.Point(560, 130);
            this.btnSelectAllExtensions.Size = new System.Drawing.Size(120, 23);
            this.btnSelectAllExtensions.Text = "모두 선택";
            this.btnSelectAllExtensions.Click += new System.EventHandler(this.btnSelectAllExtensions_Click);

            // btnClearExtensions
            this.btnClearExtensions.Location = new System.Drawing.Point(560, 160);
            this.btnClearExtensions.Size = new System.Drawing.Size(120, 23);
            this.btnClearExtensions.Text = "선택 해제";
            this.btnClearExtensions.Click += new System.EventHandler(this.btnClearExtensions_Click);

            // lstExcludedFolders
            this.lstExcludedFolders.Location = new System.Drawing.Point(20, 320);
            this.lstExcludedFolders.Size = new System.Drawing.Size(400, 100);
            this.lstExcludedFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstExcludedFolders_MouseClick);

            // btnAddFolder
            this.btnAddFolder.Location = new System.Drawing.Point(440, 320);
            this.btnAddFolder.Size = new System.Drawing.Size(100, 23);
            this.btnAddFolder.Text = "폴더 추가";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.txtRootFolder);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSaveResults);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.clbExtensions);
            this.Controls.Add(this.btnSelectAllExtensions);
            this.Controls.Add(this.btnClearExtensions);
            this.Controls.Add(this.lstExcludedFolders);
            this.Controls.Add(this.btnAddFolder);
            this.Text = "FinderString - 문자열 검색기";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
