using System;
using System.Collections.Generic;
using System.Text;

namespace word_frequency
{
    public static class DataCleaner
    {
        public static char[] Delimiters { get; set; }

        public static string TrimString(string dataString)
        {
            return dataString.Trim();
        }

        public static string StringToLowerCase(string dataString)
        {
            return dataString.ToLower();
        }

        public static string[] SplitStringAtDelimiters(string dataString, char[] delimiters)
        {
            string[] dataArray = dataString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            return dataArray;
        }

        public static string TrimCharactersFromString(string dataString, char[] trimmedCharacters)
        {
            return dataString.Trim(trimmedCharacters);
        }
    }
}
