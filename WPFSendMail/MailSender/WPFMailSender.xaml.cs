using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using MailSender.Lib;
using MailSender.Lib.Data.Linq2SQL;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для WPFMailSender.xaml
    /// </summary>
    public partial class WPFMailSender : Window
    {
        //private MailSheduler Sheduler;
        public WPFMailSender()
        {
            InitializeComponent();
            //Sheduler = new MailSheduler();
            //Sheduler.MailIsSend += ShowState;
        }

        private void GoToShedullerButton_Click(object sender, RoutedEventArgs e)
        {
            this.FormTabs.SelectedIndex = 1;
        }


        /// <summary>
        /// Запланировать отправку письма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendSheduledMail_Click(object sender, RoutedEventArgs e)
        {
            //if (!this.SendMailDateTimePicker.Value.HasValue ||
            //    this.SendMailDateTimePicker.Value.Value <= DateTime.Now)
            //    ShowState(false, "воспользуйтесь отправкой сразу");
            //else
            //{
            //    TextRange textRange = new TextRange(MessageEditor.Document.ContentStart, MessageEditor.Document.ContentEnd);
            //    if (!string.IsNullOrEmpty(textRange.Text))
            //    {
            //        MailSenderService mailSenderService
            //            = new MailSenderService((Sender)this.SenderBox.SelectedItem
            //            , textRange.Text, "Empty subject"
            //            , (IQueryable<Recipient>)this.RecipientsGrid.ItemsSource);
            //        Sheduler.AddTask(new Task(this.SendMailDateTimePicker.Value.Value
            //        , mailSenderService));
            //    }
            //}
        }
    }
}
