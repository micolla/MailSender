using MailSender.Lib.Entity.Base;


namespace MailSender.Lib.Entity
{
    public class SMTPServer : BaseEntity
    {
        private int _port;
        private string _address;
        public int Port { get => _port; set => Set(ref _port, value); }
        public string Address { get => _address; set => Set(ref _address, value); }
    }
}
