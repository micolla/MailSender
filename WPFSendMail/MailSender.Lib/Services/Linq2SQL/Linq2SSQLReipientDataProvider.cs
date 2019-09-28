using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.Data.Linq2SQL;
using MailSender.Lib.Services.Interfaces;

namespace MailSender.Lib.Services.Linq2SQL
{
    public class Linq2SSQLReipientDataProvider : IDataProvider<Recipient>
    {
        private readonly MailSenderDBDataContext _db;

        public Linq2SSQLReipientDataProvider(MailSenderDBDataContext mailSenderDBDataContext)
        {
            _db = mailSenderDBDataContext;
        }
        public int Add(Recipient sender)
        {
            throw new NotImplementedException();
        }

        public int Delete(Recipient sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipient> GetAll()
        {
            _db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            return _db.Recipient.ToArray();
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }

        public int Update(Recipient recipient)
        {
            if (recipient == null)
                throw new ArgumentNullException(nameof(recipient));
            _db.Recipient.InsertOnSubmit(recipient);
            SaveChanges();
            return recipient.recipient_id;
        }
    }
}
