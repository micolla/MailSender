using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.Entity;
using MailSender.Lib.DataProviders.Interfaces;

namespace MailSender.Lib.DataProviders.Linq2SQL
{
    public class Linq2SQLSenderDataProvider : ISenderDataProvider
    {
        private readonly Data.Linq2SQL.MailSenderDBDataContext _db;

        public Linq2SQLSenderDataProvider(Data.Linq2SQL.MailSenderDBDataContext mailSenderDBDataContext) => _db = mailSenderDBDataContext;
        public Sender GetById(int id)
        {
            var db_item = _db.Sender.FirstOrDefault(r => r.sender_id == id);
            return db_item is null ? null : MapDB2Entity(db_item);
        }

        private static Sender MapDB2Entity(Data.Linq2SQL.Sender db_item) => new Sender
        {
            Id = db_item.sender_id,
            Name = db_item.name,
            Login=db_item.login,
            Password=db_item.password,
            Email = db_item.email
        };

        public int Add(Sender Sender)
        {
            if (Sender is null) throw new ArgumentNullException(nameof(Sender));
            if (Sender.Id != 0) return Sender.Id;

            var entity = new Data.Linq2SQL.Sender
            {
                name = Sender.Name,
                email = Sender.Email
            };
            _db.Sender.InsertOnSubmit(entity);
            SaveChanges();
            return entity.sender_id;
        }

        public bool Delete(int id, Sender Sender)
        {
            var db_item = _db.Sender.FirstOrDefault(r => r.sender_id == id);
            if (db_item is null) return false;

            _db.Sender.DeleteOnSubmit(db_item);
            SaveChanges();
            return true;
        }

        public IEnumerable<Sender> GetAll() =>
            _db.Sender.ToArray().Select(r => MapDB2Entity(r));

        public void SaveChanges() => _db.SubmitChanges();

        public void Update(int id, Sender Sender)
        {
            var db_item = _db.Sender.FirstOrDefault(r => r.sender_id == id);
            if (db_item is null) return;
            db_item.name = Sender.Name;
            db_item.email = Sender.Email;
            SaveChanges();
        }
    }
}
