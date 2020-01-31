using System;
using System.Windows;
using System.Net;
using System.Net.Mail;


namespace TestWPF
{
    
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        
        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            var message_subject = $"Текстовое сообщение от {DateTime.Now}";
            var message_body = $"Тело сообщения - {DateTime.Now}";

            const string from = "joil.paderina@yandex.ru";
            const string to = "joil.paderina@gmail.com";

            try
            {
                using (var message = new MailMessage(from, to))
                {
                    message.Subject = message_subject;
                    message.Body = message_body;


                    const string host = "smtp.yandex.ru";
                    const int port = 25;
                    using (var client = new SmtpClient(host, port))
                    {
                        client.EnableSsl = true;
                        var user_name = UserNameEdit.Text;
                        System.Security.SecureString secure_password = PasswordEdit.SecurePassword;

                        client.Credentials = new NetworkCredential(user_name, secure_password);
                        client.Send(message);

                        MessageBox.Show("Письмо успешно отправлено!", "Y", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
