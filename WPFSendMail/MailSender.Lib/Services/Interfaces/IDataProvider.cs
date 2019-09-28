using MailSender.Lib.Data.Linq2SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib.Services.Interfaces
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetAll();

        int Add(T sender);
        int Delete(T sender);

        void SaveChanges();
    }
}
