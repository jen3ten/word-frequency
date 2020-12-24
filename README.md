# Word Frequency Counter

## Purpose

This C# console app is a text normalization tool that will print the 20 most commonly occuring terms for a given text file, in descending order of frequency. 

See [NLP, AI, and Machine Learning: What's the Difference?](https://monkeylearn.com/blog/nlp-ai/#:~:text=Natural%20Language%20Processing%20(NLP)%20is,grammar%20checking%2C%20or%20topic%20classification.) for more information about how computers can be used to understand human language in order to interact more effectively with customers or automate tasks.  

## Requirements

The application reads in a text file, removes stop words, removes all non-alphabetical text, stems words into their root form , computes the frequency of each term, and prints out the 20 most commonly occurring terms in descending order of frequency.

### Data Files

This application normalizes text and prints frequency of terms for:
- [Text1- Declaration of Independence](./word-frequency/Data/Text1.txt)
- [Text2- Alice in Wonderland](./word-frequency/Data/Text2.txt)

### Stop Words

The list of stop words is contained in the [stop words text file](./word-frequency/Data/stopwords.txt).  Stop words, such as 'I', 'they', 'have', 'like', 'yours', etc., will be removed because they don’t add any semantic value and are unlikely to be useful.

### Stemming Algorithm

The common [Porter Stemming Algorithm](https://tartarus.org/martin/PorterStemmer/) has been used in this application. Stemming is a process for removing the suffix from a word and reducing it to its root word. Its main use is as part of a term normalisation process that is usually done when setting up Information Retrieval systems.

Specifically, the [Csharp encoding by Brad Patton](https://tartarus.org/martin/PorterStemmer/csharp3.txt) has been used in this application.

For more information about stemming, see [NLP: A quick guide to Stemming](https://medium.com/@tusharsri/nlp-a-quick-guide-to-stemming-60f1ca5db49e)

## Design Decisions and Assumptions

### Prioritization

The solution has been designed for:
- Correctness: It fulfills the requirements and all logic has been verified through unit testing using the xUnit unit testing framework.
- Maintainability: It is easy to understand and maintain.
- Performance: It completes the tasks quickly.

### Process Order
 
- ### Split Text into Words and Remove Non-Alphabetical Text

The text file was split into an array of words using non-alphabetic text as the delimiter.  The delimiter has been removed in the process.

With this process, all non-alphabetic text, except for apostrophes, have been removed.  Non-alphabetic text includes any characters not found in the a-z or A-Z character sets, such as numbers (0-9), punctuation, and special characters.  

An apostrophe typically represents a possessive ("Alice's" or "girl's") or contraction ("he'll" is a contraction of "he will") and exist within a word.  Apostrophes cannot be used as a split delimiter because it will create non-sense words.  Many contractions exist in the stop word list, and will be removed with the stop words.  Any remaining apostrophes will be removed later.   

- ### Remove Apostrophes

Single apostrophes, leading and trailing apostrophes, possessives, and some contractions were removed based on the use and position of the apostrophe within the word.

- ### Add Words and Frequency to Dictionary 

The application then iterated through the array of words and added the words to a dictionary.  The string word is the 'key' and the integer count of the word's frequency is the 'value'.  This process created a collection of non-duplicated words and their frequency.  

By converting the large array of words into a dictionary first, the array of words is only iterated once.  Future manipulations of the collection, for removal of stop words or stemming, will occur more quickly by looking up words in the efficient and smaller dictionary.

- ### Remove Stop Words

Stop word removal was performed before stemming, so that words like 'was' don't turn into 'wa' by the Porter stemmer. 

- ### Stemming

The Porter Stemming algorithm was then used to convert words to their stem.  If the word changed, the dictionary was checked for the stem's existence.  If the stem already existed, it was combined with its match.  If it didn't exist, it was removed from the dictionary, and re-added as a new term.

## Running the Application

To run the application, please clone this project to your machine.  Open it in Visual Studio and run the application.  A user menu will appear with directions.  You will be prompted to enter the file path for the `word-frequency` application.

## Results

The result of running the normalization process and determing the frequency of each term can be found in the following files:
- [Text1- Declaration of Independence Terms & Frequency](./word-frequency/Data/Text1frequency.txt)
- [Text2- Alice in Wonderland Terms & Frequency](./word-frequency/Data/Text2frequency.txt)
