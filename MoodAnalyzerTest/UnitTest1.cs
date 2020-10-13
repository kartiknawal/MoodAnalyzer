using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProject;

namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1Case1()
        {
            string message = "I am in a sad mood";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);

            string result = moodAnalyser.AnalyseMood();

            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        public void Test1Case2()
        {
            string message = "I am in a happy mood";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);

            string result = moodAnalyser.AnalyseMood();

            Assert.AreEqual("HAPPY", result);
        }
    }
}