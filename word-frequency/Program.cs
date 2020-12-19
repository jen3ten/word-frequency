using System;
using System.IO;

namespace word_frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:/Users/jenev/source/repos/CleFedReserveBank";

            try
            {
                using (StreamReader reader = new StreamReader(filePath + "/word-frequency/word-frequency/Data/stopwords.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR: file could not be read");
                Console.WriteLine(e.Message);
            }
        }
    }
}
