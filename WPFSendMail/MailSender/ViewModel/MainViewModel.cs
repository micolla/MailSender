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
using MailServer.ViewModel;
using System.Windows.Documents;
using MailSender.Lib;
using System.Windows;

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
            AddServerCommand = new RelayCommand(OnAddServerCommand);
            UpdateServerCommand = new RelayCommand<SMTPServer>(OnUpdateServerCommand);
            DeleteServerCommand = new RelayCommand<SMTPServer>(OnDeleteServerCommand);
            #endregion
            #region SendMailNow
            SendMailNow = new RelayCommand(OnSendMailNow);
            #endregion
            #region SheduledMail
            CreateEmptyTask();            
            AddShedulerTask = new RelayCommand(OnAddShedulerTask);
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
        /// <summary>Выбранный отправитель</summary>
        private SMTPServer _SelectedServer;

        /// <summary>Выбранный отправитель</summary>
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
            var saved = false;
            var serverEditorVM = new ServerEditorVM(obj);
            ServerEditorWindow editorWindow = new ServerEditorWindow();
            editorWindow.DataContext = serverEditorVM;
            serverEditorVM.Save += (o, e) => { saved = true; editorWindow.Close(); };
            serverEditorVM.Canceled += (o, e) => { saved = false; editorWindow.Close(); };
            editorWindow.ShowDialog();
            if (saved)
            {
                _serverDataProvider.Update(obj.Id, obj);
            }
        }

        private void OnAddServerCommand()
        {
            SMTPServer newServer= new SMTPServer();
            var saved = false;
            var serverEditorVM = new ServerEditorVM(newServer);
            ServerEditorWindow senderEditorWindow = new ServerEditorWindow { DataContext = serverEditorVM };
            serverEditorVM.Save += (o, e) => { saved = true; senderEditorWindow.Close(); };
            serverEditorVM.Canceled += (o, e) => { senderEditorWindow.Close(); };
            senderEditorWindow.ShowDialog();
            if (saved)
            {
                Servers.Add(newServer);
                newServer.Id = _serverDataProvider.Add(newServer);
            }
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

        /// <summary>Выбранный отправитель</summary>
        private Sender _SelectedSender;

        /// <summary>Выбранный отправитель</summary>
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
                newSender.Id=_senderDataProvider.Add(newSender);
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

        /// <summary>Выбранный отправитель</summary>
        private Recipient _SelectedRecipient;

        /// <summary>Выбранный отправитель</summary>
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
        #region Mail
        private Email _Email = new Email();
        public Email Email
        {
            get => _Email;
            set => Set(ref _Email, value);
        }
        #endregion
        #region SendMailNow
        public ICommand SendMailNow { get; }
        private void OnSendMailNow()
        {
                MailSenderService mailSenderService
                    = new MailSenderService(SelectedSender, Email.Message, Email.Subject,SelectedServer);

                SentState sentState
                    = mailSenderService.SendMails(Recipients);
            ShowState(sentState);
        }

        #endregion
        #region SheduledTask
        MailSheduler _mailSheduler = new MailSheduler();
        public ICommand AddShedulerTask { get; }
        private SheduledTask _SheduledTask = new SheduledTask();
        public SheduledTask SheduledTask
        {
            get => _SheduledTask;
            set => Set(ref _SheduledTask, value);
        }
        private void CreateEmptyTask()
        {
            SheduledTask.Email = Email;
            RecipientsList recipientsList = new RecipientsList { Recipients= Recipients };
            SheduledTask.RecipientsList = recipientsList;
            SheduledTask.SMTPServer = SelectedServer;
            SheduledTask.Sender = SelectedSender;
        }
        private void OnAddShedulerTask()
        {
            _mailSheduler.AddTask(SheduledTask);
        }
        #endregion
        #region InformationWindow
        private static void ShowState(SentState sentState)
        {
            WPFInformationMessage w = new WPFInformationMessage(sentState.IsOk ? "Успех!" : "Ошибка!", sentState.Message);
            w.ShowDialog();
        }
        private static void ShowState(bool isOk, string Message)
        {
            WPFInformationMessage w = new WPFInformationMessage(isOk ? "Успех!" : "Ошибка!", Message);
            w.ShowDialog();
        }
        #endregion
        public ICommand ApplicationCloseCommand = new RelayCommand(() => Application.Current.Shutdown());
    }
}