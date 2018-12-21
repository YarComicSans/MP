using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionereClassLibrary.Hints
{
    [Serializable]
    public class AudienceHelpHint : Hint
    { 
        //public AudienceHelpHint() : base()
        //{
        //}

        public AudienceHelpHint()
        {
            IsAvailable = true;
        }
        public override List<string> CalculateAnswer(List<string> answers, string correctAnswer, int requiredProbability)
        {
            SetUsed();

            List<string> result = new List<string>();
            Random randomValue = new Random();
            int maxPercent = 100;
            int randomPercent = randomValue.Next(maxPercent);

            if (randomPercent <= requiredProbability)
            {
                result.Add(correctAnswer);
                answers.Remove(correctAnswer);
                randomPercent = randomValue.Next(maxPercent);
            }

            while (answers.Count > 0)
            {               
                result.Add(answers[randomPercent % answers.Count]);
                answers.Remove(result.Last());
                randomPercent = randomValue.Next(maxPercent);
            }

            return result;
        }

        public SortedSet<int> CalculateProbability(int answersNumber)
        {
            Random randomValue = new Random();
            SortedSet<int> setOfPercentages = new SortedSet<int>();
            int maxPercent = 100;

            while (answersNumber > 1)
            {
                int randomPercent = randomValue.Next(0, maxPercent);
                setOfPercentages.Add(randomPercent);
                maxPercent -= randomPercent;
                answersNumber--;
            }
            setOfPercentages.Add(maxPercent);

            return setOfPercentages;
        }
    }
}
