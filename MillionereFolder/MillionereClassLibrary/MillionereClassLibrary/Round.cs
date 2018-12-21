using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillionereClassLibrary.Hints;
using System.Xml.Serialization;

namespace MillionereClassLibrary
{
    [Serializable]
     public class Round
    {
        public QuestionStructure _currentQuestionStructure;
        public Player _currentPlayer;
        public HintsUsage UsedHints = new HintsUsage();

        public Round(Player player, QuestionStructure questionStructure)
        {
            _currentPlayer = player;
            _currentQuestionStructure = questionStructure;
        }

        public Round()
        { }

        public void SetCallHintsPosition(int position)
        {
            UsedHints.CallFriendPosition = position;
        }

        public void SetAudienceHintPositions(List<int> positions)
        {
            UsedHints.AudienceHelpPositions = positions;
        }

        public void SetFiftyFiftyPositions(List<int> positions)
        {
            UsedHints.FiftyFiftyPositions = positions;
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

        public string GetCorrectAnswer()
        {
            return _currentQuestionStructure.CorrectAnswer;
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

        public void RemoveAnswers(List<string> answers)
        {
            _currentQuestionStructure.RemoveAnswers(answers);
        }
    }
}
