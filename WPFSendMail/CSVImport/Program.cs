using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVImport
{
    class Program
    {
        static void Main(string[] args)
        {
            CSVReader reader = new CSVReader("Files\\ImportData.csv", ',');
            List<Man> men = reader.ReadCSVMenAsync().Result;
            using(var _db=new PeopleDbContext())
            {
                _db.Men.AddRange(men);
                _db.SaveChanges();
            }
            Console.WriteLine("Проимпортировано");
            Console.Read();
        }
    }
}
