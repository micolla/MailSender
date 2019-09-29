using GalaSoft.MvvmLight;
using MailSender.Lib.Entity;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System;
using MailSender.View;
using MailSender.Lib.DataProviders.Interfaces;
using MailSender.Lib.Entity.Base;
using System.Collections.Generic;

namespace MailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(ISenderDataProvider senderDataProvider, IRecipientDataProvider recipientDataProvider, ISMTPServerDataProvider serverDataProvider)
        {
            #region Senders
            _senderDataProvider = senderDataProvider;
            RefreshSenders();
            RefreshSendersCommand = new RelayCommand(OnRefreshSenderCommand);
            AddSenderCommand = new RelayCommand(OnAddSenderCommand);
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
            #region SMTPServer
            _serverDataProvider = serverDataProvider;
            RefreshServers();
            AddServerCommand = new RelayCommand<SMTPServer>(OnAddServerCommand);
            UpdateServerCommand = new RelayCommand<SMTPServer>(OnUpdateServerCommand);
            DeleteServerCommand = new RelayCommand<SMTPServer>(OnDeleteServerCommand);
            #endregion
        }
        #region SMTPServer
        private ISMTPServerDataProvider _serverDataProvider;
        private ObservableCollection<SMTPServer> _Servers = new ObservableCollection<SMTPServer>();
        public ObservableCollection<SMTPServer> Servers
        {
            get => _Servers;
            set => Set(ref _Servers, value);
        }
        /// <summary>��������� �����������</summary>
        private SMTPServer _SelectedServer;

        /// <summary>��������� �����������</summary>
        public SMTPServer SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }
        public ICommand AddServerCommand { get; }
        public ICommand UpdateServerCommand { get; }
        public ICommand DeleteServerCommand { get; }
        private void RefreshServers()
        {
            var servers = Servers;
            Servers.Clear();
            foreach (var server in _serverDataProvider.GetAll())
                servers.Add(server);
        }
        private void OnDeleteServerCommand(SMTPServer obj)
        {
            throw new NotImplementedException();
        }

        private void OnUpdateServerCommand(SMTPServer obj)
        {
            throw new NotImplementedException();
        }

        private void OnAddServerCommand(SMTPServer obj)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Senders
        private ISenderDataProvider _senderDataProvider;
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
        private void OnAddSenderCommand()
        {
            Sender newSender = new Sender();
            var saved = false;
            var senderEditorVM = new SenderEditorViewModel(newSender);
            SenderEditorWindow senderEditorWindow = new SenderEditorWindow { DataContext = senderEditorVM };
            senderEditorVM.Save += (o, e) => { saved = true; senderEditorWindow.Close(); };
            senderEditorVM.Canceled += (o, e) => { senderEditorWindow.Close(); };
            senderEditorWindow.ShowDialog();
            if (saved)
            {
                Senders.Add(newSender);
                _senderDataProvider.Add(newSender);
            }
        }
        public void OnUpdateSenderCommand(Sender sender)
        {
            var saved = false;
            var senderEditorVM = new SenderEditorViewModel(sender);
            SenderEditorWindow senderEditorWindow = new SenderEditorWindow();
            senderEditorWindow.DataContext = senderEditorVM;
            senderEditorVM.Save += (o, e) => { saved = true; senderEditorWindow.Close(); };
            senderEditorVM.Canceled += (o, e) => { senderEditorWindow.Close(); };
            senderEditorWindow.ShowDialog();
            if (saved)
            {
                _senderDataProvider.Update(sender.Id, sender);
            }
        }
        public void OnDeleteSenderCommand(Sender sender) => _senderDataProvider.Delete(sender.Id,sender);

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
        private IRecipientDataProvider _recipientDataProvider;
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
        public void OnUpdateRecipientCommand(Recipient recipient) => throw new NotImplementedException("OnUpdateRecipientCommand");
        public void OnDeleteRecipientCommand(Recipient recipient) => _recipientDataProvider.Delete(recipient.Id,recipient);

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
    }
}