using System;
using System.Collections.Generic;
using MillionereClassLibrary.Hints;

namespace MillionereClassLibrary
{
    [Serializable]
     public class Round
    {
        public QuestionStructure CurrentQuestionStructure;
        public Player CurrentPlayer;
        public HintsUsage UsedHints = new HintsUsage();

        public Round(Player player, QuestionStructure questionStructure)
        {
            CurrentPlayer = player;
            CurrentQuestionStructure = questionStructure;
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
            CurrentQuestionStructure = questionStructure;
        }
        public bool CheckAnswer(string chosenAnswer)
        {
            if(chosenAnswer == CurrentQuestionStructure.CorrectAnswer)
                return true;
            return false;
        }

        public string GetQuestion()
        {
            return CurrentQuestionStructure.Question;
        }

        public string GetCorrectAnswer()
        {
            return CurrentQuestionStructure.CorrectAnswer;
        }

        public List<string> GetAnswers()
        {
            return CurrentQuestionStructure.Answers;
        }

        public List<Hint> GetAvalibaleHints()
        {
            return CurrentPlayer.GetAvailableHints();
        }
        public List<string> UseHint(Hint hint, List<string> answers, string correctAnswer, int requiredProbability = 0)
        {
            return hint.CalculateAnswer(answers,correctAnswer,requiredProbability);
        }

        public void RemoveAnswers(List<string> answers)
        {
            CurrentQuestionStructure.RemoveAnswers(answers);
        }
    }
}
