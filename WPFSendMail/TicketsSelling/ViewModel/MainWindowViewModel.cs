using System;
using System.Windows.Input;
using TicketsSelling.Data.EF;
using TicketsSelling.Entities;
using TicketsSelling.MVVM;
using TicketsSelling.View;

namespace TicketsSelling.ViewModel
{
    public class MainWindowViewModel: MVVM.BaseEditorVM
    {
        string _WindowTitle = "АРМ по продаже билетов";
        public string WindowTitle
        {
            get => _WindowTitle;
            set => Set(ref _WindowTitle, value);
        }

        public ICommand SellTicketCommand { get; set; }
        public ICommand CreateNewSessionCommand { get; set; }

        public MainWindowViewModel()
        {
            SellTicketCommand = new LambdaCommand(OnSellTicketCommand);
            CreateNewSessionCommand = new LambdaCommand(OnCreateNewSessionCommand);
        }

        private void OnSellTicketCommand(object obj)
        {
            Sell newSell = new Sell();
            var saved = false;
            using (var _db = new TicketBoxDB())
            {
                var sellingTicketsWindowVM = new SellingTicketsWindowViewModel(newSell, _db);
                SellingTicketsWindow addFilmSessionWindow =
                    new SellingTicketsWindow { DataContext = sellingTicketsWindowVM };
                sellingTicketsWindowVM.Save += (o, e) => { saved = true; addFilmSessionWindow.Close(); };
                sellingTicketsWindowVM.Canceled += (o, e) => { addFilmSessionWindow.Close(); };
                addFilmSessionWindow.ShowDialog();
                if (saved)
                {

                    _db.Database.Log = msg => Console.WriteLine("EF: {0}\r\n-----------------", msg);
                    newSell.InsertDTM = DateTime.Now;
                    _db.Sells.Add(newSell);
                    _db.SaveChanges();
                }
            }
        }

        private void OnCreateNewSessionCommand(object obj)
        {
            FilmSession newSession = new FilmSession();
            var saved = false;
            var addFilmSessionWindowVM = new AddFilmSessionWindowViewModel(newSession);
            AddFilmSessionWindow addFilmSessionWindow =
                new AddFilmSessionWindow { DataContext = addFilmSessionWindowVM };
            addFilmSessionWindowVM.Save += (o, e) => { saved = true; addFilmSessionWindow.Close(); };
            addFilmSessionWindowVM.Canceled += (o, e) => { addFilmSessionWindow.Close(); };
            addFilmSessionWindow.ShowDialog();
            if (saved)
            {
                using (var _db = new TicketBoxDB())
                {
                    newSession.InsertDTM = DateTime.Now;
                    _db.FilmSessions.Add(newSession);
                    _db.SaveChanges();
                }
            }
        }
    }
}
