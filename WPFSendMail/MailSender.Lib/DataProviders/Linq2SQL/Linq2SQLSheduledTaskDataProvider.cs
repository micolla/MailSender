using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.DataProviders.Interfaces;
using MailSender.Lib.Entity;

namespace MailSender.Lib.DataProviders.Linq2SQL
{
    public class Linq2SQLSheduledTaskDataProvider : ISheduledTaskDataProvider
    {
        private Data.Linq2SQL.MailSenderDBDataContext _db;
        ICollection<Sender> _senders;
        ICollection<SMTPServer> _servers;
        ICollection<Recipient> _recipients;
        Email _email;
        public Linq2SQLSheduledTaskDataProvider(Data.Linq2SQL.MailSenderDBDataContext mailSenderDBDataContext
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
            return _db.Tasks.ToArray().Select((r) => MapDb(r));
        }
        SheduledTask MapDb(Data.Linq2SQL.Task task)
        {
            return new SheduledTask
            {
                Id = task.task_id,
                Email = _email,
                RecipientsList = new RecipientsList { Recipients = _recipients },
                Sender = _senders.FirstOrDefault((s) => s.Id == task.sender_sender_id),
                SheduledTime = DateTime.Now.AddMinutes(4),
                SMTPServer = _servers.FirstOrDefault((s) => s.Id == 1)
            };
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