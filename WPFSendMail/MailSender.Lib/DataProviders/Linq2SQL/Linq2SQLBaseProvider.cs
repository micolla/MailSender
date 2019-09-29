using MailSender.Lib.DataProviders.Interfaces;
using MailSender.Lib.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib.DataProviders.Linq2SQL
{
    public class Linq2SQLBaseProvider<T> : IDataProvider<T> where T : BaseEntity
    {
        protected readonly List<T> _Items = new List<T>();
        public int Add(T Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id, T Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll() => _Items;

        public T GetById(int id) => _Items.FirstOrDefault(item => item.Id == id);

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
