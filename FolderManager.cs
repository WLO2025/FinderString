using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FinderString
{
    public class FolderManager
    {
        private List<string> excludedFolders = new List<string>();
        private readonly string configPath = "excludedFolders.json";

        public void AddExcludedFolder(string folderPath)
        {
            if (!excludedFolders.Contains(folderPath))
            {
                excludedFolders.Add(folderPath);
                SaveExcludedFolders();
            }
        }

        public void RemoveExcludedFolder(int index)
        {
            if (index >= 0 && index < excludedFolders.Count)
            {
                excludedFolders.RemoveAt(index);
                SaveExcludedFolders();
            }
        }

        public List<string> GetExcludedFolders()
        {
            return excludedFolders;
        }

        public void LoadExcludedFolders()
        {
            if (File.Exists(configPath))
            {
                var json = File.ReadAllText(configPath);
                excludedFolders = JsonSerializer.Deserialize<List<string>>(json);
            }
        }

        private void SaveExcludedFolders()
        {
            var json = JsonSerializer.Serialize(excludedFolders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configPath, json);
        }
    }
}
