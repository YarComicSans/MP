using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MillionereClassLibrary
{
    public class QuestionStructure  // Need to come up with an idea how to link GET functions
    {
        public readonly string CorrectAnswer;
        public string Question { get; set; }
        public List<string> Answers { get; set; }

        public QuestionStructure(string structuredQuestion)
        {
            Question = GetQuestion(structuredQuestion);
            Answers = GetAnswers(structuredQuestion);
            CorrectAnswer = GetCorrectAnswer(structuredQuestion);
        }

        private string GetQuestion(string text)
        {
            string pattern = @"<q>(.*?)</q>";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);

            return match.Success ? match.Value : "Haven't load the question";
        }

        private List<string> GetAnswers(string text)
        {
            string pattern = @"<a>(.*?)</a>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            List<string> answers = new List<string>();

            foreach (Match match in matches)
            {
                answers.Add(match.Value);    
            }

            return answers;
        }

        private string GetCorrectAnswer(string text)
        {
            string pattern = @"<correct>(.*?)</correct>";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(text);

            return match.Success ? match.Value : "Haven't load the correct answer";
        }

    }
}
