﻿using System;
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
            PorterStemmer porterStemmer = new PorterStemmer();

            if (reader.DefineStream(stopWordsDataFile))
            {
                stopWords = reader.ConvertTextFileToList(reader.Stream);

                //for (int i = 0; i < stopWords.Count; i++)
                //{
                //    Console.WriteLine(stopWords[i]);
                //}
            }
            Console.WriteLine();

            if (reader.DefineStream(delimitersDataFile))
            {
                cleaner.CreateDelimiterArrayFromTextFile(reader.Stream);

                //for (int i = 0; i < cleaner.Delimiters.Length; i++)
                //{
                //    Console.WriteLine(cleaner.Delimiters[i]);
                //}
            }
            Console.WriteLine();

            if (reader.DefineStream(text1DataFile))
            {
                text1Data = reader.ConvertTextFileToString(reader.Stream);
                string[] text1Words = cleaner.SplitStringAtDelimiters(text1Data);
                //for (int i = 0; i < text1Words.Length; i++)
                //{
                //    Console.WriteLine(text1Words[i]);
                //}

                //foreach(string term in text1Words)
                //{
                //    if (cleaner.ExistsInTermFrequency(term))
                //    {
                //        cleaner.IncreaseTermFrequency(term, 1);
                //    }
                //    else
                //    {
                //        cleaner.AddTermToTermFrequency(term);
                //    }
                //}

                //foreach (KeyValuePair<string, int> item in cleaner.TermFrequency.OrderByDescending(key => key.Value))
                //{
                //    Console.WriteLine($"Term: {item.Key}, Frequency: {item.Value}");
                //}

            }
            Console.WriteLine();

            if (reader.DefineStream(text2DataFile))
            {
                text2Data = reader.ConvertTextFileToString(reader.Stream);
                string[] text2Words = cleaner.SplitStringAtDelimiters(text2Data);
                //for (int i = 0; i < text2Words.Length; i++)
                //{
                //    Console.WriteLine(text2Words[i]);
                //}

                // add words to TermFrequency dictionary with term frequency
                foreach (string word in text2Words)
                {
                    if (cleaner.ExistsInTermFrequency(word))
                    {
                        cleaner.IncreaseTermFrequency(word, 1);
                    }
                    else
                    {
                        cleaner.AddTermToTermFrequency(word);
                    }
                }

                // remove stop words from TermFrequency dictionary
                foreach (string word in stopWords)
                {
                    if (cleaner.ExistsInTermFrequency(word))
                    {
                        cleaner.RemoveStopWord(word);
                    }
                }

                // stem words in TermFrequency dictionary and add new stems to dictionary, or combine with existing stem
                string term;
                int frequency;
                foreach (KeyValuePair<string, int> item in cleaner.TermFrequency)
                {
                    term = item.Key;
                    frequency = item.Value;
                    string stem = porterStemmer.StemWord(term);
                    if (!stem.Equals(term))
                    {
                        Console.WriteLine($"{stem} derived from {term}");
                    }
                }

                // print out terms and frequency in descending order
                //foreach (KeyValuePair<string, int> item in cleaner.TermFrequency.OrderByDescending(key => key.Value))
                //{
                //    Console.WriteLine($"Term: {item.Key}, Frequency: {item.Value}");
                //}
            }
            Console.WriteLine();

            //Test Porter Stemmer
            //PorterStemmer porterStemmer = new PorterStemmer();
            //string stem = porterStemmer.StemWord("jumping");
            //Console.WriteLine(stem);

            Console.ReadKey();
        }
    }
}
