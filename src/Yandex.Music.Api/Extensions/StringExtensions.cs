using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yandex.Music.Api.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceRegex(this string str, string regExpr, string replStr, RegexOptions options = RegexOptions.IgnoreCase)
        {
            return str == null
                ? string.Empty
                : Regex.Replace(str, regExpr, replStr);
        }

        public static string SplitByCapitalLetter(this string str, string delimiter)
        {
#if NETCOREAPP
            return string.Join(delimiter, Regex.Matches(str, @"([A-Z]+)(?=([A-Z][a-z]|$)) | [A-Z][a-z].+?(?=([A-Z]|$))", RegexOptions.IgnorePatternWhitespace)
                .Select(m => m.ToString()));
#endif

#if NETSTANDARD2_0
            var matches = Regex.Matches(str, @"([A-Z]+)(?=([A-Z][a-z]|$)) | [A-Z][a-z].+?(?=([A-Z]|$))",
                RegexOptions.IgnorePatternWhitespace);
            var results = new List<string>();

            foreach (Match match in matches) results.Add(match.Value);

            return string.Join(delimiter, results);
#endif
        }

        /// <summary>
        /// ��������� ������������ ����������� ���������
        /// </summary>
        public static bool IsMatch(this string str, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(str, pattern, options);
        }

        /// <summary>
        /// ��������� ������������ ����������� ���������
        /// </summary>
        public static bool IsMatch(this string str, string pattern)
        {
            return IsMatch(str, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// ���������� ���������� ��� ����������� ���������
        /// </summary>
        public static string[] GetMatches(this string str, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        {
            if (str.IsMatch(pattern, options))
                return Regex.Matches(str, pattern, options).Cast<Match>().Select(m => m.Value).ToArray();

            return new string[] { };
        }
    }
}