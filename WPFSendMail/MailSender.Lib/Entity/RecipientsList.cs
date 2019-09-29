using MailSender.Lib.Entity.Base;
using System.Collections.Generic;


namespace MailSender.Lib.Entity
{
    public class RecipientsList : NamedEntity
    {
        ICollection<Recipient> Recipients { get; set; }
    }

}
