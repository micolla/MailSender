using MailSender.Lib.Entity.Base;
using System.Collections.Generic;


namespace MailSender.Lib.Entity
{
    public class RecipientsList : NamedEntity
    {
        ICollection<Recipient> _Recipients;
        public ICollection<Recipient> Recipients { get => _Recipients; set => Set(ref _Recipients, value); }
    }

}
