using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib
{
    public class Task
    {
        DateTime SheduledDate;
        MailSenderService MailSenderService;
        bool IsActual;
        public Task(DateTime sheduledDate, MailSenderService mailSenderService)
        {
            SheduledDate = sheduledDate;
            MailSenderService = mailSenderService;
            IsActual = true;
        }

        public bool IsTime() => SheduledDate == DateTime.Now.Date && IsActual ? true : false;
        
        public SentState DoTask()
        {
            SentState resultState = MailSenderService.SendMails();
            IsActual = false;
            return resultState;
        }
    }
}
