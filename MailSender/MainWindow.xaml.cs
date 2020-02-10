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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services;
using MailSender.lib.Service;


namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //SenderList.ItemsSource = TestData.Senders;

        }

        private void Button_click_pl(object sender, RoutedEventArgs e)
        {
            test.SelectedItem = pl;
            pl.Visibility = Visibility;
        }

        private void Click_button_send(object sender, RoutedEventArgs e)
        {
            
            if (MailBody.Text == "") MessageBox.Show("Введите текст");
        }

        private void OnSendButton(object Sender, RoutedEventArgs e)
        {
            //var recipient = RecipientsList.SelectedItem as Recipient;
            //var sender = SenderList.SelectedItem as Sender;
            //var server = ServersList.SelectedItem as Server;

            //if (recipient == null || sender == null || server == null) return;

            //var mail_sender = new DebugMailSender(server.Adress, server.Port, server.UseSsl, server.Login, server.Password.Decode(3));
            //mail_sender.Send(MailHeader.Text, MailBody.Text, sender.Adress, recipient.Adress);
        }

        private void OnSenderEditClick(object Sender, RoutedEventArgs e)
        {
            var sender = SenderList.SelectedItem as Sender;
            if (sender is null) return;

            var dialog = new SenderEditor(sender);

            if (dialog.ShowDialog() != true) return;
            sender.Name = dialog.NameValue;
            sender.Adress = dialog.AdressValue;
        }
    }
}
