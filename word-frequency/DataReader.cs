using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace word_frequency
{
    public class DataReader
    {
        public DataReader(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
        public StreamReader Stream { get; set; }

        public bool DefineStream(string fileName)
        {
            try
            {
                Stream = new StreamReader(FilePath + fileName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public string ConvertTextFileToString(StreamReader stream)
        {
            string textString = "";
            using (stream)
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    textString += line + " ";
                }

                return textString;
            }
        }

        public List<string> ConvertTextFileToList(StreamReader stream)
        {
            List<string> textList = new List<string>();
            using (stream)
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    textList.Add(line);
                }
            }
            return textList;
        }
    }
}
