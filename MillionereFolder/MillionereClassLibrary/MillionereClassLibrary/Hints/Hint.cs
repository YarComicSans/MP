using System;
using System.Collections.Generic;

namespace MillionereClassLibrary.Hints
{
    [Serializable]
    public abstract class Hint
    {
        public string CurrentIconPath;
        public bool IsAvailable;

        protected Hint()
        {
            IsAvailable = true;
        }

        public abstract List<string> CalculateAnswer(List<string> answers, string correctAnswer, int requiredProbability);

        public void SetUsed()
        {
            IsAvailable = false;
        }

        public void SetIconPath(string p)
        {
            CurrentIconPath = p;
        }
    }
}
