using System;

namespace WarAndWorldLaba
{
    class Program
    {
        static string filename = "WarAndWorld.txt";
        static void Main()
        {

            Menu.PrintMenuInConsole(ContainersFunctions.GetContainerNames());

            int choice = int.Parse(Console.ReadLine());

            ContainersFunctions.DoRequiredAnalysis(choice,filename);

            while (choice != 0)
            {
                Menu.PrintMenuInConsole(ContainersFunctions.GetContainerNames());

                choice = int.Parse(Console.ReadLine());

                ContainersFunctions.DoRequiredAnalysis(choice, filename);
            }

        }
    }
}
