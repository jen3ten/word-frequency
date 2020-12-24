using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            List<string> stopWords = new List<string>();
            string text1Data;
            string text2Data;

            DataReader reader = new DataReader(filePath);
            DataCleaner cleaner = new DataCleaner();

            // create a string list of stop words
            if (reader.DefineStream(stopWordsDataFile))
            {
                stopWords = reader.ConvertTextFileToList(reader.Stream);
            }

            // create a char array of delimiters
            if (reader.DefineStream(delimitersDataFile))
            {
                cleaner.CreateDelimiterArrayFromTextFile(reader.Stream);
            }

            // clean data and identify frequency of terms
            if (reader.DefineStream(text1DataFile))
            {
                text1Data = reader.ConvertTextFileToString(reader.Stream);
                string[] text1Words = cleaner.SplitStringAtDelimiters(text1Data);

                cleaner.GetTermFrequencyFromStringArray(text1Words, stopWords);
            }

            // clean data and identify frequency of terms
            if (reader.DefineStream(text2DataFile))
            {
                // create array of words from text file
                text2Data = reader.ConvertTextFileToString(reader.Stream);
                string[] text2Words = cleaner.SplitStringAtDelimiters(text2Data);

                cleaner.GetTermFrequencyFromStringArray(text2Words, stopWords);
            }

            Console.ReadKey();
        }
    }
}
