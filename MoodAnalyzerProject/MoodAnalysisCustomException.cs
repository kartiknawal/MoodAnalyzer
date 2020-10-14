using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProject
{
    public class MoodAnalysisCustomException:Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE
        }
        ExceptionType type;
        public MoodAnalysisCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
