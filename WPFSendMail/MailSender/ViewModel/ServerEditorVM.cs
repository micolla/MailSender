using MailSender.Lib.Entity;
using MailSender.ViewModel.BaseEditorVM;

namespace MailServer.ViewModel
{
    public class ServerEditorVM : BaseEditorVM<SMTPServer>
    {
        public ServerEditorVM(SMTPServer entity) : base(entity) { }
    }
}
