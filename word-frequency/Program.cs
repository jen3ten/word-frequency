using System;
using System.IO;

namespace word_frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:/Users/jenev/source/repos/CleFedReserveBank";

            DataReader reader = new DataReader(filePath);

            reader.ReadFromDataFile();

        }
    }
}
