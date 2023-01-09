using System.IO;
using System.Linq;
using Xunit;
using Day_7;
using System;

namespace Day_7.Tests
{
    public class UnitTest1
    {
        public string[] GetData()
        {
            var _filepath = "../../../../day_07_test_data.txt";
            return File.ReadAllLines(_filepath).ToArray();
        }
    
        [Fact]
        public void Test1()
        {
            var data = GetData();
            var dictionary = new DirectoryDictionary();
            var mainDirectory = dictionary.Create(data);
            var list = dictionary.GetDirectoriesSize().ToArray();
            foreach (var item in list)
                Console.WriteLine(item);
            ;
            Assert.Equal(list[0], 94853);
            Assert.Equal(list[1], 24933642);
            Assert.Equal(list[2], 584);
        }
    }
}