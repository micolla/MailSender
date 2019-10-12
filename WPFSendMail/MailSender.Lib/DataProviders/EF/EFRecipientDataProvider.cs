using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.Entity;
using MailSender.Lib.DataProviders.Interfaces;

namespace MailSender.Lib.DataProviders.EF
{
    public class EFRecipientDataProvider : IRecipientDataProvider
    {
        private readonly Data.EF.MailSenderDB _db;

        public EFRecipientDataProvider(Data.EF.MailSenderDB mailSenderDBDataContext)=>_db = mailSenderDBDataContext;
        public Recipient GetById(int id)
        {
            var db_item = _db.Recipients.FirstOrDefault(r => r.Id == id);
            return db_item;
        }

        public int Add(Recipient recipient)
        {
            if (recipient is null) throw new ArgumentNullException(nameof(recipient));
            if (recipient.Id != 0) return recipient.Id;
            _db.Recipients.Add(recipient);
            SaveChanges();
            return recipient.Id;
        }

        public bool Delete(int id, Recipient recipient)
        {
            var db_item = _db.Recipients.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return false;

            _db.Recipients.Remove(db_item);
            SaveChanges();
            return true;
        }

        public IEnumerable<Recipient> GetAll()=>
            _db.Recipients;

        public void SaveChanges()=>_db.SaveChanges();

        public void Update(int id, Recipient recipient)
        {
            var db_item = _db.Recipients.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return;
            db_item.Name = recipient.Name;
            db_item.Email = recipient.Email;
            SaveChanges();
        }
    }
}
