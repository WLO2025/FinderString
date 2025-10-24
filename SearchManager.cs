using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinderString
{
    public static class SearchManager
    {
        public static List<string> SearchFiles(string folderPath, List<string> extensions, string keyword)
        {
            var matchedFiles = new List<string>();

            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
                return matchedFiles;

            var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                .Where(file => extensions.Any(ext => file.EndsWith(ext, StringComparison.OrdinalIgnoreCase)));

            foreach (var file in files)
            {
                try
                {
                    string content = File.ReadAllText(file);
                    if (content.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        matchedFiles.Add(file);
                    }
                }
                catch
                {
                    // 파일 읽기 실패 시 무시
                }
            }

            return matchedFiles;
        }
    }
}
