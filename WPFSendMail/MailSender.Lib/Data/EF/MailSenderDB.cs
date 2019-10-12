using MailSender.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib.Data.EF
{
    public class MailSenderDB : DbContext
    {
        //static MailSenderDB() =>
        //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailSenderDB, Migrations.Configuration>());
        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<RecipientsList> RecipientsLists { get; set; }

        public DbSet<SMTPServer> Servers { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<SheduledTask> SchedulerTasks { get; set; }


        public MailSenderDB() : this(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MailSenderDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False") { }

        public MailSenderDB(string Connection) : base(Connection) { }
    }
}
