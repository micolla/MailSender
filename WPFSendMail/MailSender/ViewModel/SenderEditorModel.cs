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
        MainViewModel MainViewModel;

        private Sender _Sender;

        /// <summary>Выбранный получатель</summary>
        public Sender Sender
        {
            get => _Sender;
            set => Set(ref _Sender, value);
        }
        public string SenderName
        {
            get => Sender.login;
        }
        public string UserPassword {
            get => "11";// PasswordDecoder.getPassword(Sender.password)??String.Empty;
            set=>Sender.password=PasswordDecoder.getCodPassword(value);
        }

        public ICommand SaveCommand;
        public ICommand CancelCommand;

        public SenderEditorViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            SaveCommand = new RelayCommand(OnSaveCommand);
            CancelCommand = new RelayCommand(OnSaveCommand);
        }

        private void OnSaveCommand() => MainViewModel.SenderChangeOK = true;
        private void OnCancelCommand() => MainViewModel.SenderChangeOK = false;
    }
}