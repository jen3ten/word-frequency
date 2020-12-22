# Word Frequency Counter

## Purpose

This C# console app will print the 20 most commonly occuring terms for a given text file, in descending order of frequency.

## Requirements

It reads in a text file, removes stop words, removes all non-alphabetical text, stems words into their root form , computes the frequency of each term, and prints out the 20 most commonly occurring terms in descending order of frequency. 

### Stop Words

The list of “stop words” is contained in “stopwords.txt”.

### Stemming Algorithm

The [Porter Stemming Algorithm](https://tartarus.org/martin/PorterStemmer/) has been used.  It is a process for removing the commoner morphological and inflexional endings from words in English. Its main use is as part of a term normalisation process that is usually done when setting up Information Retrieval systems.

Specifically, the [Csharp encoding by Brad Patton](https://tartarus.org/martin/PorterStemmer/csharp3.txt) has been used in this application.

## Design Decisions

The solution has been designed for:
- Correctness: It fulfills the requirements and all logic has been verified through unit testing using the xUnit unit testing framework.
- Maintainability: It is easy to understand and maintain.
- Performance: It completes the tasks quickly.

## Assumptions

### Removal of Non-Alphabetical Text

All non-alphabetic text has been removed.  Non-alphabetic text includes numbers (0-9), punctuation, and special characters.  

See Stemming for explanation of how dashes (-), double dashes (--), and possessive ('s) were handled.

### Stemming

