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
            Assert.IsType<string[]>(DataCleaner.SplitStringAtDelimiters("", new char[] { }));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Split_And_Remove_WhiteSpace()
        {
            string testString = " One two  Three";
            string[] expectedArray = { "One", "two", "Three"};

            Assert.Equal(expectedArray, DataCleaner.SplitStringAtDelimiters(testString, new char[] {' '}));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Split_At_Multiple_Delimiters()
        {
            string testString = " One--two  Three,four five six-seven";
            char[] testDelimiters = { ' ', '-', ',' };
            string[] expectedArray = { "One", "two", "Three", "four", "five", "six", "seven" };

            Assert.Equal(expectedArray, DataCleaner.SplitStringAtDelimiters(testString, testDelimiters));
        }

        [Fact]
        public void RemoveStopWord_Should_Remove_One_Word_From_String()
        {
            string testString = "this isn't a stop word";
            string stopWord = "isn't";
            expectedString = "this  a stop word";

            Assert.Equal(expectedString, DataCleaner.RemoveStopWord(testString, stopWord));
        }

        [Fact]
        public void RemoveStopWord_Should_Remove_One_Word_From_String_Ignoring_Case()
        {
            string testString = "this isn't a stop word";
            string stopWord = "Isn't";
            expectedString = "this  a stop word";

            Assert.Equal(expectedString, DataCleaner.RemoveStopWord(testString, stopWord));
        }

    }
}
