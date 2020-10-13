using System;

namespace MoodAnalyzerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Mood Analyzer Program");

            Console.WriteLine("Enter the message");
            string message = Console.ReadLine();

            MoodAnalyzer moodAnalyser = new MoodAnalyzer(message);
            Console.WriteLine("The mood is :" + moodAnalyser.AnalyseMood());
        }
    }
}
