using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace word_frequency
{
    public class DataCleaner
    {
        public char[] Delimiters { get; set; }

        public string TrimString(string dataString)
        {
            return dataString.Trim();
        }

        public string StringToLowerCase(string dataString)
        {
            return dataString.ToLower();
        }


        public string TrimCharactersFromString(string dataString, char[] trimmedCharacters)
        {
            return dataString.Trim(trimmedCharacters);
        }

        public void CreateDelimiterArrayFromTextFile(StreamReader stream)
        {
            string textString = " "; //adds whitespace to char array

            using (stream)
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    textString += line;
                }
            }

            Delimiters = new char[textString.Length];
            StringReader sr = new StringReader(textString);
            sr.Read(Delimiters);
        }

        //public static string[] SplitStringAtDelimiters(string dataString, char[] delimiters)
        //{
        //    string[] dataArray = dataString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        //    return dataArray;
        //}

        public string[] SplitStringAtDelimiters(string dataString)
        {
            string[] dataArray = dataString.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
            return dataArray;
        }


    }
}
