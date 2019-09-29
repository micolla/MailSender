using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.Entity;
using MailSender.Lib.DataProviders.Interfaces;

namespace MailSender.Lib.DataProviders.Linq2SQL
{
    public class Linq2SQLRecipientDataProvider : IRecipientDataProvider
    {
        private readonly Data.Linq2SQL.MailSenderDBDataContext _db;

        public Linq2SQLRecipientDataProvider(Data.Linq2SQL.MailSenderDBDataContext mailSenderDBDataContext)=>_db = mailSenderDBDataContext;
        public Recipient GetById(int id)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.recipient_id == id);
            return db_item is null ? null : MapDB2Entity(db_item);
        }

        private static Recipient MapDB2Entity(Data.Linq2SQL.Recipient db_item)=>new Recipient
            {
                Id = db_item.recipient_id,
                Name = db_item.name,
                Email = db_item.email
            };

        public int Add(Recipient recipient)
        {
            if (recipient is null) throw new ArgumentNullException(nameof(recipient));
            if (recipient.Id != 0) return recipient.Id;

            var entity = new Data.Linq2SQL.Recipient
            {
                name = recipient.Name,
                email = recipient.Email
            };
            _db.Recipient.InsertOnSubmit(entity);
            SaveChanges();
            return entity.recipient_id;
        }

        public bool Delete(int id, Recipient recipient)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.recipient_id == id);
            if (db_item is null) return false;

            _db.Recipient.DeleteOnSubmit(db_item);
            SaveChanges();
            return true;
        }

        public IEnumerable<Recipient> GetAll()=>
            _db.Recipient.ToArray().Select(r=> MapDB2Entity(r));

        public void SaveChanges()=>_db.SubmitChanges();

        public void Update(int id, Recipient recipient)
        {
            var db_item = _db.Recipient.FirstOrDefault(r => r.recipient_id == id);
            if (db_item is null) return;
            db_item.name = recipient.Name;
            db_item.email = recipient.Email;
            SaveChanges();
        }
    }
}
