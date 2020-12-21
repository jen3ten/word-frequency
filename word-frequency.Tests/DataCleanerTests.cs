using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace word_frequency.Tests
{
    public class DataCleanerTests
    {
        public DataCleaner sut;
        public DataCleanerTests()
        {
            sut = new DataCleaner();
        }

        [Fact]
        public void TrimListStrings_Should_Remove_Leading_And_Trailing_Spaces()
        {
            List<string> testList = new List<string> { "  one", " two ", "three  ", "four" };
            List<string> expectedList = new List<string> { "one", "two", "three", "four" };

            Assert.Equal(expectedList, sut.TrimListStrings(testList));
        }

    }
}
