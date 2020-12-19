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
                    bool eof = false;
                    string line;
                    int count = 0;
                    while (!eof)
                    {
                        line = reader.ReadLine();
                        if (line == null)
                        {
                            eof = true;
                        }
                        else
                        {
                            Console.WriteLine(line);
                            count++;
                        }
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
