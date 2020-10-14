using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProject;

namespace MoodAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_I_am_sad_When_AnalyseMood_Sould_return_Sad()
        {
            string message = "I am in a sad mood";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);

            string result = moodAnalyser.AnalyseMood();

            Assert.AreEqual("SAD", result);
        }
        [TestMethod]
        public void Given_I_am_happy_When_AnalyseMood_Sould_return_Happy()
        {
            string message = "I am in a happy mood";
            MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);

            string result = moodAnalyser.AnalyseMood();

            Assert.AreEqual("HAPPY", result);
        }
        
        [TestMethod]
        public void Given_NULL_Mood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string message = null;
                MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);
                string mood = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Mood cannot be null", e.Message);
            }

        }
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string message = "";
                MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);
                string mood = moodAnalyser.AnalyseMood();
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Mood cannot be empty", e.Message);
            }

        }
    }
}