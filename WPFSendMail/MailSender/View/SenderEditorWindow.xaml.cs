﻿using MailSender.Lib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailSender.View
{
    /// <summary>
    /// Логика взаимодействия для SenderEditorWindow.xaml
    /// </summary>
    public partial class SenderEditorWindow : Window
    {
        Sender Sender;
        public SenderEditorWindow(Sender sender)
        {
            InitializeComponent();
            Sender = sender;
            DataContext = Sender;
        }

        private void OnSaveButton(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void OnCancelButton(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}