using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MillionereClassLibrary
{
    [Serializable]
    public class QuestionStructure  // Need to come up with an idea how to link GET functions
    {
        public string CorrectAnswer;
        public string Question { get; set; }
        public List<string> Answers { get; set; }

        public QuestionStructure(string structuredQuestion)
        {
            Question = GetQuestion(structuredQuestion);
            Answers = GetAnswers(structuredQuestion);
            CorrectAnswer = GetCorrectAnswer(structuredQuestion);
        }

        public QuestionStructure()
        { }

        private string GetValue(string text, int pos, int removeLength)
        {
            return text.Substring(pos, text.Length - removeLength);
        }

        private string GetQuestion(string text)
        {
            string pattern = @"<Name>(.*?)</Name>";
            var regex = new Regex(pattern);
            var match = regex.Match(text);

            return match.Success ? GetValue(match.Value, 6, 13) : "Haven't load the question";
        }

        private List<string> GetAnswers(string text)
        {
            if (Answers != null)
                return Answers;
            string pattern = @"<Text>(.*?)</Text>";
            var regex = new Regex(pattern);
            var matches = regex.Matches(text);
            var answers = new List<string>();

            foreach (Match match in matches)
            {
                answers.Add(GetValue(match.Value,6,13));
            }

            return answers;
        }

        private string GetCorrectAnswer(string text)
        {
            string pattern = @"<CorrectAnswer>(.*?)</CorrectAnswer>";
            var regex = new Regex(pattern);
            var match = regex.Match(text);

            return match.Success ? GetValue(match.Value,15,31) : "Haven't load the correct answer";
        }

        public void RemoveAnswers(List<string> answers)
        {
            foreach (var answer in answers)
            {
                if (Answers.Contains(answer))
                    Answers.Remove(answer);
            }
        }
    }
}
