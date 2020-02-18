using System.Net.Mail;
using System.Net;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private readonly Server _Server;

        public MailSender(Server Server) => _Server = Server;

        public void Send(Mail Mail, Sender From, Recipient To)
        {
            using (var message = new MailMessage(new MailAddress(From.Adress, From.Name),
                new MailAddress(To.Adress, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var login = new NetworkCredential(_Server.Login, _Server.Password);
                using (var client = new SmtpClient(_Server.Adress, _Server.Port)
                { EnableSsl = _Server.UseSsl, Credentials = login })
                    client.Send(message);

            }
        }
    }

    
}
