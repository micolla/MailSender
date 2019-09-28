using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            object i = "dsds";
            Console.WriteLine(i.GetType().ToString());
            IEnumerable si = new List<int> { 1,2};
            foreach (var item in si)
            {
                Console.WriteLine(item.GetType());
            }
            Console.ReadLine();
        }
    }
}
