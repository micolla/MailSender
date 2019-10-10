using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole.Lesson6Tasks
{
    public static class Exercise1
    {
        static void MultiplyRow(int rowNumber,int columnsCount,int[,] firstMatrix,int[,] secondMatrix,int[,] result)
        {
            int iterator = 0;
            while (iterator < columnsCount)
            {
                for (int c = 0; c < columnsCount; c++)
                {
                    result[rowNumber, iterator] += firstMatrix[rowNumber, c] * secondMatrix[c, iterator];
                }
                iterator++;
            }
        }

        public static async Task<int[,]> MultiplyMatrixAsync(int[,] firstMatrix,int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0)) return null;
            int[,] _result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            int secondMatrixRows = secondMatrix.GetLength(1);
            for (int i = 0; i < _result.GetLength(0); i++)
            {
                for (int j = 0; j < _result.GetLength(1); j++)
                {
                    _result[i, j] = 0;
                }
            }
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                int row = i;
                tasks.Add(Task.Run(()=>MultiplyRow(row, secondMatrixRows,firstMatrix,secondMatrix,_result)));
            }
            var awaitingAllTasks = Task.WhenAll(tasks);
            await awaitingAllTasks;
            return _result;
        }
    }
}
