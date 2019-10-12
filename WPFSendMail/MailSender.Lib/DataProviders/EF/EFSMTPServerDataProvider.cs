using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.DataProviders.Interfaces;
using MailSender.Lib.Entity;

namespace MailSender.Lib.DataProviders.EF
{
    public class EFSMTPServerDataProvider : ISMTPServerDataProvider
    {
        private readonly Data.EF.MailSenderDB _db;

        public EFSMTPServerDataProvider(Data.EF.MailSenderDB mailSMTPServerDBDataContext) => _db = mailSMTPServerDBDataContext;
        public SMTPServer GetById(int id)
        {
            var db_item = _db.Servers.FirstOrDefault(r => r.Id == id);
            return db_item;
        }
        public int Add(SMTPServer SMTPServer)
        {
            if (SMTPServer is null) throw new ArgumentNullException(nameof(SMTPServer));
            if (SMTPServer.Id != 0) return SMTPServer.Id;
            _db.Servers.Add(SMTPServer);
            SaveChanges();
            return SMTPServer.Id;
        }

        public bool Delete(int id, SMTPServer SMTPServer)
        {
            var db_item = _db.Servers.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return false;

            _db.Servers.Remove(db_item);
            SaveChanges();
            return true;
        }

        public IEnumerable<SMTPServer> GetAll() =>
            _db.Servers;

        public void SaveChanges() => _db.SaveChanges();

        public void Update(int id, SMTPServer SMTPServer)
        {
            var db_item = _db.Servers.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return;
            db_item.Port = SMTPServer.Port;
            db_item.Address = SMTPServer.Address;
            SaveChanges();
        }
    }
}
