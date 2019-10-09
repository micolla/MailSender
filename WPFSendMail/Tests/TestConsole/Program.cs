using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using TestConsole.Lesson6Tasks;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        private static int[,] result;

        static void Main(string[] args)
        {
            int[,] result=DoFirst().Result;
            //PrintArray(result);
            DoSecond();
            Console.ReadLine();
        }

        static void DoSecond()
        {
            Exercise2 e = new Exercise2("Lesson6Tasks\\Files", "result.dat");
            Task t = Task.Run(e.Calc);
            t.Wait();
        }
        static async Task<int[,]> DoFirst()
        {
            int[,] first = new int[100, 100];
            int[,] second = new int[100, 100];
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    first[i, j] = rnd.Next(0, 10);
                    second[i, j] = rnd.Next(0, 10);
                }
            }
            Exercise1 e = new Exercise1(first, second);
            var t = await e.MultiplyMatrixAsync();
            return t;
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($" {array[i, j]}");
                }
                Console.WriteLine();
            }
        }


    }
}
