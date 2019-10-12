using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.Entity;
using MailSender.Lib.DataProviders.Interfaces;

namespace MailSender.Lib.DataProviders.EF
{
    public class EFSenderDataProvider : ISenderDataProvider
    {
        private readonly Data.EF.MailSenderDB _db;

        public EFSenderDataProvider(Data.EF.MailSenderDB mailSenderDB) => _db = mailSenderDB;
        public Sender GetById(int id)
        {
            var db_item = _db.Senders.FirstOrDefault(r => r.Id == id);
            return db_item;
        }

        public int Add(Sender Sender)
        {
            if (Sender is null) throw new ArgumentNullException(nameof(Sender));
            if (Sender.Id != 0) return Sender.Id;
            _db.Senders.Add(Sender);
            _db.SaveChangesAsync();
            return Sender.Id;
        }

        public bool Delete(int id, Sender Sender)
        {
            var db_item = _db.Senders.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return false;

            _db.Senders.Remove(db_item);
            _db.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Sender> GetAll() =>
            _db.Senders;

        public void SaveChanges() => _db.SaveChanges();

        public void Update(int id, Sender Sender)
        {
            var db_item = _db.Senders.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return;
            db_item.Name = Sender.Name;
            db_item.Email = Sender.Email;
            db_item.Login = Sender.Login;
            db_item.Password = Sender.Password;
            _db.SaveChanges();
        }
    }
}
