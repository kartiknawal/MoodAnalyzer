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
                Assert.AreEqual("Constructor Not Found", e.Message);
            }
        }

        [TestMethod]
        public void Given_ProperMessage_To_MoodAnalyse_ShouldReturn_MoodAnalyseObject()
        {
            object expected = new MoodAnalyzer("HAPPY");
            object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerProject.MoodAnalyzer", "MoodAnalyzer", "I am in Happy Mood");
            expected.Equals(obj);
        }
        [TestMethod]
        public void Given_ProperMessage_ButImproperMoodAnalyseClassName_Should_throw_MoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerProject.MoodAnalyyzzer", "MoodAnalyyzzer", "I am in Happy Mood");
                expected.Equals(obj);
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Class Not Found", e.Message);
            }
        }
        [TestMethod]
        public void Given_ProperMessage_But_ImproperMoodAnalyseConstructor_Should_throw_MoodAnalysisException()
        {
            try
            {
                object expected = new MoodAnalyzer();
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerProject.MoodAnalyzer", "MoodAnalyyzzer", "I am in Happy Mood");
                expected.Equals(obj);
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Constructor Not Found", e.Message);
            }
        }
        [TestMethod]
        public void Given_HappyMood_UsingReflection_When_Proper_Should_Return_Happy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyzerRecflector.InvokeAnalyzeMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }
        [TestMethod]
        public void Given_HappyMessage_But_ImproperMethod_Should_throw_MoodAnalysisException()
        {
            try
            {
                string expected = "HAPPY";
                string mood = MoodAnalyzerRecflector.InvokeAnalyzeMood("Happy", "AnalyyzeMood");
                expected.Equals(mood);
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Method Not Found", e.Message);
            }
        }

        [TestMethod]
        public void Given_HappyMessageWithReflector_Should_Return_Happy()
        {
            string expected = "HAPPY";
            string result = MoodAnalyzerRecflector.SetField("HAPPY", "message");
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Given_HappyMessageImproperField_Should_Throw_MoodAnalysisCustomException()
        {
            try
            {
                string result = MoodAnalyzerRecflector.SetField("HAPPY", "any");
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Field not found", e.Message);
            }
        }
        [TestMethod]
        public void Given_NullMessageWithReflection_Should_Throw_MoodAnalysisCustomException()
        {
            try
            {
                string message = null;
                string result = MoodAnalyzerRecflector.SetField(message, "message");
            }
            catch (MoodAnalysisCustomException e)
            {
                Assert.AreEqual("Message should not be null", e.Message);
            }
        }
    }
}