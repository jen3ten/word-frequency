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

        public void ConvertTextFileToString(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePath + fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: file could not be read");
                Console.WriteLine(e.Message);
            }

        }
    }
}
