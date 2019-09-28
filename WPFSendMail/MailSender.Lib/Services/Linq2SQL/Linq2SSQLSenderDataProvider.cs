using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.Data.Linq2SQL;
using MailSender.Lib.Services.Interfaces;

namespace MailSender.Lib.Services.Linq2SQL
{
    public class Linq2SSQLSenderDataProvider : IDataProvider<Sender>
    {
        private readonly MailSenderDBDataContext _db;

        public Linq2SSQLSenderDataProvider(MailSenderDBDataContext mailSenderDBDataContext)
        {
            _db = mailSenderDBDataContext;
        }
        public int Add(Sender sender)
        {
            _db.Sender.InsertOnSubmit(sender);
            return sender.sender_id;
        }

        public int Delete(Sender sender)
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
    }
}
