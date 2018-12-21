using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redactor
{
    [Serializable]
    public class Question
    {
        public string _question;
        public string _a;
        public string _b;
        public string _c;
        public string _d;

        public Question(string question, string answerA, string answerB, string answerC, string answerD)
        {
            _question = question;
            _a = answerA;
            _b = answerB;
            _c = answerC;
            _d = answerD;
        }
        public Question()
        {

        }
    }
}
