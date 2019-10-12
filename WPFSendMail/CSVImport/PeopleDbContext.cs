using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVImport
{
    public class PeopleDbContext:DbContext
    {
        public DbSet<Man> Men { get; set; }
        public PeopleDbContext() : this("name=PeopleDb") { }

        public PeopleDbContext(string connectionString) : base(connectionString) { }
    }
}
