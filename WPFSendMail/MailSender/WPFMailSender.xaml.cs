using System;
using System.Linq;
using System.Windows;
using MailSender.Lib;
using MailSender.Lib.Data.Linq2SQL;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для WPFMailSender.xaml
    /// </summary>
    public partial class WPFMailSender : Window
    {
        public WPFMailSender()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GoToShedullerButton_Click(object sender, RoutedEventArgs e)
        {
            this.FormTabs.SelectedIndex = 1;
        }

        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsAllFieldsFilled())
            {
                MailSenderService mailSenderService
                    = new MailSenderService((Sender)this.SenderBox.SelectedItem);

                SentState sentState 
                    = mailSenderService.SendMails((IQueryable<Recipient>)this.RecipientsGrid.ItemsSource);
                ShowState(sentState);
            }
        }

        private static void ShowState(SentState sentState)
        {
            WPFInformationMessage w = new WPFInformationMessage(sentState.IsOk ? "Успех!" : "Ошибка!", sentState.Message);
            w.ShowDialog();
        }

        /// <summary>
        /// Заглушка для проверки полей на заполнение
        /// </summary>
        /// <returns></returns>
        private bool IsAllFieldsFilled()
        {
            return true;
        }
    }
}
