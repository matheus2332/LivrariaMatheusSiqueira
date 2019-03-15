using System.Text.RegularExpressions;

namespace CrossCutting.Strings
{
    public static class StringHelper
    {
        public static string TextoToQuery(this string valor, bool wildCardNoComeco = true, bool wildCardNoFim = true)
        {
            return $"{(wildCardNoComeco ? "%" : "")}{Regex.Replace(valor?.Trim() ?? "", @"[^0-9a-zA-Z]+", "%")}{(wildCardNoFim ? "%" : "")}";
        }
    }
}