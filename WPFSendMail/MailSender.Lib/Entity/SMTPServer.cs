using MailSender.Lib.Entity.Base;


namespace MailSender.Lib.Entity
{
    public class SMTPServer : BaseEntity
    {
        public int Port { get; set; }
        public string Address { get; set; }
    }
}
