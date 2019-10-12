using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsSelling.Entities
{
    public class FilmSession:BaseEntity
    {
        public string FilmName { get; set; }
        public DateTime BeginingDate { get; set; }
        public int AvailibleTicketsCount { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
    }
}
