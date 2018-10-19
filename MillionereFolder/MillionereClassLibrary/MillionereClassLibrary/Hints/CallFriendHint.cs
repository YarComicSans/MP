using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionereClassLibrary.Hints
{
    partial class CallFriendHint : Hint
    {
        public CallFriendHint() : base()
        {
        }


        public override List<string> CalculateAnswer(List<string> answers, string correctAnswer, int requiredProbability)
        {
            SetUsed();

            Random randomValue = new Random();
            int maxRandomValue = 100;
            int calculatedProbability = randomValue.Next(maxRandomValue);

            if(calculatedProbability <= requiredProbability)
                return new List<string> {correctAnswer};
            else
            {
                answers.Remove(correctAnswer);
                return new List<string> {answers[calculatedProbability % answers.Count]};
            }
        }
    }
}
