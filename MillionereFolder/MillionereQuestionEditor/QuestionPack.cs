using System;
using System.Collections.Generic;

namespace MillionereQuestionEditor
{
    [Serializable]
    public class QuestionPack
    {
        public List<Question> Questions;
        public string Name;
        public QuestionPack(List<Question> q, string n)
        {
            Questions = q;
            Name = n;
        }

        public QuestionPack()
        {
        }
    }
}
