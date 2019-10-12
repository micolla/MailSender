using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CSVImport
{
    public class CSVReader
    {
        string _filePath;
        char _splitter;
        public CSVReader(string filePath,char splitter)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Необходимо указать существующий файл", filePath);
            _filePath = filePath;
            _splitter = splitter;
        }

        public async Task<List<Man>> ReadCSVMenAsync()
        {
            List<Man> mans = new List<Man>();
            using (var sr=new StreamReader(_filePath))
            {
                string line;
                string[] elements;
                while (!sr.EndOfStream)
                {
                    line = await sr.ReadLineAsync();
                    elements = line.Split(_splitter);
                    if (elements.Length == 3)
                        mans.Add(new Man(elements[0], elements[1], elements[2]));
                }
            }
            return mans;
        }

    }
}
