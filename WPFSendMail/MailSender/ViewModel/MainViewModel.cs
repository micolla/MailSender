using GalaSoft.MvvmLight;
using MailSender.Lib.Services.Interfaces;
using MailSender.Lib.Data.Linq2SQL;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System;

namespace MailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ISenderDataProvider _senderDataProvider;
        private ObservableCollection<Sender> _Senders = new ObservableCollection<Sender>();

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            set => Set(ref _Senders, value);
        }

        #region SelectedSender : Sender - Выбранный отправитель

        /// <summary>Выбранный отправитель</summary>
        private Sender _SelectedSender;

        /// <summary>Выбранный отправитель</summary>
        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        #endregion

        public MainViewModel(ISenderDataProvider senderDataProvider)
        {
            _senderDataProvider = senderDataProvider;
            RefreshData();
            RefreshDateCommand = new RelayCommand(OnRefreshDateCommand);
        }
        private void OnRefreshDateCommand() => RefreshData();

        public ICommand RefreshDateCommand {get;}


        private void RefreshData()
        {
            var senders = Senders;
            Senders.Clear();
            foreach (var sender in _senderDataProvider.GetAll())
                senders.Add(sender);
        }
    }
}