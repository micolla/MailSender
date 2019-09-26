using MailSender.Lib.Data.Linq2SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib.Services.Interfaces
{
    public interface ISenderDataProvider
    {
        IEnumerable<Sender> GetAll();

        int AddSender(Sender sender);
        int UpdateSender(Sender sender);
        int DeleteSender(Sender sender);

        void SaveChanges();
    }
}
