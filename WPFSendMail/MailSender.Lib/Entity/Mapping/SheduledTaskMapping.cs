namespace MailSender.Lib.Entity.Mapping
{
    public static class SheduledTaskMapping
    {
        public static Task ToTask(this SheduledTask sheduledTask)
        {
            return new Task(sheduledTask.SheduledTime,
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
