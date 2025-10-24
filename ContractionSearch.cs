using System;

namespace FinderString.SearchModules
{
    public static class ContractionSearch
    {
        public static string Run(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            // 예시: 공백 제거
            return input.Replace(" ", "");
        }
    }
}
