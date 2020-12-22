using System;
using System.Collections.Generic;
using System.Text;

namespace word_frequency
{
    public static class DataCleaner
    {

        public static string TrimString(string dataString)
        {
            return dataString.Trim();
        }

        public static string StringToLowerCase(string dataString)
        {
            return dataString.ToLower();
        }
    }
}
