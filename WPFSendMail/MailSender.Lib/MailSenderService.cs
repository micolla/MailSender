using System;
using System.Security;
using System.Net;
using System.Net.Mail;
using MailSender.Lib.Entity;
using System.Linq;
using System.Collections.Generic;

namespace MailSender.Lib
{   
    public class MailSenderService
    {
        string host;
        int port;
        string user_name;
        string password;
        string message;
        string subject;
        string user_email;
        ICollection<Recipient> recipients;
        public MailSenderService(Sender sender, string message,string subject, ICollection<Recipient> recipients,
            SMTPServer server) 
            :this(sender,message,subject, server)
        {
            this.recipients = recipients;
        }
        public MailSenderService(Sender sender, string message, string subject, SMTPServer server) : this(sender, server)
        {
            this.message = message;
            this.subject = subject;
        }

        public MailSenderService(Sender sender,SMTPServer server)
        {
            this.host = server.Address;
            this.port = server.Port;
            this.user_email = sender.Email;
            this.user_name = sender.Login;
            this.password = sender.Password;
            this.message = "не указан текст";
            this.subject = "не указана тема";
        }
        /// <summary>
        /// Отправка почты внешнему списку адресатов
        /// </summary>
        /// <param name="recipients">список адресатов</param>
        /// <returns></returns>
        public SentState SendMails(ICollection<Recipient> recipients)
        {
            SentState tmpState = new SentState("Не указаны получатели", false);
            if (recipients.Count() > 0)
            {
                foreach (var item in recipients)
                {
                    tmpState = SendMail(item.Email, item.Name);
                    if (!tmpState.IsOk)
                        throw new InvalidOperationException(tmpState.Message);
                }
            }
            return tmpState;
        }
        /// <summary>
        /// Отправка писем внутреннему списку адресатов
        /// </summary>
        /// <returns></returns>
        public SentState SendMails()
        {
            return SendMails(this.recipients);
        }

        public SentState SendMail(string recipientEmail,string recipientName)
        {
            try
            {
                using (var client = new SmtpClient(host, port))
                {
                    client.EnableSsl = true;
                    //client.Credentials = new NetworkCredential(user_name, password);
                    client.Credentials = new NetworkCredential(user_name, PasswordDecoder.getPassword(password));
                    using (var message = new MailMessage() { Body = this.message, Subject = this.subject })
                    {
                        message.From = new MailAddress(this.user_email);
                        message.To.Add(new MailAddress(recipientEmail,recipientName));

                        client.Send(message);
                        return new SentState("Почта успешно отправлена", true);
                    }
                }
            }
            catch (Exception e)
            {
                return new SentState(e.Message, false);
            }
        }
    }
}
