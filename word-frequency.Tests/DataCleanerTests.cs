using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace word_frequency.Tests
{
    public class DataCleanerTests
    {
        private DataCleaner sut;
        private List<string> testList; 
        public DataCleanerTests()
        {
            sut = new DataCleaner();
            testList = new List<string> { "  One", " tWo ", "THREE  ", "four" };
        }

        [Fact]
        public void TrimListStrings_Should_Remove_Leading_And_Trailing_Spaces()
        {
            List<string> expectedList = new List<string> { "One", "tWo", "THREE", "four" };

            Assert.Equal(expectedList, sut.TrimListStrings(testList));
        }

        [Fact]
        public void ListItemsToLowerCase_Should_Remove_All_Upper_Case_Letters()
        {
            List<string> expectedList = new List<string> { "  one", " two ", "three  ", "four" };

            Assert.Equal(expectedList, sut.ListItemsToLowerCase(testList));

        }

    }
}
