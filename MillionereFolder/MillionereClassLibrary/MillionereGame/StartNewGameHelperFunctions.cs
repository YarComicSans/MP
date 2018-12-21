using MillionereClassLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MillionereGame
{
    partial class StartNewGameHelperFunctions
    {
        public static Hoster MakeHoster(string name)
        {
            string iconPath = "";
            switch (name)
            {
                case "Galkin":
                {
                    iconPath = SetIconPath("GalkinIcon.jpg");
                    break;
                }
                case "Dibrov":
                {
                    iconPath = SetIconPath("DibrovIcon.jpg");
                    break;
                }
            }
            return new Hoster(name, iconPath);

        }

        private static string SetIconPath(string iconFileName)
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + "/Icons/" + iconFileName;
        }

        public static List<QuestionStructure> MakeQuestionList(string questionPackPath)
        {
            string textFromPack = "";
            using (StreamReader sr = new StreamReader(questionPackPath))
            {
                textFromPack = sr.ReadToEnd();
            }

            List<QuestionStructure> questionList = new List<QuestionStructure>();
            
            var questions = Regex.Split(textFromPack, @"(<Question>[\s\S]+?<\/Question>)").Where(l => l != string.Empty).ToArray();
            for(int i = 1; i < questions.Length; i+=2)
                questionList.Add(new QuestionStructure(questions[i]));
            return questionList;
        }

        public static string GetQuestionPackName(string questionPackPath)
        {
            string textFromPack = "";
            using (StreamReader sr = new StreamReader(questionPackPath))
            {
                textFromPack = sr.ReadToEnd();
            }
            string pattern = @"<Name>(.*?)</Name>";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(textFromPack);

            string name = matches[matches.Count - 1].Value.Substring(6, matches[matches.Count - 1].Value.Length - 13);
            return name;
        }

        public static Player MakePlayer(string name)
        {
            return new Player(name);
        }
    }
}
