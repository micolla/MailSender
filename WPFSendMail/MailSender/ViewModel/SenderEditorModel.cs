using GalaSoft.MvvmLight;
using MailSender.Lib.Entity;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System;
using MailSender.Lib;

namespace MailSender.ViewModel
{
    public class SenderEditorViewModel : ViewModelBase
    {
        private Sender _Sender;
        public Sender Sender
        {
            get => _Sender;
            set => Set(ref _Sender, value);
        }
        public string UserPassword
        {
            get => PasswordDecoder.getPassword(Sender.Password);
            set => Sender.Password = PasswordDecoder.getCodPassword(value);
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public event EventHandler Save;
        public event EventHandler Canceled;
        public SenderEditorViewModel(Sender sender)
        {
            Sender = sender;
            SaveCommand = new RelayCommand(OnSaveCommand);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }

        private void OnSaveCommand() => Save?.Invoke(this, EventArgs.Empty);
        private void OnCancelCommand() => Canceled?.Invoke(this, EventArgs.Empty);
    }
}