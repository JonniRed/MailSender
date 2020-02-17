using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MailSender.lib.Entities;
using MailSender.ViewModels;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для SenderEditor.xaml
    /// </summary>
    public partial class SenderEditor : Window
    {
        private MainWindow _MainWindow;
        public string NameValue { get => NameEditor.Text; set => NameEditor.Text = value; }
        public string AdressValue { get => AdressEditor.Text; set => AdressEditor.Text = value; }
        public SenderEditor(Sender Sender, MainWindow MainWindow)
        {
            InitializeComponent();
            NameValue = Sender.Name;
            AdressValue = Sender.Adress;
            _MainWindow = MainWindow;
        }

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
