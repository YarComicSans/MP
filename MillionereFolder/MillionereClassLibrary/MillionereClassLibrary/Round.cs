using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionereClassLibrary.Hints;

namespace MillionereClassLibrary
{
     public class Round
    {
        private QuestionStructure _currentQuestionStructure;
        private readonly Player _currentPlayer;

        public Round(Player player, QuestionStructure questionStructure)
        {
            _currentPlayer = player;
            _currentQuestionStructure = questionStructure;
        }

        public void ChangeCurrectQuestionStructure(QuestionStructure questionStructure)
        {
            _currentQuestionStructure = questionStructure;
        }
        public bool CheckAnswer(string chosenAnswer)
        {
            if(chosenAnswer == _currentQuestionStructure.CorrectAnswer)
                return true;
            return false;
        }

        public string GetQuestion()
        {
            return _currentQuestionStructure.Question;
        }

        public List<string> GetAnswers()
        {
            return _currentQuestionStructure.Answers;
        }

        public List<Hint> GetAvalibaleHints()
        {
            return _currentPlayer.GetAvailableHints();
        }
        public List<string> UseHint(Hint hint, List<string> answers, string correctAnswer, int requiredProbability = 0)
        {
            return hint.CalculateAnswer(answers,correctAnswer,requiredProbability);
        }

    }
}
