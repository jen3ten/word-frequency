using System;
using System.Collections.Generic;
using System.IO;
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


        public static string TrimCharactersFromString(string dataString, char[] trimmedCharacters)
        {
            return dataString.Trim(trimmedCharacters);
        }

        public static void CreateDelimiterArrayFromTextFile(StreamReader stream)
        {
            string textString = " "; //adds whitespace to char array
            using (stream)
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    textString += line;
                }

                StringReader sr = new StringReader(textString);

                sr.Read(Delimiters);
            }
        }

        //public static string[] SplitStringAtDelimiters(string dataString, char[] delimiters)
        //{
        //    string[] dataArray = dataString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        //    return dataArray;
        //}

        public static string[] SplitStringAtDelimiters(string dataString)
        {
            string[] dataArray = dataString.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
            return dataArray;
        }


    }
}
