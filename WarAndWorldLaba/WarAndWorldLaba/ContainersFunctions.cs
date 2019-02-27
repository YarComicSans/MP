using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WarAndWorldLaba
{

    public class Frequency
    {
        public int Value;
        public string Word;

        public Frequency(string w, int v)
        {
            Word = w;
            Value = v;
        }
    }
    enum Containers
    {
        SortedList = 1,
        SortedDictionary = 2,
        List = 3,
        Dictionary = 4,
        All = 5
    }
    public static class ContainersFunctions
    {
        static int mostFrequentWordsNumber = 10;
        public static string[] GetContainerNames()
        {
            string[] containerNames = {"SortedList", "SortedDictionary", "List", "Dictionary"};
            return containerNames;
        }
        public static void DoRequiredAnalysis(int choice, string filename)
        {
            
            string[] words = GetWordsFromText(GetTextFromFile(filename));
            
            switch (choice)
            {
                case (int) Containers.SortedList:
                {
                    RunSortedListAnalysis(words);
                    break;
                }
                case (int) Containers.SortedDictionary:
                {
                    RunSortedDictionaryAnalysis(words);
                    break;   
                }
                case (int) Containers.List:
                {
                    RunListAnalysis(words);
                    break;
                }
                case (int) Containers.Dictionary:
                {
                    RunDictionaryAnalysis(words);
                    break;
                }
                case (int) Containers.All:
                {
                    RunSortedListAnalysis(words);
                    RunSortedDictionaryAnalysis(words);
                    RunDictionaryAnalysis(words);
                    RunListAnalysis(words);
                    break;
                }
            }
        }

        private static void RunDictionaryAnalysis(string[] words)
        {
            Dictionary<string, int> frequencesDictionary = new Dictionary<string, int>();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (var word in words)
            {
                if (!frequencesDictionary.ContainsKey(word))
                    frequencesDictionary.Add(word, 0);
                frequencesDictionary[word]++;
            }

            int uniqueWordsCount = frequencesDictionary.Count;

            var frequencesSortedByValue = frequencesDictionary.OrderByDescending(t => t.Value);
            var tenMostFrequentWords = frequencesSortedByValue.Take(mostFrequentWordsNumber);

            watch.Stop();

            Menu.PrintCompletionTimeInConsole(watch.ElapsedMilliseconds, "Dictionary");
            Menu.PrintNumberOfUniqueWordsInConsole(uniqueWordsCount);
            Menu.PrintMostFrequentWordsInConsole(tenMostFrequentWords);

        }

        private static void RunListAnalysis(string[] words)
        {
            List<KeyValuePair<string,int>> frequenciesList = new List<KeyValuePair<string, int>>();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (var word in words)
            {
                int indexOfWord = frequenciesList.FindIndex(t => t.Key == word);
                bool wordAddedAlready = (indexOfWord != -1);
                if (!wordAddedAlready)
                    frequenciesList.Add(new KeyValuePair<string, int>(word,1));
                else
                {
                    var oldEntry = frequenciesList[indexOfWord];
                    frequenciesList[indexOfWord] = new KeyValuePair<string, int>(oldEntry.Key, oldEntry.Value + 1);
                }
            }

            int uniqueWordsCount = frequenciesList.Count;

            var frequencesSortedByValue = frequenciesList.OrderByDescending(t => t.Value);
            var tenMostFrequentWords = frequencesSortedByValue.Take(mostFrequentWordsNumber);

            watch.Stop();

            Menu.PrintCompletionTimeInConsole(watch.ElapsedMilliseconds, "List");
            Menu.PrintNumberOfUniqueWordsInConsole(uniqueWordsCount);
            Menu.PrintMostFrequentWordsInConsole(tenMostFrequentWords);
        }

        private static void RunSortedDictionaryAnalysis(string[] words)
        {
            SortedDictionary<string,int> frequencesDictionary = new SortedDictionary<string, int>();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (var word in words)
            {
                if (!frequencesDictionary.ContainsKey(word))
                    frequencesDictionary.Add(word, 0);
                frequencesDictionary[word]++;
            }

            int uniqueWordsCount = frequencesDictionary.Count;

            var frequencesSortedByValue = frequencesDictionary.OrderByDescending(t => t.Value);
            var tenMostFrequentWords = frequencesSortedByValue.Take(mostFrequentWordsNumber);

            watch.Stop();

            Menu.PrintCompletionTimeInConsole(watch.ElapsedMilliseconds, "SortedDictionary");
            Menu.PrintNumberOfUniqueWordsInConsole(uniqueWordsCount);
            Menu.PrintMostFrequentWordsInConsole(tenMostFrequentWords);
        }

        private static void RunSortedListAnalysis(string[] words)
        {
            SortedList<string,int> frequencesList = new SortedList<string, int>();
            
            var watch = System.Diagnostics.Stopwatch.StartNew();

            foreach (var word in words)
            {
                if (!frequencesList.ContainsKey(word))
                    frequencesList.Add(word,0);
                frequencesList[word]++;
            }

            int uniqueWordsCount = frequencesList.Count;

            var frequencesSortedByValue = frequencesList.OrderByDescending(t => t.Value);
            var tenMostFrequentWords = frequencesSortedByValue.Take(mostFrequentWordsNumber);

            watch.Stop();

            Menu.PrintCompletionTimeInConsole(watch.ElapsedMilliseconds, "SortedList");
            Menu.PrintNumberOfUniqueWordsInConsole(uniqueWordsCount);
            Menu.PrintMostFrequentWordsInConsole(tenMostFrequentWords);

        }

        private static string GetTextFromFile(string filename)
        {

            string wholeText;

            using (StreamReader sr = new StreamReader(filename))
            {
                wholeText = sr.ReadToEnd();
            }
            return wholeText;
            
        }

        private static string[] GetWordsFromText(string text)
        {
            string pattern = "[А-Яа-яA-Za-z][А-Яа-яA-Za-z]*[$]?";
            string[] words = {};

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            if (matches.Count > 0)
            {
                List<string> wordsList = new List<string>();
                foreach (Match match in matches)
                {
                    wordsList.Add(match.Value);
                }

                words = wordsList.Select(i => i.ToString()).ToArray();
            }
            return words;
        }
    }
}
