using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinderString
{
    public partial class Form1 : Form
    {
        // ----------------------------------------------------
        // 1. 전역 변수 및 상수
        // ----------------------------------------------------
        private const string ExclusionFileName = "ExclusionList.json";
        private List<string> exclusionFolders = new List<string>();
        private readonly string[] defaultExtensions = { ".txt", ".cs", ".log", ".json", ".xml", ".md", ".html", ".java", ".py" };
        private bool isSearching = false;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            // 제외 폴더 목록에 우클릭 메뉴 연결
            this.listBoxExclusions.MouseDown += new MouseEventHandler(this.listBoxExclusions_MouseDown);
        }

        // ----------------------------------------------------
        // 2. 폼 로드 시 초기 설정
        // ----------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeExtensions();
            LoadExclusionList();

            // WLO 로고 이미지 로드 (리소스 이름 WLO503 반영)
            try
            {
                this.pictureBoxWLO.Image = global::FinderString.Properties.Resources.WLO503;
            }
            catch (Exception)
            {
                // 리소스 로드 실패 시 무시
            }
        }

        private void InitializeExtensions()
        {
            checkedListBoxExtensions.Items.Clear();
            foreach (var ext in defaultExtensions)
            {
                checkedListBoxExtensions.Items.Add(ext, false);
            }
        }

        // ----------------------------------------------------
        // 3. 제외 폴더 관리 기능 (저장/로딩/추가)
        // ----------------------------------------------------

        private void LoadExclusionList()
        {
            if (File.Exists(ExclusionFileName))
            {
                try
                {
                    string jsonString = File.ReadAllText(ExclusionFileName);
                    List<string> loadedList = JsonSerializer.Deserialize<List<string>>(jsonString);
                    if (loadedList != null)
                    {
                        exclusionFolders = loadedList.Distinct().ToList();
                        RefreshExclusionListBox();
                    }
                }
                catch (Exception) { /* 무시 */ }
            }
        }

        private void SaveExclusionList()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(exclusionFolders, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ExclusionFileName, jsonString);
            }
            catch (Exception) { /* 무시 */ }
        }

        private void RefreshExclusionListBox()
        {
            listBoxExclusions.Items.Clear();
            foreach (var folder in exclusionFolders)
            {
                listBoxExclusions.Items.Add(folder);
            }
        }

        private void AddExclusionFolder(string path)
        {
            if (!string.IsNullOrWhiteSpace(path) && !exclusionFolders.Contains(path, StringComparer.OrdinalIgnoreCase))
            {
                exclusionFolders.Add(path);
                RefreshExclusionListBox();
                SaveExclusionList();
            }
        }

        // ----------------------------------------------------
        // 4. 이벤트 핸들러 구현
        // ----------------------------------------------------

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    textBoxFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void buttonAddExclusion_Click(object sender, EventArgs e)
        {
            string path = textBoxExclusionInput.Text.Trim();
            if (Directory.Exists(path))
            {
                AddExclusionFolder(path);
                textBoxExclusionInput.Clear();
            }
            else
            {
                MessageBox.Show("유효하지 않은 폴더 경로이거나 존재하지 않는 폴더입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBoxExclusions_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBoxExclusions.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    listBoxExclusions.SelectedIndex = index;

                    var contextMenu = new ContextMenuStrip();
                    contextMenu.Items.Add("삭제", null, (s, ev) =>
                    {
                        if (listBoxExclusions.SelectedIndex >= 0)
                        {
                            string selectedPath = listBoxExclusions.SelectedItem.ToString();
                            exclusionFolders.Remove(selectedPath);

                            RefreshExclusionListBox();
                            SaveExclusionList();
                        }
                    });

                    contextMenu.Show(listBoxExclusions, e.Location);
                }
            }
        }

        private void buttonToggleExtensions_Click(object sender, EventArgs e)
        {
            int checkedCount = checkedListBoxExtensions.CheckedItems.Count;
            bool shouldCheckAll = checkedCount != checkedListBoxExtensions.Items.Count;

            for (int i = 0; i < checkedListBoxExtensions.Items.Count; i++)
            {
                checkedListBoxExtensions.SetItemChecked(i, shouldCheckAll);
            }
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            if (isSearching)
            {
                MessageBox.Show("현재 검색 중입니다. 잠시 기다려 주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string targetFolder = textBoxFolder.Text.Trim();
            string keyword = textBoxKeyword.Text.Trim();

            if (!Directory.Exists(targetFolder))
            {
                MessageBox.Show("유효한 검색 폴더를 선택해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("검색할 문자열을 입력해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedExtensions = checkedListBoxExtensions.CheckedItems.Cast<string>().ToList();
            if (!selectedExtensions.Any())
            {
                MessageBox.Show("검색할 파일 확장자를 하나 이상 선택해 주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBoxResults.Items.Clear();
            isSearching = true;
            buttonSearch.Enabled = false;

            List<string> inaccessibleFolders = await Task.Run(() => SearchFiles(targetFolder, keyword, selectedExtensions));

            isSearching = false;
            buttonSearch.Enabled = true;

            HandleInaccessibleFolders(inaccessibleFolders);
        }


        // ----------------------------------------------------
        // 5. 실제 파일 검색 및 '제외 폴더 자동 등록' 로직
        // ----------------------------------------------------

        private List<string> SearchFiles(string path, string keyword, List<string> extensions)
        {
            Queue<string> foldersToProcess = new Queue<string>();
            foldersToProcess.Enqueue(path);

            List<string> inaccessibleFolders = new List<string>();

            while (foldersToProcess.Any())
            {
                string currentDir = foldersToProcess.Dequeue();

                if (exclusionFolders.Contains(currentDir, StringComparer.OrdinalIgnoreCase))
                {
                    continue;
                }

                // 1. 파일 검색
                try
                {
                    foreach (string file in Directory.GetFiles(currentDir))
                    {
                        string extension = Path.GetExtension(file);
                        if (extensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                        {
                            CheckFileForKeyword(file, keyword);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    if (!inaccessibleFolders.Contains(currentDir, StringComparer.OrdinalIgnoreCase))
                    {
                        inaccessibleFolders.Add(currentDir);
                    }
                }
                catch (Exception)
                {
                }

                // 2. 하위 폴더 큐에 추가
                try
                {
                    foreach (string dir in Directory.GetDirectories(currentDir))
                    {
                        if (!exclusionFolders.Contains(dir, StringComparer.OrdinalIgnoreCase))
                        {
                            foldersToProcess.Enqueue(dir);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    if (!inaccessibleFolders.Contains(currentDir, StringComparer.OrdinalIgnoreCase))
                    {
                        inaccessibleFolders.Add(currentDir);
                    }
                }
                catch (Exception)
                {
                }
            }
            return inaccessibleFolders;
        }

        private void CheckFileForKeyword(string filePath, string keyword)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        string result = $"{filePath} (Line {i + 1}): {lines[i].Trim()}";
                        this.Invoke((MethodInvoker)delegate {
                            listBoxResults.Items.Add(result);
                        });
                    }
                }
            }
            catch
            {
            }
        }

        private void HandleInaccessibleFolders(List<string> folders)
        {
            List<string> uniqueFolders = folders.Distinct(StringComparer.OrdinalIgnoreCase).ToList();

            if (uniqueFolders.Any())
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string message = $"검색 중 {uniqueFolders.Count}개의 폴더에 접근할 수 없었습니다. 제외 폴더 목록에 등록하여 다음부터 자동으로 건너뛸까요?\n\n(예시: {uniqueFolders.First()})";
                    if (MessageBox.Show(message, "접근 불가 폴더 알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (var folder in uniqueFolders)
                        {
                            AddExclusionFolder(folder);
                        }
                        MessageBox.Show($"{uniqueFolders.Count}개 폴더가 제외 폴더 목록에 등록되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                });
            }
        }


        // ----------------------------------------------------
        // 6. 하단 버튼 이벤트 핸들러
        // ----------------------------------------------------

        private void buttonCopyResults_Click(object sender, EventArgs e)
        {
            if (listBoxResults.Items.Count > 0)
            {
                string results = string.Join(Environment.NewLine, listBoxResults.Items.Cast<string>());
                Clipboard.SetText(results);
                MessageBox.Show("검색 결과가 클립보드에 복사되었습니다.", "복사 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("복사할 검색 결과가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSaveResults_Click(object sender, EventArgs e)
        {
            if (listBoxResults.Items.Count == 0)
            {
                MessageBox.Show("저장할 검색 결과가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "텍스트 파일 (*.txt)|*.txt";
                sfd.FileName = $"FinderString_Results_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string results = string.Join(Environment.NewLine, listBoxResults.Items.Cast<string>());
                        File.WriteAllText(sfd.FileName, results);
                        MessageBox.Show("검색 결과가 성공적으로 저장되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"파일 저장 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonExitApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
