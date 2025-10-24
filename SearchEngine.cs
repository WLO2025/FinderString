using System;
using System.Collections.Generic;
using System.IO;

namespace FinderString
{
    public class SearchEngine
    {
        public List<string> Search(string rootPath, string keyword, List<string> extensions, List<string> excludedFolders)
        {
            var results = new List<string>();

            if (!Directory.Exists(rootPath) || string.IsNullOrWhiteSpace(keyword))
                return results;

            try
            {
                SearchDirectory(rootPath, keyword, extensions, excludedFolders, results);
            }
            catch (Exception ex)
            {
                results.Add($"[오류] 검색 중 예외 발생: {ex.Message}");
            }

            return results;
        }

        private void SearchDirectory(string currentPath, string keyword, List<string> extensions, List<string> excludedFolders, List<string> results)
        {
            if (excludedFolders.Contains(currentPath))
                return;

            try
            {
                foreach (var file in Directory.GetFiles(currentPath))
                {
                    if (extensions.Count > 0 && !extensions.Contains(Path.GetExtension(file)))
                        continue;

                    try
                    {
                        var lines = File.ReadAllLines(file);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                results.Add($"{file} (Line {i + 1}): {lines[i]}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        results.Add($"[읽기 오류] {file}: {ex.Message}");
                    }
                }

                foreach (var dir in Directory.GetDirectories(currentPath))
                {
                    SearchDirectory(dir, keyword, extensions, excludedFolders, results);
                }
            }
            catch (UnauthorizedAccessException)
            {
                results.Add($"[접근 거부] {currentPath}");
            }
            catch (Exception ex)
            {
                results.Add($"[디렉터리 오류] {currentPath}: {ex.Message}");
            }
        }
    }
}
