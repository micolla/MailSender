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
        TicketBoxDB _db;
        public SellingTicketsWindowViewModel(Sell sell,TicketBoxDB db) : base(sell)
        {
            WindowTitle = "Продажа билета";
            _db = db;
            FilmsSessions = LoadSessions();
        }
        List<FilmSession> LoadSessions()
        {
            return _db.FilmSessions.ToList();
        }
    }
}
