using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole.Lesson6Tasks
{
    class Exercise2
    {
        List<string> _files;
        string _directoryPath;
        string _fileOutputPath;
        List<string> _buffer;
        bool _readDone = false;
        AutoResetEvent waitHandler = new AutoResetEvent(true);
        public Exercise2(string directoryPath, string fileOutputPath)
        {
            _directoryPath = directoryPath;
            _fileOutputPath = fileOutputPath;
            _files = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(_directoryPath);
            foreach (var item in dir.GetFiles("*.txt"))
            {
                _files.Add(item.FullName);
            }
            _buffer = new List<string>();
        }

        public async void Calc()
        {
            Console.WriteLine("Файл");
            List<Task> tasks=new List<Task>();
            for (int i = 0; i < _files.Count; i++)
            {
                string s = _files[i];
                tasks.Add(Task.Run(()=>Calc(s)));
            }
            tasks.Add(Task.Run(TXTWrite));
            await Task.WhenAll(tasks);
        }
        void Calc(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] elements;
                Task<string> taskRead;
                string result;
                while (!sr.EndOfStream)
                {
                    taskRead = sr.ReadLineAsync();
                    waitHandler.WaitOne();
                    elements = taskRead.Result.Split(' ');
                    switch (elements[0])
                    {
                        case "1":
                            result = $"{filePath}:{elements[1]}*{elements[2]}={int.Parse(elements[1]) * int.Parse(elements[2])}";
                            break;
                        case "2":
                            string s = int.Parse(elements[2]) == 0 ? "деление на ноль"
                                : (int.Parse(elements[1]) / int.Parse(elements[2])).ToString();
                            result = $"{filePath}:{elements[1]}/{elements[2]}={s}";
                            break;
                        default:
                            result = $"{filePath}:Не поддерживаемая операция";
                            break;
                    }
                    _buffer.Add(result+" Поток: "+Thread.CurrentThread.ManagedThreadId);
                    waitHandler.Set();
                }
                _readDone = true;
            }
        }
        async void TXTWrite()
        {
            using (StreamWriter sw = new StreamWriter(_fileOutputPath))
            {
                string line;
                while (!_readDone || _buffer.Count > 0)
                {
                    waitHandler.WaitOne();
                    if (_buffer.Count > 0)
                    {
                        line = _buffer[0];
                        _buffer.RemoveAt(0);
                        waitHandler.Set();
                        await sw.WriteLineAsync(line);
                    }
                }
            }
        }
    }
}
