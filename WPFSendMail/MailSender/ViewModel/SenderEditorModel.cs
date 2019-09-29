using GalaSoft.MvvmLight;
using MailSender.Lib.Services.Interfaces;
using MailSender.Lib.Data.Linq2SQL;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System;
using System.ComponentModel;
using MailSender.Lib;

namespace MailSender.ViewModel
{
    public class SenderEditorViewModel : ViewModelBase
    {
        private Sender _Sender;

        /// <summary>Выбранный получатель</summary>
        public Sender Sender
        {
            get => _Sender;
            set => Set(ref _Sender, value);
        }
        public string UserPassword {
            get => PasswordDecoder.getPassword(Sender?.password ?? String.Empty);
            set=>Sender.password=PasswordDecoder.getCodPassword(value);
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public event EventHandler Save;
        public event EventHandler Canceled;
        public SenderEditorViewModel()
        {
            SaveCommand = new RelayCommand(OnSaveCommand);
            CancelCommand = new RelayCommand(OnSaveCommand);
        }

        private void OnSaveCommand() => Save?.Invoke(this,EventArgs.Empty);
        private void OnCancelCommand() => Canceled?.Invoke(this, EventArgs.Empty);
    }
}