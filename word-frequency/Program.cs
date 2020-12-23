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

            //List<string> stopWords;
            string stopWordsData;
            string text1Data;
            string text2Data;

            DataReader reader = new DataReader(filePath);

            if (reader.DefineStream(stopWordsDataFile))
            {
                // Iteration 1: Convert text file to list, then trim and convert to lower case
                //stopWords = reader.ConvertTextFileToList(reader.Stream);

                //for (int i = 0; i < stopWords.Count; i++)
                //{
                //    stopWords[i] = DataCleaner.TrimString(stopWords[i]);
                //    stopWords[i] = DataCleaner.StringToLowerCase(stopWords[i]);
                //    Console.WriteLine(stopWords[i]);
                //}

                // Iteration 2: Convert text file to string, then split at Delimiters
                    // whitespace and tabs are automatically removed
                    // conversion to lower case is not necessary
                stopWordsData = reader.ConvertTextFileToString(reader.Stream);
                char[] delimiters = { ' ', '\t' };
                string[] stopWords = DataCleaner.SplitStringAtDelimiters(stopWordsData, delimiters);
                for (int i = 0; i < stopWords.Length; i++)
                {
                    Console.WriteLine(stopWords[i]);
                }
            }
            Console.WriteLine();

            //if (reader.DefineStream(text1DataFile))
            //{
            //    text1Data = reader.ConvertTextFileToString(reader.Stream);
            //    char[] delimiters = { ' ', '-' };
            //    string[] text1Words = DataCleaner.SplitStringAtDelimiters(text1Data, delimiters);
            //    for (int i = 0; i < text1Words.Length; i++)
            //    {
            //        Console.WriteLine(text1Words[i]);
            //    }
            //}
            //Console.WriteLine();

            //if (reader.DefineStream(text2DataFile))
            //{
            //    text2Data = reader.ConvertTextFileToString(reader.Stream);
            //    char[] delimiters = { ' ', '-'};
            //    string[] text2Words = DataCleaner.SplitStringAtDelimiters(text2Data, delimiters);
            //    for (int i = 0; i < text2Words.Length; i++)
            //    {
            //        Console.WriteLine(text2Words[i]);
            //    }
            //}

            Console.ReadKey();
        }
    }
}
