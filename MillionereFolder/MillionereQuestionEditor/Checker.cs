using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MillionereQuestionEditor
{
    public class Checker
    {
        public Checker()
        {

        }
        public bool CheckAllField(string Q, string A, string B, string C, string D, string CA)
        {
            if (Q == "" || Q == " " || A == "" || A == " " || B == "" || B == " " || C == "" || C == " " || D == "" || D == " " || CA == "" || CA == " ")
            {
                MessageBox.Show("Заполните все поля, пожалуйста!");
                return false;
            }
            else if (A == B || A == C || A == D || B == C || B == D || C == D)
            {
                MessageBox.Show("Варианты ответа совпадают");
                return false;
            }
            else if (CA.ToLower() != "a" && CA.ToLower() != "b" && CA.ToLower() != "c" && CA.ToLower() != "d")
            {
                MessageBox.Show("Правильный ответ не совпадает ни с одним из варинтов ответа!");
                return false;
            }
            return true;
        }
        public string RightAnswerForUser(string A, string B, string C, string D, string CA)
        {
            if (CA == A)
            {
                return "A";
            }
            else if (CA == B)
            {
                return "B";
            }
            else if (CA == C)
            {
                return "C";
            }
            else if (CA == D)
            {
                return "D";
            }
            return null;
        }
        public string RightAnswer(string A, string B, string C, string D, string CA)
        {
            if (CA.ToLower() == "a")
            {
                return A;
            }
            else if (CA.ToLower() == "b")
            {
                return B;
            }
            else if (CA.ToLower() == "c")
            {
                return C;
            }
            else if (CA.ToLower() == "d")
            {
                return D;
            }
            return null;
        }
    }
}
