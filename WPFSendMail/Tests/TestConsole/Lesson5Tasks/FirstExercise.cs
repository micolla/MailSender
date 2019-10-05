using System;
using System.Threading;

namespace TestConsole.Lesson5Tasks
{
    public static class FirstExercise
    {
        static long resultFactorial = 1;
        static ulong sumNumber = 0;
        public static void DoExercise()
        {
            int N;
            bool _correct = false;
            Thread factorialThread = new Thread(Factorial) { IsBackground = true };
            Thread SumThread = new Thread(Sum) { IsBackground = true };
            while (!_correct)
            {
                Console.WriteLine("Введите число для расчета суммы от 1 до N");
                _correct = int.TryParse(Console.ReadLine(), out N);
                if (_correct)
                {
                    SumThread.Start(N);
                }
            }
            _correct = false;
            while (!_correct)
            {
                Console.WriteLine("Введите число для расчета факториала от 0 до 59");
                _correct = int.TryParse(Console.ReadLine(), out N);
                if (_correct && N >= 0 && N < 60)
                {
                    factorialThread.Start(N);
                }
            }

            factorialThread.Join();
            Console.WriteLine("Факториал {0}", resultFactorial);
            SumThread.Join();
            Console.WriteLine("Сумма {0}", sumNumber);
        }
        private static void Factorial(object n)
        {
            int N = (int)n;
            if (N > 1)
            {
                Factorial(N - 1);
                resultFactorial *= N;
            }
        }
        static void Sum(object n)
        {
            int N = (int)n;
            for (int i = 1; i < N; i++)
            {
                sumNumber += (ulong)i;
            }
        }
        #region MaybeLater
        //private static void CalcFactorial(int N,bool threads, out long result)
        //    {
        //        result = 1;
        //        int step = 20;
        //        if (threads)
        //        {
        //            List<FactClass> listClasses = new List<FactClass>();
        //            List<Thread> listThreads = new List<Thread>();
        //            int n = N;
        //            while (n >= step)
        //            {
        //                listClasses.Add(new FactClass { N = n, S = n - step });
        //                n -= step;
        //            }
        //            if (n > 1)
        //                listClasses.Add(new FactClass { N = n, S = 1 });
        //            Thread thread;
        //            foreach (var item in listClasses)
        //            {
        //                thread = new Thread(item.Calc) { Name = item.N.ToString() };
        //                listThreads.Add(thread);
        //                thread.Start();
        //                Console.WriteLine(thread.ThreadState.ToString());
        //            }
        //            while (listThreads.Count((t) => t.ThreadState == ThreadState.Running) > 0) { }

        //            foreach (var item in listClasses)
        //                result *= item.result;
        //        }
        //        else
        //        {
        //            FactClass f = new FactClass { N = N, S = 1 };
        //            f.Calc();
        //            result = f.result;
        //        }

        //    }
        //}

        //class FactClass
        //{
        //    public int N;
        //    public int S;
        //    public long result=1;

        //    public void Calc()
        //    {
        //        Console.WriteLine("Запустился {0} поток", Thread.CurrentThread.ManagedThreadId);
        //        //Thread.Sleep(1000);
        //        result = Factorial(N, S);
        //        Console.WriteLine("Завершился {0} поток", Thread.CurrentThread.ManagedThreadId);
        //    }
        //    private long Factorial(int n, int s)
        //    {
        //        if (n <= s)
        //            return 1;
        //        else
        //            return n * Factorial(n - 1, s);
        //    }
        #endregion

    }

}
