using System;

namespace FinderString.SearchModules
{
    public static class UnificationSearch
    {
        public static string Run(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            // 예시: 대문자로 통일
            return input.ToUpper();
        }
    }
}
