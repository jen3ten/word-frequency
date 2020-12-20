using System;
using System.Collections.Generic;
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

            List<string> stopWords = reader.ConvertTextFileToList(stopWordsDataFile);
            foreach (string word in stopWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();

            if (reader.DefineStream(text1DataFile))
            {
                string text1Data = reader.ConvertTextFileToString(reader.Stream);
                Console.WriteLine(text1Data);
            }
            Console.WriteLine();

            if (reader.DefineStream(text2DataFile))
            {
                string text2Data = reader.ConvertTextFileToString(reader.Stream);
                Console.WriteLine(text2Data);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
