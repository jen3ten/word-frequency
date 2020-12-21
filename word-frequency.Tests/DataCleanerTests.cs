using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace word_frequency.Tests
{
    public class DataCleanerTests
    {
        private DataCleaner sut;
        private string testString;
        private string expectedString;
        public DataCleanerTests()
        {
            sut = new DataCleaner();
            testString = " One ";
        }

        [Fact]
        public void TrimString_Should_Remove_Leading_And_Trailing_Spaces()
        {
            expectedString = "One";

            Assert.Equal(expectedString, sut.TrimString(testString));
        }

        [Fact]
        public void ListItemsToLowerCase_Should_Remove_All_Upper_Case_Letters()
        {
            expectedString = " one ";

            Assert.Equal(expectedString, sut.ListItemsToLowerCase(testString));

        }

    }
}
