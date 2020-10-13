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
            if (message.ToUpper().Contains("SAD"))
            {
                return "SAD";
            }
            if (message.ToUpper().Contains("HAPPY"))
            {
                return "HAPPY";
            }
            return "";
        }
    }
}