using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace MillionereGame
{
    [Serializable]
    public class AnswersWithPossibilities
    {
        public int Possibility;
        public string Answer;

        public AnswersWithPossibilities(int p, string a)
        {
            Possibility = p;
            Answer = a;
        }

        public AnswersWithPossibilities()
        { }
    }

    [Serializable]
    public class AnswrsWithPossCollection : Collection<AnswersWithPossibilities>
    {
        private static AnswrsWithPossCollection chartInfo = new AnswrsWithPossCollection();
        private AnswrsWithPossCollection()
        { }
        public static AnswrsWithPossCollection GetInstance(List<string> answers = null, SortedSet<int> possibilities = null)
        {
            lock (chartInfo)
            {
                if (chartInfo == null)
                {
                    for (int i = 0; i < answers.Count; i++)
                        chartInfo.Add(new AnswersWithPossibilities(possibilities.ElementAt(i), answers[i]));
                }
                return chartInfo;
            }
        }
    }
}
