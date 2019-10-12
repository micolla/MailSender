namespace MailSender.Lib.Entity.Mapping
{
    public static class SheduledTaskMapping
    {
        public static MailTask ToTask(this SheduledTask sheduledTask)
        {
            return new MailTask(sheduledTask.SheduledTime,
                new MailSenderService(
                    sheduledTask.Sender,
                    sheduledTask.Email.Subject,
                    sheduledTask.Email.Message,
                    sheduledTask.RecipientsList.Recipients,
                    sheduledTask.SMTPServer
                    ));
        }
    }
}
