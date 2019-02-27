using System;
using System.Collections.Generic;

namespace WarAndWorldLaba
{
    public static class Menu
    {
        public static void PrintMenuInConsole(string[] availableContainers)
        {
            Console.WriteLine("Choose Container to test:");
            for (int i = 0; i < availableContainers.Length; i++)
            {
                Console.WriteLine($"{i+1}. " + availableContainers[i]);
            }
            Console.WriteLine($"{availableContainers.Length + 1}. Test All Containers");
        }

        public static void PrintNumberOfUniqueWordsInConsole(int value)
        {
            Console.WriteLine($"Number of unique words : {value}");
        }

        public static void PrintMostFrequentWordsInConsole(IEnumerable<KeyValuePair<string, int>> words)
        {
            Console.WriteLine($"Most frequent words :");
            Console.WriteLine("\t-WORD-\t-FREQUENCY-");
            foreach (var word in words)
            {
                Console.WriteLine($"\t{word.Key}\t{word.Value}");
            }
        }

        public static void PrintCompletionTimeInConsole(long watchElapsedMilliseconds, string containerName)
        {
            Console.WriteLine($"\n\nCompletion time via {containerName} : {watchElapsedMilliseconds}ms");
        }
    }
}
