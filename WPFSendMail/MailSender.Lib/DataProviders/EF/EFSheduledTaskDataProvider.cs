using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.DataProviders.Interfaces;
using MailSender.Lib.Entity;

namespace MailSender.Lib.DataProviders.EF
{
    public class EFSheduledTaskDataProvider : ISheduledTaskDataProvider
    {
        private Data.EF.MailSenderDB _db;
        ICollection<Sender> _senders;
        ICollection<SMTPServer> _servers;
        ICollection<Recipient> _recipients;
        Email _email;
        public EFSheduledTaskDataProvider(Data.EF.MailSenderDB mailSenderDBDataContext
            , ICollection<Sender> senders, ICollection<SMTPServer> servers, ICollection<Recipient> recipients
            , Email email)
        {
            _db = mailSenderDBDataContext;
            _senders = senders;
            _servers = servers;
            _recipients = recipients;
            _email = email;
        }
        public int Add(SheduledTask Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, SheduledTask Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SheduledTask> GetAll()
        {
            return _db.SchedulerTasks;
        }
        

        public SheduledTask GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, SheduledTask Entity)
        {
            throw new NotImplementedException();
        }
    }
}