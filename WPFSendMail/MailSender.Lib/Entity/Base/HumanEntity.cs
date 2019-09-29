namespace MailSender.Lib.Entity.Base
{
    public abstract class HumanEntity : NamedEntity
    {
        private string _email;
        public string Email {
            get =>_email;
            set { Set(ref _email, value); }
        }
    }
}
