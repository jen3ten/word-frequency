using System;
using System.Security.Authentication;
using Xunit;

namespace word_frequency.Tests
{
    public class DataReaderTests
    {
        public DataReader sut;
        public DataReaderTests()
        {
            sut = new DataReader("C:/Users/jenev/source/repos/CleFedReserveBank/word-frequency/word-frequency.Tests/TestData/");
        }

        [Fact]
        public void ConvertTextFileToString_Should_Return_String_Type()
        {
            Assert.IsType<string>(sut.ConvertTextFileToString("TestFile1.txt"));
        }

        [Fact]
        public void DefineStream_Should_Return_True_If_File_Successfully_Read()
        {
            Assert.True(sut.DefineStream("TestFile1.txt"));
        }
    }
}
