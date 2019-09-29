using MailSender.Lib.Entity.Base;


namespace MailSender.Lib.Entity
{
    public class Email : BaseEntity
    {
        public string Message { get; set; }
        public string Subject { get; set; }
    }

}
