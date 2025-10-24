using System.IO;
using System.Text.Json;

namespace FinderString
{
    public class AppConfig<T> where T : class, new()
    {
        private readonly string configFile;

        public AppConfig(string fileName)
        {
            configFile = fileName;
        }

        public T Load()
        {
            if (!File.Exists(configFile))
                return new T();

            var json = File.ReadAllText(configFile);
            return JsonSerializer.Deserialize<T>(json);
        }

        public void Save(T config)
        {
            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFile, json);
        }
    }
}
