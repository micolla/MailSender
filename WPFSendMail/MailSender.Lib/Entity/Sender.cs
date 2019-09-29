using MailSender.Lib.Entity.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MailSender.Lib.Entity
{
    public class Sender: HumanEntity
    {
        private string _login;
        private string _password;
        public string Login { get => _login; set => Set(ref _login, value); }
        public string Password { get => _password; set => Set(ref _password, value); }
    }
}
