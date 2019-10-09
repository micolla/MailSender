using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using TestConsole.Lesson5Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstExercise.DoExercise();
            SecondExersice.DoExercise("Lesson5Tasks/testdata.csv", "Lesson5Tasks/outputData.txt");
            Console.ReadLine();

        }
    }
}
