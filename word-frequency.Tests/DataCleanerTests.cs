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
        public DataCleanerTests()
        {
            testString = " One ";
        }

        [Fact]
        public void TrimString_Should_Remove_Leading_And_Trailing_Spaces()
        {
            expectedString = "One";

            Assert.Equal(expectedString, DataCleaner.TrimString(testString));
        }

        [Fact]
        public void StringToLowerCase_Should_Remove_All_Upper_Case_Letters()
        {
            expectedString = " one ";

            Assert.Equal(expectedString, DataCleaner.StringToLowerCase(testString));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Return_String_Array()
        {
            DataCleaner.Delimiters = new char[] { };

            Assert.IsType<string[]>(DataCleaner.SplitStringAtDelimiters(""));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Split_And_Remove_WhiteSpace()
        {
            string testString = " One two  Three";
            DataCleaner.Delimiters = new char[] { ' ' };
            string[] expectedArray = { "One", "two", "Three"};

            Assert.Equal(expectedArray, DataCleaner.SplitStringAtDelimiters(testString));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Split_At_Multiple_Delimiters()
        {
            string testString = " One--two  Three,four five six-seven";
            DataCleaner.Delimiters = new char[] { ' ', '-', ',' };
            string[] expectedArray = { "One", "two", "Three", "four", "five", "six", "seven" };

            Assert.Equal(expectedArray, DataCleaner.SplitStringAtDelimiters(testString));
        }

        [Fact]
        public void TrimCharactersFromString_Should_Remove_Question_Mark_From_Lead_and_Trail_Of_String()
        {
            string testString = "hello?";
            char[] testCharacters = { '?'};
            expectedString = "hello";

            Assert.Equal(expectedString, DataCleaner.TrimCharactersFromString(testString, testCharacters));
        }
    }
}
