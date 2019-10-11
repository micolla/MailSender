using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsSelling.Data.EF;
using TicketsSelling.Entities;
using TicketsSelling.ViewModel.BaseEditorVM;

namespace TicketsSelling.ViewModel
{
    public class SellingTicketsWindowViewModel : BaseEditorVM<Sell>
    {
        List<FilmSession> _FilmsSessions;
        public List<FilmSession> FilmsSessions
        {
            get => _FilmsSessions;
            set => Set(ref _FilmsSessions, value);
        }
        public SellingTicketsWindowViewModel(Sell sell) : base(sell)
        {
            WindowTitle = "Продажа билета";
            FilmsSessions = LoadSessions();
        }
        List<FilmSession> LoadSessions()
        {
            using(var _db=new TicketBoxDB())
            {
                return _db.FilmSessions.ToList();
            }
        }
        
    }
}
