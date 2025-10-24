using System;

namespace FinderString.SearchModules
{
    public static class ContractionSearch
    {
        public static string Run(string input)
        {
            // 예시: 문자열에서 공백 제거
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input.Replace(" ", "");
        }
    }
}
