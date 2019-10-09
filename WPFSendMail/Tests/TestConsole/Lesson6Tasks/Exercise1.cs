using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole.Lesson6Tasks
{
    public class Exercise1
    {
        int[,] _firstMatrix;
        int[,] _secondMatrix;
        int[,] _result;
        int _secondMatrixRows;
        public Exercise1(int[,] firstMatrix,int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0)) return;
            _firstMatrix = firstMatrix;
            _secondMatrix = secondMatrix;
            _result = new int[_firstMatrix.GetLength(0),_secondMatrix.GetLength(1)];
            _secondMatrixRows = _secondMatrix.GetLength(1);
            for (int i = 0; i < _result.GetLength(0); i++)
            {
                for (int j = 0; j < _result.GetLength(1); j++)
                {
                    _result[i, j] = 0;
                }
            }
        }
        public int[,] MultiplyMatrix()
        {
            for (int r = 0; r < _firstMatrix.GetLength(0); r++)
            {
                MultiplyRow(r);
            }
            return _result;
        }

        void MultiplyRow(int row)
        {
            Console.WriteLine($"Start row {row} :{Thread.CurrentThread.ManagedThreadId}");
            int iterator = 0;
            while (iterator < _secondMatrixRows)
            {
                for (int c = 0; c < _firstMatrix.GetLength(1); c++)
                {
                    _result[row, iterator] += _firstMatrix[row, c] * _secondMatrix[c, iterator];
                }
                iterator++;
            }
            Console.WriteLine($"Finish row {row} :{Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task<int[,]> MultiplyMatrixAsync()
        {
            List<Task> tasks = new List<Task>();
            //Console.WriteLine($"Start {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < _firstMatrix.GetLength(0); i++)
            {
                int row = i;
                tasks.Add(Task.Run(()=>MultiplyRow(row)));
            }
            var awaitingAllTasks = Task.WhenAll(tasks);
            await awaitingAllTasks;
            return this._result;
        }
    }
}
