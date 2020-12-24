using System;
using System.Collections.Generic;
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
        public void DefineStream_Should_Return_True_If_File_Successfully_Read()
        {
            Assert.True(sut.DefineStream("TestFile1.txt"));
        }

        [Fact]
        public void DefineStream_Should_Return_False_If_File_Cannot_Be_Read()
        {
            Assert.False(sut.DefineStream(""));
        }

        [Fact]
        public void ConvertTextFileToString_Should_Return_String_Type()
        {
            sut.DefineStream("TestFile1.txt");

            Assert.IsType<string>(sut.ConvertTextFileToString(sut.Stream));
        }

        [Fact]
        public void ConvertTextFileToList_Should_Return_List_Type()
        {
            sut.DefineStream("TestFile1.txt");

            Assert.IsType<List<string>>(sut.ConvertTextFileToList(sut.Stream));
        }
    }
}
