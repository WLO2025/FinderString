using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinderString.SearchModules;

namespace FinderString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 확장자 리스트 초기화
            checkedListBoxExtensions.Items.AddRange(new string[]
            {
                ".txt", ".cs", ".log", ".json", ".xml", ".md", ".html", ".java", ".py", ".cpp"
            });
            checkedListBoxExtensions.CheckOnClick = true;
        }

        private void buttonContraction_Click(object sender, EventArgs e)
        {
            string input = textBoxInput.Text;
            string result = ContractionSearch.Run(input);
            textBoxOutput.Text = result;
        }

        private void buttonUnification_Click(object sender, EventArgs e)
        {
            string input = textBoxInput.Text;
            string result = UnificationSearch.Run(input);
            textBoxOutput.Text = result;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolder.Text = dialog.SelectedPath;
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string folderPath = textBoxFolder.Text;
            string keyword = textBoxKeyword.Text;

            // 선택된 확장자만 리스트로 추출
            var extensions = checkedListBoxExtensions.CheckedItems.Cast<string>().ToList();

            if (extensions.Count == 0)
            {
                MessageBox.Show("검색할 확장자를 하나 이상 선택해주세요.");
                return;
            }

            var results = SearchManager.SearchFiles(folderPath, extensions, keyword);

            listBoxResults.Items.Clear();
            foreach (var file in results)
            {
                listBoxResults.Items.Add(file);
            }

            if (results.Count == 0)
            {
                MessageBox.Show("검색 결과가 없습니다.");
            }
        }
    }
}
