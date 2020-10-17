using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProject;
using System;

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
        [TestMethod]
        public void Given_MoodAnalyzerClassName_ShouldReturn_MoodAnalyzerObject()
        {
            object expected = new MoodAnalyzer();
            object obj = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerProject.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }
        [TestMethod]
        public void Given_MoodAnalyzerClassName_ShouldReturn_WrongClassException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object obj = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerProject.MoodAnalyyzer", "MoodAnalyyzer");
                expected.Equals(obj);
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Class Not Found", e.Message);
            }
        }

        [TestMethod]
        public void Given_ImproperMoodAnalyseConstructor_ShouldReturn_MoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object obj = MoodAnalyzerFactory.CreateMoodAnalyse("MoodAnalyzerProject.MoodAnalyzer", "MoodAnalyyzerr");
                expected.Equals(obj);
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Constructor is Not Found", e.Message);
            }
        }

    }
}