namespace FinderString
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // V2.0에 필요한 컨트롤 변수들
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.CheckedListBox checkedListBoxExtensions;
        private System.Windows.Forms.TextBox textBoxExclusionInput;
        private System.Windows.Forms.Button buttonAddExclusion;
        private System.Windows.Forms.ListBox listBoxExclusions;
        private System.Windows.Forms.Button buttonToggleExtensions;
        private System.Windows.Forms.PictureBox pictureBoxWLO;
        private System.Windows.Forms.Button buttonCopyResults;
        private System.Windows.Forms.Button buttonSaveResults;
        private System.Windows.Forms.Button buttonExitApp;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.checkedListBoxExtensions = new System.Windows.Forms.CheckedListBox();
            this.textBoxExclusionInput = new System.Windows.Forms.TextBox();
            this.buttonAddExclusion = new System.Windows.Forms.Button();
            this.listBoxExclusions = new System.Windows.Forms.ListBox();
            this.buttonToggleExtensions = new System.Windows.Forms.Button();
            this.pictureBoxWLO = new System.Windows.Forms.PictureBox();
            this.buttonCopyResults = new System.Windows.Forms.Button();
            this.buttonSaveResults = new System.Windows.Forms.Button();
            this.buttonExitApp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWLO)).BeginInit();
            this.SuspendLayout();

            // ----------------------------------------------------
            // 1. 폴더 선택 섹션
            // ----------------------------------------------------
            // buttonBrowse (폴더 선택 버튼)
            this.buttonBrowse.Location = new System.Drawing.Point(10, 10);
            this.buttonBrowse.Size = new System.Drawing.Size(80, 23);
            this.buttonBrowse.Text = "폴더 선택";
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);

            // textBoxFolder (선택된 폴더 경로 표시)
            this.textBoxFolder.Location = new System.Drawing.Point(100, 12);
            this.textBoxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolder.Size = new System.Drawing.Size(430, 20);

            // ----------------------------------------------------
            // 2. 제외 폴더 섹션
            // ----------------------------------------------------
            // textBoxExclusionInput (제외 폴더 입력)
            this.textBoxExclusionInput.Location = new System.Drawing.Point(100, 40);
            this.textBoxExclusionInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExclusionInput.Size = new System.Drawing.Size(430, 20);

            // buttonAddExclusion (제외 폴더 '클릭' 버튼)
            this.buttonAddExclusion.Location = new System.Drawing.Point(540, 40);
            this.buttonAddExclusion.Size = new System.Drawing.Size(50, 23);
            this.buttonAddExclusion.Text = "클릭";
            this.buttonAddExclusion.Click += new System.EventHandler(this.buttonAddExclusion_Click);

            // listBoxExclusions (제외 폴더 목록)
            this.listBoxExclusions.Location = new System.Drawing.Point(10, 70);
            this.listBoxExclusions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxExclusions.Size = new System.Drawing.Size(580, 80);

            // ----------------------------------------------------
            // 3. 확장자 선택 섹션 (CheckedListBox와 모두 버튼)
            // ----------------------------------------------------
            // checkedListBoxExtensions
            this.checkedListBoxExtensions.Location = new System.Drawing.Point(600, 10);
            this.checkedListBoxExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxExtensions.Size = new System.Drawing.Size(80, 139);

            // buttonToggleExtensions ('모두' 버튼)
            this.buttonToggleExtensions.Location = new System.Drawing.Point(600, 150);
            this.buttonToggleExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToggleExtensions.Size = new System.Drawing.Size(80, 23);
            this.buttonToggleExtensions.Text = "모두";
            this.buttonToggleExtensions.Click += new System.EventHandler(this.buttonToggleExtensions_Click);

            // ----------------------------------------------------
            // 4. 검색 문자열 입력 섹션
            // ----------------------------------------------------
            // textBoxKeyword (문자열 입력)
            this.textBoxKeyword.Location = new System.Drawing.Point(10, 180);
            this.textBoxKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKeyword.Size = new System.Drawing.Size(570, 20);

            // buttonSearch (검색 버튼)
            this.buttonSearch.Location = new System.Drawing.Point(585, 180);
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Size = new System.Drawing.Size(95, 23);
            this.buttonSearch.Text = "검색";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);

            // ----------------------------------------------------
            // 5. 검색 결과 및 하단 버튼 섹션
            // ----------------------------------------------------
            // listBoxResults (검색 결과 표시)
            this.listBoxResults.Location = new System.Drawing.Point(10, 210);
            this.listBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResults.Size = new System.Drawing.Size(670, 250);

            // buttonCopyResults (복사 버튼)
            this.buttonCopyResults.Location = new System.Drawing.Point(10, 470);
            this.buttonCopyResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCopyResults.Size = new System.Drawing.Size(80, 23);
            this.buttonCopyResults.Text = "결과 복사";
            this.buttonCopyResults.Click += new System.EventHandler(this.buttonCopyResults_Click);

            // buttonSaveResults (저장 버튼)
            this.buttonSaveResults.Location = new System.Drawing.Point(95, 470);
            this.buttonSaveResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSaveResults.Size = new System.Drawing.Size(80, 23);
            this.buttonSaveResults.Text = "결과 저장";
            this.buttonSaveResults.Click += new System.EventHandler(this.buttonSaveResults_Click);

            // buttonExitApp (앱 종료 버튼)
            this.buttonExitApp.Location = new System.Drawing.Point(600, 470);
            this.buttonExitApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExitApp.Size = new System.Drawing.Size(80, 23);
            this.buttonExitApp.Text = "앱 종료";
            this.buttonExitApp.Click += new System.EventHandler(this.buttonExitApp_Click);

            // ----------------------------------------------------
            // 6. 로고 및 폼 설정
            // ----------------------------------------------------
            // pictureBoxWLO (WLO 로고 - 우측 상단)
            this.pictureBoxWLO.Location = new System.Drawing.Point(540, 10);
            this.pictureBoxWLO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWLO.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxWLO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // WLO 로고 이미지 참조 이름 수정 (WLO503 반영)
            this.pictureBoxWLO.Image = global::FinderString.Properties.Resources.WLO503;

            // Form1
            this.ClientSize = new System.Drawing.Size(690, 500);
            this.Text = "FinderString";

            // Controls.Add 순서
            this.Controls.Add(this.buttonExitApp);
            this.Controls.Add(this.buttonSaveResults);
            this.Controls.Add(this.buttonCopyResults);
            this.Controls.Add(this.pictureBoxWLO);
            this.Controls.Add(this.buttonToggleExtensions);
            this.Controls.Add(this.listBoxExclusions);
            this.Controls.Add(this.buttonAddExclusion);
            this.Controls.Add(this.textBoxExclusionInput);
            this.Controls.Add(this.checkedListBoxExtensions);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxKeyword);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxFolder);

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWLO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}