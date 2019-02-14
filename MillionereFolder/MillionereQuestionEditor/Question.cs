using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace MillionereQuestionEditor
{
    [Serializable]
    public class Question
    {
        [XmlElement(ElementName = "Name")]
        public string _question;
        [XmlElement(ElementName = "Answer")]
        public List<Answer> _answers;
        [XmlElement(ElementName = "CorrectAnswer")]
        public string _correctAnswer;


        public Question(string q, List<Answer> a, string cA)
        {
            _question = q;
            _answers = a;
            _correctAnswer = cA;
        }

        public Question()
        { }
        public string GetQuestion()
        {
            return _question;
        }

        public string GetAnswerByIndex(int index)
        {
            return _answers[index].answer;
        }

        public string GetCorrectAnswer()
        {
            return _correctAnswer;
        }
    }

    [Serializable]
    public class Answer
    {
        [XmlElement(ElementName = "Text")]
        public string answer;

        public Answer(string a)
        {
            answer = a;
        }

        public Answer()
        { }
    }
}
