namespace MailSender.Lib.Entity.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        private string _name;
        public string Name {
            get =>_name;
            set { Set(ref _name, value); }
        }
    }
}
