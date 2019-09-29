using MailSender.Lib.Entity.Base;


namespace MailSender.Lib.Entity
{
    public class Email : BaseEntity
    {
        private string _message;
        private string _subject;
        public string Message { get => _message; set => Set(ref _message, value); }
        public string Subject { get => _subject; set => Set(ref _subject, value); }

    }

}
