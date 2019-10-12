using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsSelling.Entities
{
    public class Sell:BaseEntity
    {
        public virtual FilmSession FilmSession { get; set; }
        public int TicketsCount { get; set; }
    }
}
