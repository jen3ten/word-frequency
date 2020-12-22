using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace word_frequency.Tests
{
    public class DataCleanerTests
    {
        private string testString;
        private string testString2;
        private string expectedString;
        public DataCleanerTests()
        {
            testString = " One ";
            testString2 = " One two  Three";
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
            Assert.IsType<string[]>(DataCleaner.SplitStringAtDelimiters(""));
        }

        [Fact]
        public void SplitStringAtDelimiters_Should_Split_And_Remove_WhiteSpace()
        {
            string[] expectedArray = { "One", "two", "Three"};
            Assert.Equal(expectedArray, DataCleaner.SplitStringAtDelimiters(testString2));
        }


    }
}
