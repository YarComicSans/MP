using System;
using System.Collections.Generic;

namespace MillionereClassLibrary.Hints
{
    partial class FiftyHint : Hint
    {
        public FiftyHint() : base()
        {
        }

        public override List<string> CalculateAnswer(List<string> answers, string correctAnswer, int requestedPossibility = 0)
        {
            SetUsed();

            Random randomValue = new Random();
            int chosenAnswerNumber = randomValue.Next(answers.Count);
            if (answers[chosenAnswerNumber] == correctAnswer)
                answers.Remove(correctAnswer);
            return new List<string> {correctAnswer, answers[chosenAnswerNumber % answers.Count]};
        }
    }
}
