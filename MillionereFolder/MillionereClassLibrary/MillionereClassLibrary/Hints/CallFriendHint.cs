using System;
using System.Collections.Generic;

namespace MillionereClassLibrary.Hints
{
    [Serializable]
    public class CallFriendHint : Hint
    {

        public CallFriendHint(bool available = true)
        {
            IsAvailable = true;
        }

        public CallFriendHint()
        { }

        public override List<string> CalculateAnswer(List<string> answers, string correctAnswer, int requiredProbability)
        {
            SetUsed();

            var randomValue = new Random();
            int maxRandomValue = 100;
            int calculatedProbability = randomValue.Next(maxRandomValue);

            if(calculatedProbability <= requiredProbability)
                return new List<string> {correctAnswer};
            answers.Remove(correctAnswer);
            return new List<string> {answers[calculatedProbability % answers.Count]};
        }
    }
}
