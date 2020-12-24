using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace word_frequency.Tests
{
    public class DataCleanerTests
    {
        private string testString;
        private string expectedString;
        private DataCleaner sut;

        public DataCleanerTests()
        {
            testString = " One ";
            sut = new DataCleaner();
            sut.TermFrequency = new Dictionary<string, int>();
        }

        [Fact]
        public void TrimString_Should_Remove_Leading_And_Trailing_Spaces()
        {
            expectedString = "One";

            Assert.Equal(expectedString, sut.TrimString(testString));
        }

        [Fact]
        public void StringToLowerCase_Should_Remove_All_Upper_Case_Letters()
        {
            expectedString = " one ";

            Assert.Equal(expectedString, sut.StringToLowerCase(testString));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Return_String_Array()
        {
            sut.Delimiters = new char[] { };

            Assert.IsType<string[]>(sut.SplitStringAtDelimiters(""));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Split_And_Remove_WhiteSpace()
        {
            string testString = " One two  Three";
            sut.Delimiters = new char[] { ' ' };
            string[] expectedArray = { "One", "two", "Three"};

            Assert.Equal(expectedArray, sut.SplitStringAtDelimiters(testString));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Split_At_Multiple_Delimiters()
        {
            string testString = " One--two  Three,four five six-seven";
            sut.Delimiters = new char[] { ' ', '-', ',' };
            string[] expectedArray = { "One", "two", "Three", "four", "five", "six", "seven" };

            Assert.Equal(expectedArray, sut.SplitStringAtDelimiters(testString));
        }

        [Fact]
        public void TrimCharactersFromString_Should_Remove_Question_Mark_From_Lead_and_Trail_Of_String()
        {
            string testString = "hello?";
            char[] testCharacters = { '?'};
            expectedString = "hello";

            Assert.Equal(expectedString, sut.TrimCharactersFromString(testString, testCharacters));
        }

        [Fact]
        public void ExistsInTermFrequency_Should_Return_False_If_Dictionary_Is_Empty()
        {
            sut.TermFrequency = null;
            string testString = "hello";

            Assert.False(sut.ExistsInTermFrequency(testString));
        }

        [Fact]
        public void ExistsInTermFrequency_Should_Return_False_If_Term_Does_Not_Exist_In_Dictionary()
        {
            sut.TermFrequency.Add("hello", 1);
            string testString = "welcome";

            Assert.False(sut.ExistsInTermFrequency(testString));
        }

        [Fact]
        public void ExistsInTermFrequency_Should_Return_True_If_Term_Exists_In_Dictionary_Of_One_Element()
        {
            sut.TermFrequency.Add("hello", 1);
            string testString = "hello";

            Assert.True(sut.ExistsInTermFrequency(testString));
        }

        [Fact]
        public void ExistsInTermFrequency_Should_Return_True_If_Term_Found_Regardless_Of_Case()
        {
            sut.TermFrequency.Add("welcome", 10);
            sut.TermFrequency.Add("hello", 1);
            sut.TermFrequency.Add("name", 4);
            sut.TermFrequency.Add("Bob", 2);
            string testString = "Hello";

            Assert.True(sut.ExistsInTermFrequency(testString));
        }

        [Fact]
        public void ExistsInTermFrequency_Should_Return_True_If_Term_Exists_In_Dictionary()
        {
            sut.TermFrequency.Add("welcome", 10);
            sut.TermFrequency.Add("hello", 1);
            sut.TermFrequency.Add("name", 4);
            sut.TermFrequency.Add("Bob", 2);
            string testString = "hello";

            Assert.True(sut.ExistsInTermFrequency(testString));
        }

        [Fact]
        public void AddTermToTermFrequency_Should_Add_New_Key()
        {
            sut.TermFrequency = new Dictionary<string, int>() { {"hello", 1} };
            string testString = "welcome";

            sut.AddTermToTermFrequency(testString);

            Assert.True(sut.ExistsInTermFrequency(testString));
        }

        [Fact]
        public void AddTermToTermFrequency_Should_Add_New_Key_In_Lower_Case()
        {
            sut.TermFrequency = new Dictionary<string, int>() { { "hello", 1 } };
            string testString = "Welcome";
            string testStringLowerCase = "welcome";

            sut.AddTermToTermFrequency(testString);

            Assert.True(sut.ExistsInTermFrequency(testStringLowerCase));
        }

        [Fact]
        public void AddTermToTermFrequency_Should_Have_Frequency_Of_1()
        {
            sut.TermFrequency = new Dictionary<string, int>() { {"hello", 1} };
            string testString = "welcome";
            int frequency;

            sut.AddTermToTermFrequency(testString);
            sut.TermFrequency.TryGetValue(testString, out frequency);

            Assert.Equal(1, frequency);
        }

        [Fact]
        public void IncreaseTermFrequency_Should_Add_1_To_Frequency()
        {
            sut.TermFrequency = new Dictionary<string, int>() { {"hello", 1} };
            string testTerm = "hello";

            sut.IncreaseTermFrequency(testTerm, 1);

            Assert.Equal(2, sut.TermFrequency[testTerm]);
        }

        [Fact]
        public void IncreaseTermFrequency_Should_Add_1_To_Frequency_Regardless_Of_Case()
        {
            sut.TermFrequency = new Dictionary<string, int>() { { "hello", 1 } };
            string testTerm = "Hello";

            sut.IncreaseTermFrequency(testTerm, 1);

            Assert.Equal(2, sut.TermFrequency["hello"]);
        }


        [Fact]
        public void IncreaseTermFrequency_Should_Add_Value_Of_Duplicate_Term_To_Frequency()
        {
            sut.TermFrequency = new Dictionary<string, int>() {
                {"greet", 1},
                {"greeting", 3}};
            string term = "greet";
            int frequencyOfDuplicate = sut.TermFrequency["greeting"];

            sut.IncreaseTermFrequency(term, frequencyOfDuplicate);

            Assert.Equal(4, sut.TermFrequency[term]);
        }

        [Fact]
        public void RemoveDuplicateTerm_Should_Remove_Term_From_Dictionary()
        {
            sut.TermFrequency = new Dictionary<string, int>() {
                {"greet", 1},
                {"greeting", 3}};
            string duplicateTerm = "greeting";

            sut.RemoveDuplicateTerm(duplicateTerm);

            Assert.False(sut.ExistsInTermFrequency(duplicateTerm)); ;
        }

        [Fact]
        public void RemoveStopWord_Should_Remove_Stop_Word_From_Dictionary()
        {
            sut.TermFrequency = new Dictionary<string, int>() {
                {"greet", 1},
                {"and", 12}};
            string stopWord = "and";

            sut.RemoveStopWord(stopWord);

            Assert.False(sut.ExistsInTermFrequency(stopWord)); ;
        }

        [Fact]
        public void RemoveStopWord_Should_Remove_Stop_Word_From_Dictionary_Regardless_Of_Case()
        {
            sut.TermFrequency = new Dictionary<string, int>() {
                {"greet", 1},
                {"and", 12}};
            string stopWord = "And";

            sut.RemoveStopWord(stopWord);

            Assert.False(sut.ExistsInTermFrequency(stopWord.ToLower())); ;
        }

    }
}
