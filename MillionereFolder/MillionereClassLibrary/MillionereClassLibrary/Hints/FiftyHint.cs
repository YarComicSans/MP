using System;
using System.Collections.Generic;

namespace MillionereClassLibrary.Hints
{
    [Serializable]
    public class FiftyHint : Hint
    {

        public FiftyHint(bool available = true)
        {
            IsAvailable = true;
        }

        public override List<string> CalculateAnswer(List<string> answers, string correctAnswer, int requestedPossibility = 0)
        {
            SetUsed();

            var randomValue = new Random();
            int chosenAnswerNumber = randomValue.Next(answers.Count);
            if (answers[chosenAnswerNumber] == correctAnswer)
                answers.Remove(correctAnswer);
            return new List<string> {correctAnswer, answers[chosenAnswerNumber % answers.Count]};
        }
    }
}
