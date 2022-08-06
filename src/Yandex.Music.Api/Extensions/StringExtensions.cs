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
            return string.Join(delimiter, Regex.Matches(str, @"([A-Z]+)(?=([A-Z][a-z]|$)) | [A-Z][a-z].+?(?=([A-Z]|$))", RegexOptions.IgnorePatternWhitespace)
                .Cast<Match>()
                .Select(m => m.ToString()));
        }
    }
}