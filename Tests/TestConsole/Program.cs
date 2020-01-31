using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.Mail.MailMessage msg = new MailMessage ("sender@server.ru", "recipient@server.ru");
            msg.Subject = "Тема сообщения";
            msg.Body = "Тело сообщения";
            msg.IsBodyHtml = false;
            msg.Attachments.Add(new Attachment("c:\\file.exe"));

            System.Net.Mail.SmtpClient client = new SmtpClient ("smtp@yandex.ru", 25);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("UserNane", "Password");

            client.Send(msg);

            Console.WriteLine("Hello World!");
        }
    }
}
