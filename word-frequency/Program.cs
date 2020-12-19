using System;
using System.IO;

namespace word_frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new StreamReader("C:/Users/jenev/source/repos/CleFedReserveBank/word-frequency/word-frequency/Data/stopwords.txt"))
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
                    Console.WriteLine($"line count is {count}");
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
