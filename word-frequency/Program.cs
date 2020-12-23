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
            string delimitersDataFile = "delimiters.txt";

            List<string> stopWords;
            string text1Data;
            string text2Data;
            //char[] delimiters;

            DataReader reader = new DataReader(filePath);

            //if (reader.DefineStream(stopWordsDataFile))
            //{
            //    stopWords = reader.ConvertTextFileToList(reader.Stream);

            //    for (int i = 0; i < stopWords.Count; i++)
            //    {
            //        stopWords[i] = DataCleaner.TrimString(stopWords[i]);
            //        stopWords[i] = DataCleaner.StringToLowerCase(stopWords[i]);
            //        Console.WriteLine(stopWords[i]);
            //    }
            //}
            //Console.WriteLine();

            if (reader.DefineStream(delimitersDataFile))
            {
                DataCleaner.Delimiters = reader.ConvertTextFileToCharArray(reader.Stream);

                for (int i = 0; i < DataCleaner.Delimiters.Length; i++)
                {
                    Console.WriteLine(DataCleaner.Delimiters[i]);
                }
            }
            Console.WriteLine();

            if (reader.DefineStream(text1DataFile))
            {
                text1Data = reader.ConvertTextFileToString(reader.Stream);
                //char[] delimiters = { ' ', '-' };
                string[] text1Words = DataCleaner.SplitStringAtDelimiters(text1Data, DataCleaner.Delimiters);
                for (int i = 0; i < text1Words.Length; i++)
                {
                    Console.WriteLine(text1Words[i]);
                }
            }
            Console.WriteLine();

            if (reader.DefineStream(text2DataFile))
            {
                text2Data = reader.ConvertTextFileToString(reader.Stream);
                //char[] delimiters = { ' ', '-'};
                string[] text2Words = DataCleaner.SplitStringAtDelimiters(text2Data, DataCleaner.Delimiters);
                for (int i = 0; i < text2Words.Length; i++)
                {
                    Console.WriteLine(text2Words[i]);
                }
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
