using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSelling.Entities;

namespace TicketsSelling.Data.EF
{
    public class TicketBoxDB:DbContext
    {
        public DbSet<FilmSession> FilmSessions { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public TicketBoxDB(string ConnectionString) : base(ConnectionString) { }
        public TicketBoxDB() : this("name=TicketBoxDB") { }
    }
}
