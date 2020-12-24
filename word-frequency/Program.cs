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
            string applicationLocation;
            string stopWordsDataFile = "stopwords.txt";
            string text1DataFile = "Text1.txt";
            string text2DataFile = "Text2.txt";
            string delimitersDataFile = "delimiters.txt";

            List<string> stopWords = new List<string>();
            string text1Data;
            string text2Data;

            Console.WriteLine("TEXT NORMALIZATION AND TERM FREQUENCY FINDER\n");
            Console.WriteLine("This application reads in a text file, removes stop words, removes all non-alphabetical text, stems words into their root form using the Porter stemmer, computes the frequency of each term, and prints out the 20 most commonly occurring terms in descending order of frequency.\n");
            Console.WriteLine("The input files are:");
            Console.WriteLine("- (text1.txt) The Declaration of Independence");
            Console.WriteLine("- (text2.txt) Alice in Wonderland\n");
            Console.Write("Please enter the file path for this application, for example 'C:/Users/jenev/source/repos': ");
            applicationLocation = Console.ReadLine();
            Console.WriteLine();
            string filePath = applicationLocation + "/word-frequency/word-frequency/Data/";

            DataReader reader = new DataReader(filePath);
            DataCleaner cleaner = new DataCleaner();

            bool incorrectPath = true;
            do
            {
                // create a string list of stop words
                if (reader.DefineStream(stopWordsDataFile))
                {
                    stopWords = reader.ConvertTextFileToList(reader.Stream);
                    incorrectPath = false;
                }
                else
                {
                    Console.Write("\nThe provided file path is inaccessible.  Please enter a correct file path: ");
                    applicationLocation = Console.ReadLine();
                    Console.WriteLine();
                    filePath = applicationLocation + "/word-frequency/word-frequency/Data/";
                    reader = new DataReader(filePath);
                }
            } while (incorrectPath);

            // create a char array of delimiters
            if (reader.DefineStream(delimitersDataFile))
            {
                cleaner.CreateDelimiterArrayFromTextFile(reader.Stream);
            }

            Console.Clear();
            bool showMenu = true;
            do
            {
                Console.WriteLine("TEXT NORMALIZATION AND TERM FREQUENCY FINDER\n");
                Console.WriteLine("1. View text for Declaration of Independence");
                Console.WriteLine("2. View text for Alice in Wonderland");
                Console.WriteLine("3. Show term frequency for Declaration of Independence");
                Console.WriteLine("4. Show term frequency for Alice in Wonderland");
                Console.WriteLine("5. Exit");
                Console.Write("\nPlease enter a menu option: ");
                string menuOption = Console.ReadLine();
                Console.Clear();

                switch (menuOption)
                {
                    case "1":
                        Console.WriteLine("DECLARATION OF INDEPENDENCE:\n");
                        if (reader.DefineStream(text1DataFile))
                        {
                            text1Data = reader.ConvertTextFileToString(reader.Stream);
                            Console.WriteLine(text1Data);
                        }
                        break;
                    case "2":
                        Console.WriteLine("ALICE IN WONDERLAND:\n");
                        if (reader.DefineStream(text2DataFile))
                        {
                            text2Data = reader.ConvertTextFileToString(reader.Stream);
                            Console.WriteLine(text2Data);
                        }
                        break;
                    case "3":
                        Console.WriteLine("TOP 20 TERMS FOR DECLARATION OF INDEPENDENCE:\n");
                        if (reader.DefineStream(text1DataFile))
                        {
                            text1Data = reader.ConvertTextFileToString(reader.Stream);
                            string[] text1Words = cleaner.SplitStringAtDelimiters(text1Data);

                            cleaner.GetTermFrequencyFromStringArray(text1Words, stopWords);
                        }
                        break;
                    case "4":
                        Console.WriteLine("TOP 20 TERMS FOR ALICE IN WONDERLAND:\n");
                        if (reader.DefineStream(text2DataFile))
                        {
                            text2Data = reader.ConvertTextFileToString(reader.Stream);
                            string[] text2Words = cleaner.SplitStringAtDelimiters(text2Data);

                            cleaner.GetTermFrequencyFromStringArray(text2Words, stopWords);
                        }
                        break;
                    case "5":
                        Console.WriteLine("Good-bye");
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Menu selection was invalid.  Please try again.\n");
                        break;
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();

            } while (showMenu);
        }
    }
}
