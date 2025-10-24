using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FinderString
{
    public partial class MainForm : Form
    {
        private FolderManager folderManager;
        private SearchEngine searchEngine;

        public MainForm()
        {
            InitializeComponent();
            folderManager = new FolderManager();
            searchEngine = new SearchEngine();
            LoadExcludedFolders();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    folderManager.AddExcludedFolder(dialog.SelectedPath);
                    RefreshExcludedFolderList();
                }
            }
        }

        private void RefreshExcludedFolderList()
        {
            lstExcludedFolders.Items.Clear();
            foreach (var folder in folderManager.GetExcludedFolders())
            {
                lstExcludedFolders.Items.Add(folder);
            }
        }

        private void LoadExcludedFolders()
        {
            folderManager.LoadExcludedFolders();
            RefreshExcludedFolderList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var rootPath = txtRootFolder.Text;
            var keyword = txtKeyword.Text;
            var extensions = GetSelectedExtensions();

            var results = searchEngine.Search(rootPath, keyword, extensions, folderManager.GetExcludedFolders());
            lstResults.Items.Clear();
            foreach (var result in results)
            {
                lstResults.Items.Add(result);
            }
        }

        private List<string> GetSelectedExtensions()
        {
            var selected = new List<string>();
            foreach (var item in clbExtensions.CheckedItems)
            {
                selected.Add(item.ToString());
            }
            return selected;
        }

        private void lstExcludedFolders_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = lstExcludedFolders.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    var result = MessageBox.Show("이 폴더를 제외 목록에서 삭제할까요?", "삭제 확인", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        folderManager.RemoveExcludedFolder(index);
                        RefreshExcludedFolderList();
                    }
                }
            }
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text Files (*.txt)|*.txt";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(dialog.FileName, lstResults.Items.Cast<string>());
                }
            }
        }

        private void btnSelectAllExtensions_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbExtensions.Items.Count; i++)
            {
                clbExtensions.SetItemChecked(i, true);
            }
        }

        private void btnClearExtensions_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbExtensions.Items.Count; i++)
            {
                clbExtensions.SetItemChecked(i, false);
            }
        }
    }
}
