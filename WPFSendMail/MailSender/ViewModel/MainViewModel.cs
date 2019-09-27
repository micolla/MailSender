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
        public MainViewModel(IDataProvider<Sender> senderDataProvider, IDataProvider<Recipient> recipientDataProvider)
        {
            #region Senders
            _senderDataProvider = senderDataProvider;
            RefreshSenders();
            RefreshSendersCommand = new RelayCommand(OnRefreshSenderCommand);
            AddSenderCommand = new RelayCommand<Sender>(OnAddSenderCommand);
            UpdateSenderCommand = new RelayCommand<Sender>(OnUpdateSenderCommand);
            DeleteSenderCommand = new RelayCommand<Sender>(OnDeleteSenderCommand);
            #endregion
            #region Recipients
            _recipientDataProvider = recipientDataProvider;
            RefreshRecipients();
            RefreshRecipientsCommand = new RelayCommand(OnRefreshRecipientCommand);
            AddRecipientCommand = new RelayCommand<Recipient>(OnAddRecipientCommand);
            UpdateRecipientCommand = new RelayCommand<Recipient>(OnUpdateRecipientCommand);
            DeleteRecipientCommand = new RelayCommand<Recipient>(OnDeleteRecipientCommand);
            #endregion
        }
        #region Senders
        private IDataProvider<Sender> _senderDataProvider;
        private ObservableCollection<Sender> _Senders = new ObservableCollection<Sender>();

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            set => Set(ref _Senders, value);
        }

        /// <summary>��������� �����������</summary>
        private Sender _SelectedSender;

        /// <summary>��������� �����������</summary>
        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }
        private void OnRefreshSenderCommand() => RefreshSenders();
        private void OnAddSenderCommand(Sender sender) => _senderDataProvider.Add(sender);
        public void OnUpdateSenderCommand(Sender sender) => _senderDataProvider.Update(sender);
        public void OnDeleteSenderCommand(Sender sender) => _senderDataProvider.Delete(sender);

        public ICommand RefreshSendersCommand {get;}
        public ICommand AddSenderCommand { get; }
        public ICommand UpdateSenderCommand { get; }
        public ICommand DeleteSenderCommand { get; }
        

        private void RefreshSenders()
        {
            var senders = Senders;
            Senders.Clear();
            foreach (var sender in _senderDataProvider.GetAll())
                senders.Add(sender);
        }
        #endregion
        #region Recipients
        private IDataProvider<Recipient> _recipientDataProvider;
        private ObservableCollection<Recipient> _Recipients = new ObservableCollection<Recipient>();

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

        /// <summary>��������� �����������</summary>
        private Recipient _SelectedRecipient;

        /// <summary>��������� �����������</summary>
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }
        private void OnRefreshRecipientCommand() => RefreshRecipients();
        private void OnAddRecipientCommand(Recipient recipient) => _recipientDataProvider.Add(recipient);
        public void OnUpdateRecipientCommand(Recipient recipient) => _recipientDataProvider.Update(recipient);
        public void OnDeleteRecipientCommand(Recipient recipient) => _recipientDataProvider.Delete(recipient);

        public ICommand RefreshRecipientsCommand { get; }
        public ICommand AddRecipientCommand { get; }
        public ICommand UpdateRecipientCommand { get; }
        public ICommand DeleteRecipientCommand { get; }


        private void RefreshRecipients()
        {
            var recipients = Recipients;
            Recipients.Clear();
            foreach (var recipient in _recipientDataProvider.GetAll())
                recipients.Add(recipient);
        }
        #endregion
        #region Smtp_Servers
        public string Smtp_Server => SelectedSender?.smtp_address??"--";
        #endregion
    }
}