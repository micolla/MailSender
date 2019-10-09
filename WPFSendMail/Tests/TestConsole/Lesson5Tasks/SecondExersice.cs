using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole.Lesson5Tasks
{
    public static class SecondExersice
    {
        static List<String> _buffer = new List<string>();
        static string FileInputPath { get; set; }
        static string FileOutoutPath { get; set; }
        static readonly object __SyncRoot = new object();
        static bool _readDone = false;
static AutoResetEvent waitHandler = new AutoResetEvent(true);
        public static void DoExercise(string fileInputPath, string fileOutputPath)
        {
            if (!File.Exists(fileInputPath)) return;
            FileInputPath = fileInputPath;
            FileOutoutPath = fileOutputPath;
            Thread csvReadThread = new Thread(CSVRead) { IsBackground = true };
            Thread txtWriteThread = new Thread(TXTWrite) { IsBackground = true };
            Console.WriteLine("Парсинг начинаем из {0} в {1}", FileInputPath, FileOutoutPath);
            csvReadThread.Start();
            txtWriteThread.Start();
            csvReadThread.Join();
            txtWriteThread.Join();
            Console.WriteLine("Парсинг закончен");
        }
        static void CSVRead()
        {
            using (StreamReader sr = new StreamReader(FileInputPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    waitHandler.WaitOne();
                    _buffer.Add(line);
                    waitHandler.Set();
                }
                _readDone = true;
            }
        }
        static void TXTWrite()
        {
            using (StreamWriter sw = new StreamWriter(FileOutoutPath))
            {
                string line;
                while(!_readDone|| _buffer.Count > 0)
                {
                    if (_buffer.Count > 0)
                        waitHandler.WaitOne();
                        line = _buffer[0];
                        _buffer.RemoveAt(0);
                        waitHandler.Set();
                        sw.WriteLine(line);
                        }
                }
            }
        }
    }
}
