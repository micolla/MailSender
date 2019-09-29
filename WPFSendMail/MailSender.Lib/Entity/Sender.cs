using MailSender.Lib.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MailSender.Lib.Entity
{
    public class Sender: HumanEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class RecipientsList : NamedEntity
    {
        ICollection<Recipient> Recipients { get; set; }
    }

    public class Email : BaseEntity
    {
        public string Message { get; set; }
        public string Subject { get; set; }
    }

    public class SheduledTask : BaseEntity
    {
        public DateTime SheduledTime { get; set; }
        public Sender Sender { get; set; }
        public SMTPServer SMTPServer { get; set; }
        public RecipientsList RecipientsList { get; set; }
        public Email Email { get; set; }
    }

}
