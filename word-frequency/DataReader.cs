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

        public string ConvertTextFileToString(string fileName)
        {
            string textString = "";

            try
            {
                using (StreamReader reader = new StreamReader(FilePath + fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        textString += line + " ";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: file could not be read");
                Console.WriteLine(e.Message);
            }

            return textString;
        }

        public List<string> ConvertTextFileToList(string fileName)
        {
            List<string> textList = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(FilePath + fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        textList.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: file could not be read");
                Console.WriteLine(e.Message);
            }

            return textList;
        }

    }
}
