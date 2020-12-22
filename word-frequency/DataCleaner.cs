using System;
using System.Collections.Generic;
using System.Text;

namespace word_frequency
{
    public class DataCleaner
    {

        public string TrimString(string dataString)
        {
            return dataString.Trim();
        }

        public string StringToLowerCase(string dataString)
        {
            return dataString.ToLower();
        }
    }
}
