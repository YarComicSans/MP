using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
