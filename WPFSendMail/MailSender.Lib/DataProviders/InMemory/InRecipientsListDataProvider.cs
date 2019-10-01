using MailSender.Lib.DataProviders.Interfaces;
using MailSender.Lib.Entity;
using System;
using System.Collections.Generic;

namespace MailSender.Lib.DataProviders.InMemory
{
    public class InRecipientsListDataProvider : IRecipientsListDataProvider
    {
        public int Add(RecipientsList Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, RecipientsList Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecipientsList> GetAll()
        {
            throw new NotImplementedException();
        }

        public RecipientsList GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, RecipientsList Entity)
        {
            throw new NotImplementedException();
        }
    }
}
