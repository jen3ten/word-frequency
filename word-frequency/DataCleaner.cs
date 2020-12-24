﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace word_frequency
{
    public class DataCleaner
    {
        public char[] Delimiters { get; set; }
        public Dictionary<string, int> TermFrequency {get; set;}

        public DataCleaner()
        {
            TermFrequency = new Dictionary<string, int>();
        }

        public string TrimString(string dataString)
        {
            return dataString.Trim();
        }

        public string StringToLowerCase(string dataString)
        {
            return dataString.ToLower();
        }

        public string TrimCharactersFromString(string dataString, char[] trimmedCharacters)
        {
            return dataString.Trim(trimmedCharacters);
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

        //public static string[] SplitStringAtDelimiters(string dataString, char[] delimiters)
        //{
        //    string[] dataArray = dataString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        //    return dataArray;
        //}

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
            TermFrequency.Add(term.ToLower(), 1);
        }

        public void IncreaseTermFrequency(string term, int increaseFrequency)
        {
            TermFrequency[term.ToLower()] += increaseFrequency;
        }

        public void RemoveDuplicateTerm(string term)
        {
            TermFrequency.Remove(term);
        }
    }
}
