using GalaSoft.MvvmLight;
using MailSender.Lib.Entity;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System;
using MailSender.Lib;
using MailSender.ViewModel.BaseEditorVM;

namespace MailSender.ViewModel
{
    public class SenderEditorViewModel : BaseEditorVM<Sender>
    {
        public SenderEditorViewModel(Sender entity) : base(entity) { }
        public string UserPassword
        {
            get => PasswordDecoder.getPassword(Entity.Password ?? String.Empty);
            set => Entity.Password = PasswordDecoder.getCodPassword(value);
        }
    }
}