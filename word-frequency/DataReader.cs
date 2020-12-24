using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public StreamReader StreamReader { get; set; }
        public StreamWriter StreamWriter { get; set; }

        public bool DefineStreamReader(string fileName)
        {
            try
            {
                StreamReader = new StreamReader(FilePath + fileName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR connecting to {fileName}:");
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
                    textList.Add(line.Trim());
                }
            }
            return textList;
        }

        public bool DefineStreamWriter(string fileName)
        {
            try
            {
                StreamWriter = new StreamWriter(FilePath + fileName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR connecting to {fileName}:");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void OutputResultsToTextFile(StreamWriter stream, Dictionary<string, int> termFrequency)
        {

            using (stream)
            {
                foreach (var item in termFrequency.OrderByDescending(key => key.Value))
                {
                    stream.WriteLine($"Term: {item.Key}, Frequency: {item.Value}");
                }
            }
        }
    }
}
