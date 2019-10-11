using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicketsSelling.Data.EF;
using TicketsSelling.Entities;
using TicketsSelling.MVVM;
using TicketsSelling.ViewModel.BaseEditorVM;

namespace TicketsSelling.ViewModel
{
    public class AddFilmSessionWindowViewModel : BaseEditorVM<FilmSession>
    {
        public AddFilmSessionWindowViewModel(FilmSession entity) : base(entity)
        {
            WindowTitle = "Добавление сеанса";
        }
    }
}
