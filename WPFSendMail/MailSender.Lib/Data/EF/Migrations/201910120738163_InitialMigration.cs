namespace MailSender.Lib.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        RecipientsList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipientsLists", t => t.RecipientsList_Id)
                .Index(t => t.RecipientsList_Id);
            
            CreateTable(
                "dbo.RecipientsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SheduledTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SheduledTime = c.DateTime(nullable: false),
                        Email_Id = c.Int(),
                        RecipientsList_Id = c.Int(),
                        Sender_Id = c.Int(),
                        SMTPServer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emails", t => t.Email_Id)
                .ForeignKey("dbo.RecipientsLists", t => t.RecipientsList_Id)
                .ForeignKey("dbo.Senders", t => t.Sender_Id)
                .ForeignKey("dbo.SMTPServers", t => t.SMTPServer_Id)
                .Index(t => t.Email_Id)
                .Index(t => t.RecipientsList_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.SMTPServer_Id);
            
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SMTPServers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Port = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SheduledTasks", "SMTPServer_Id", "dbo.SMTPServers");
            DropForeignKey("dbo.SheduledTasks", "Sender_Id", "dbo.Senders");
            DropForeignKey("dbo.SheduledTasks", "RecipientsList_Id", "dbo.RecipientsLists");
            DropForeignKey("dbo.SheduledTasks", "Email_Id", "dbo.Emails");
            DropForeignKey("dbo.Recipients", "RecipientsList_Id", "dbo.RecipientsLists");
            DropIndex("dbo.SheduledTasks", new[] { "SMTPServer_Id" });
            DropIndex("dbo.SheduledTasks", new[] { "Sender_Id" });
            DropIndex("dbo.SheduledTasks", new[] { "RecipientsList_Id" });
            DropIndex("dbo.SheduledTasks", new[] { "Email_Id" });
            DropIndex("dbo.Recipients", new[] { "RecipientsList_Id" });
            DropTable("dbo.SMTPServers");
            DropTable("dbo.Senders");
            DropTable("dbo.SheduledTasks");
            DropTable("dbo.RecipientsLists");
            DropTable("dbo.Recipients");
            DropTable("dbo.Emails");
        }
    }
}
