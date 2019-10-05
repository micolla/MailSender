using MailSender.Lib.Entity.Base;
using System;


namespace MailSender.Lib.Entity
{
    public class SheduledTask : BaseEntity
    {
        public DateTime SheduledTime { get; set; }
        public Sender Sender { get; set; }
        public SMTPServer SMTPServer { get; set; }
        public RecipientsList RecipientsList { get; set; }
        public Email Email { get; set; }
    }

}
