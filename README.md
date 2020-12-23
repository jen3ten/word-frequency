# Word Frequency Counter

## Purpose

This C# console app is a text extraction tool that will print the 20 most commonly occuring terms for a given text file, in descending order of frequency. 

See [NLP, AI, and Machine Learning: What's the Difference?](https://monkeylearn.com/blog/nlp-ai/#:~:text=Natural%20Language%20Processing%20(NLP)%20is,grammar%20checking%2C%20or%20topic%20classification.) for more information about how computers can be used to understand human language in order to interact more effectively with customers or automate tasks.  

## Requirements

It reads in a text file, removes stop words, removes all non-alphabetical text, stems words into their root form , computes the frequency of each term, and prints out the 20 most commonly occurring terms in descending order of frequency. 

### Stop Words

The list of stop words is contained in `stopwords.txt`.  Stop words, such as 'I', 'they', 'have', 'like', 'yours', etc., will be removed because they don’t add any semantic value and are unlikely to be useful.

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

An apostrophe typically represents a possessive ("Alice's" or "girl's") or contraction ("he'll" is a contraction of "he will").  Many contractions exist in the stop word list, and will be removed with the stop words.  Other contractions are less frequent and will remain.   

- ### Add Words and Frequency to Dictionary 

Iterate through the array of words and add the words to a dictionary.  The string word is the 'key' and the integer count of the word's frequency is the 'value'.  This process creates a collection of non-duplicated words and their frequency.  

By converting the large array of words into a dictionary first, the array of words is only iterated once.  Future manipulations of the collection, for removal of stop words or stemming, will occur more quickly by looking up words in the efficient and smaller dictionary.

- ### Stop Word Removal

Stop word removal was performed before stemming, so that words like 'was' don't turn into 'wa' by the Porter stemmer. 

- ### Stemming

