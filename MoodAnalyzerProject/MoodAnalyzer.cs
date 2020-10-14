using System;
using System.Collections;
using System.Text;

namespace MoodAnalyzerProject
{
    public class MoodAnalyzer
    {
        string message;

        public MoodAnalyzer()
        {
            message = "";
        }
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public string AnalyseMood()
        {
            try
            {
                if (message == "")
                {
                    throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.EMPTY_MESSAGE, "Mood cannot be empty");
                }
                if (message.ToUpper().Contains("SAD"))
                {
                    return "SAD";
                }
                return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisCustomException(MoodAnalysisCustomException.ExceptionType.NULL_MESSAGE, "Mood cannot be null");
            }
        }
    }
}