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
            PorterStemmer porterStemmer = new PorterStemmer();

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

            // 
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
                // create array of words from text file
                text2Data = reader.ConvertTextFileToString(reader.Stream);
                string[] text2Words = cleaner.SplitStringAtDelimiters(text2Data);

                // add words to TermFrequency dictionary by name and frequency
                for (int i = 0; i < text2Words.Length; i++)
                {
                    // first, remove apostrophes from words
                    if (text2Words[i].Contains('\''))
                    {
                        text2Words[i] = cleaner.RemoveApostropheSubstringFromWord(text2Words[i]);
                    }

                    // then, add as a new entry or increase frequency of existing entry
                    if (cleaner.ExistsInTermFrequency(text2Words[i]))
                    {
                        cleaner.IncreaseTermFrequency(text2Words[i], 1);
                    }
                    else
                    {
                        cleaner.AddTermToTermFrequency(text2Words[i]);
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
                string originalTerm;
                int frequency;
                Dictionary<string, int> TermFrequencyCopy = new Dictionary<string, int>(cleaner.TermFrequency);
                foreach (var item in TermFrequencyCopy)
                {
                    originalTerm = item.Key;
                    frequency = item.Value;
                    string stem = porterStemmer.StemWord(originalTerm);
                    if (!stem.Equals(originalTerm))
                    {
                        // if the stem already exists in the dictionary, combine its frequency with existing frequency
                        if (cleaner.ExistsInTermFrequency(stem)) 
                        {
                            cleaner.IncreaseTermFrequency(stem, frequency); 
                        }
                        else
                        {
                            // else, add new stem word and frequency to dictionary
                            cleaner.AddStemWordToTermFrequency(stem, frequency); 
                        }

                        // remove the original term from the dictionary
                        cleaner.RemoveTerm(originalTerm); 
                    }
                }

                // print out terms and frequency in descending order
                foreach (KeyValuePair<string, int> item in cleaner.TermFrequency.OrderByDescending(key => key.Value))
                {
                    Console.WriteLine($"Term: {item.Key}, Frequency: {item.Value}");
                }
            }

            Console.ReadKey();
        }
    }
}
