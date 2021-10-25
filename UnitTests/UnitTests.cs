using DataProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethodCountForces()
        {
            var reader = new DataReader();
            reader.FileName = "police_101_call_test_data.csv";
            reader.ReadData();
            var expected = 8;
            var result = reader.NumberOfForces;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethodAverageCalls()
        {
            var reader = new DataReader();
            reader.FileName = "police_101_call_test_data.csv";
            reader.ReadData();
            var expected = 27870;
            var result = reader.AverageTotalCalls;
            Assert.AreEqual(expected, result);
        }
    }
}
