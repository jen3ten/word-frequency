using System;
using System.IO;

namespace word_frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string applicationLocation = "C:/Users/jenev/source/repos/CleFedReserveBank";
            string filePath = applicationLocation + "/word-frequency/word-frequency/Data/";
            string stopWordsDataFile = "stopwords.txt";
            string text1DataFile = "Text1.txt";
            string text2DataFile = "Text2.txt";

            DataReader reader = new DataReader(filePath);

            string stopWords = reader.ConvertTextFileToString(stopWordsDataFile);
            Console.WriteLine(stopWords);
            Console.WriteLine();

            string text1Data = reader.ConvertTextFileToString(text1DataFile);
            Console.WriteLine(text1Data);
            Console.WriteLine();

            string text2Data = reader.ConvertTextFileToString(text2DataFile);
            Console.WriteLine(text2Data);
            Console.WriteLine();

        }
    }
}
