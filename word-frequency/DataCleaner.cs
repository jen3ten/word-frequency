using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace word_frequency
{
    public class DataCleaner
    {
        public char[] Delimiters { get; set; }
        public Dictionary<string, int> TermFrequency {get; set;}

        public PorterStemmer porterStemmer;

        public DataCleaner()
        {
            TermFrequency = new Dictionary<string, int>();
        }

        public void CreateDelimiterArrayFromTextFile(StreamReader stream)
        {
            string textString = " "; //adds whitespace to char array

            using (stream)
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    textString += line;
                }
            }

            Delimiters = new char[textString.Length];
            StringReader sr = new StringReader(textString);
            sr.Read(Delimiters);
        }

        public string[] SplitStringAtDelimiters(string dataString)
        {
            string[] dataArray = dataString.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
            return dataArray;
        }

        public bool ExistsInTermFrequency(string term)
        {
            if(TermFrequency != null  && TermFrequency.Count > 0)
            {
                return TermFrequency.ContainsKey(term.ToLower());
            }
            return false;
        }

        public void AddTermToTermFrequency(string term)
        {
            if(!String.IsNullOrEmpty(term))
            {
                TermFrequency.Add(term.ToLower(), 1);
            }
        }

        public void AddStemWordToTermFrequency(string term, int frequency)
        {
            TermFrequency.Add(term.ToLower(), frequency);
        }

        public void IncreaseTermFrequency(string term, int increaseFrequency)
        {
            TermFrequency[term.ToLower()] += increaseFrequency;
        }

        public void RemoveTerm(string term)
        {
            TermFrequency.Remove(term);
        }

        public void RemoveStopWord(string stopWord)
        {
            TermFrequency.Remove(stopWord.ToLower());
        }

        public string RemoveApostropheSubstringFromWord(string word)
        {
            int index = word.IndexOf('\'');

            if (index == 0) // remove leading apostrophe, such as 'tis
            {
                word = word.Remove(0, 1);
            }
            else if(index == word.Length - 1) // remove trailing apostrophe
            {
                word = word.Remove(index, 1);
            }
            else if (word.ToLower().EndsWith("\'s") || word.ToLower().EndsWith("\'ll")) // remove 's or 'll substring 
            {
                int subStringLength = word.Length - index;
                word = word.Remove(index, subStringLength);
            }

            return word;
        }

        public void GetTermFrequencyFromStringArray(string[] data, List<string> stopWords)
        {
            porterStemmer = new PorterStemmer();

            // add words to TermFrequency dictionary by name and frequency
            for (int i = 0; i < data.Length; i++)
            {
                // first, remove apostrophes from words
                if (data[i].Contains('\''))
                {
                    data[i] = RemoveApostropheSubstringFromWord(data[i]);
                }

                // then, add as a new entry or increase frequency of existing entry
                if (ExistsInTermFrequency(data[i]))
                {
                    IncreaseTermFrequency(data[i], 1);
                }
                else
                {
                    AddTermToTermFrequency(data[i]);
                }
            }

            // remove stop words from TermFrequency dictionary
            foreach (string word in stopWords)
            {
                if (ExistsInTermFrequency(word))
                {
                    RemoveStopWord(word);
                }
            }

            // stem words in TermFrequency dictionary and add new stems to dictionary, or combine with existing stem
            string originalTerm;
            int frequency;
            Dictionary<string, int> TermFrequencyCopy = new Dictionary<string, int>(TermFrequency);
            foreach (var item in TermFrequencyCopy)
            {
                originalTerm = item.Key;
                frequency = item.Value;
                string stem = porterStemmer.StemWord(originalTerm);
                if (!stem.Equals(originalTerm))
                {
                    // if the stem already exists in the dictionary, combine its frequency with existing frequency
                    if (ExistsInTermFrequency(stem))
                    {
                        IncreaseTermFrequency(stem, frequency);
                    }
                    else
                    {
                        // else, add new stem word and frequency to dictionary
                        AddStemWordToTermFrequency(stem, frequency);
                    }

                    // remove the original term from the dictionary
                    RemoveTerm(originalTerm);
                }
            }

            // print out terms and frequency in descending order
            foreach (var item in TermFrequency.OrderByDescending(key => key.Value).Take(20))
            {
                Console.WriteLine($"Term: {item.Key}, Frequency: {item.Value}");
            }

            Console.WriteLine();
        }
    }
}