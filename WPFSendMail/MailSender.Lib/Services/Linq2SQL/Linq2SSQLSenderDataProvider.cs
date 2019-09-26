using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.Data.Linq2SQL;
using MailSender.Lib.Services.Interfaces;

namespace MailSender.Lib.Services.Linq2SQL
{
    public class Linq2SSQLSenderDataProvider : ISenderDataProvider
    {
        private readonly MailSenderDBDataContext _db;

        public Linq2SSQLSenderDataProvider(MailSenderDBDataContext mailSenderDBDataContext)
        {
            _db = mailSenderDBDataContext;
        }
        public int AddSender(Sender sender)
        {
            throw new NotImplementedException();
        }

        public int DeleteSender(Sender sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sender> GetAll()
        {
            _db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
            return _db.Sender.ToArray();
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }

        public int UpdateSender(Sender sender)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            _db.Sender.InsertOnSubmit(sender);
            SaveChanges();
            return sender.sender_id;
        }
    }
}
