using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.DataProviders.Interfaces;
using MailSender.Lib.Entity;

namespace MailSender.Lib.DataProviders.Linq2SQL
{
    public class Linq2SQLSMTPServerDataProvider : ISMTPServerDataProvider
    {
        private readonly Data.Linq2SQL.MailSenderDBDataContext _db;

        public Linq2SQLSMTPServerDataProvider(Data.Linq2SQL.MailSenderDBDataContext mailSMTPServerDBDataContext) => _db = mailSMTPServerDBDataContext;
        public SMTPServer GetById(int id)
        {
            var db_item = _db.Server_smtps.FirstOrDefault(r => r.server_id == id);
            return db_item is null ? null : MapDB2Entity(db_item);
        }

        private static SMTPServer MapDB2Entity(Data.Linq2SQL.Server_smtp db_item) => new SMTPServer
        {
            Id = db_item.server_id,
            Port=db_item.port,
            Address = db_item.address
        };

        public int Add(SMTPServer SMTPServer)
        {
            if (SMTPServer is null) throw new ArgumentNullException(nameof(SMTPServer));
            if (SMTPServer.Id != 0) return SMTPServer.Id;

            var entity = new Data.Linq2SQL.Server_smtp
            {
                port = SMTPServer.Port,
                address = SMTPServer.Address
            };
            _db.Server_smtps.InsertOnSubmit(entity);
            SaveChanges();
            return entity.server_id;
        }

        public bool Delete(int id, SMTPServer SMTPServer)
        {
            var db_item = _db.Server_smtps.FirstOrDefault(r => r.server_id == id);
            if (db_item is null) return false;

            _db.Server_smtps.DeleteOnSubmit(db_item);
            SaveChanges();
            return true;
        }

        public IEnumerable<SMTPServer> GetAll() =>
            _db.Server_smtps.ToArray().Select(r => MapDB2Entity(r));

        public void SaveChanges() => _db.SubmitChanges();

        public void Update(int id, SMTPServer SMTPServer)
        {
            var db_item = _db.Server_smtps.FirstOrDefault(r => r.server_id == id);
            if (db_item is null) return;
            db_item.port = SMTPServer.Port;
            db_item.address = SMTPServer.Address;
            SaveChanges();
        }
    }
}
