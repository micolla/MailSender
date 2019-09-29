using MailSender.Lib.Entity.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MailSender.Lib.Entity
{
    public class Sender: HumanEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
