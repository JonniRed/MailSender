using System.Net.Mail;
using System.Net;
using MailSender.lib.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class MailSenderService : IMailSenderService
    {
        public IMailSender GetSender(Server Server) => new MailSender(Server);
    }
    public class MailSender : IMailSender
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
        public void Send(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To) 
                Send(Message, From, To);
        }
        public void SendParallel(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var recipient in To)
                ThreadPool.QueueUserWorkItem(_ => Send(Message, From, To));
        }

        public async Task SendAsync(Mail Mail, Sender From, Recipient To)
        {
            using (var message = new MailMessage(new MailAddress(From.Adress, From.Name),
               new MailAddress(To.Adress, To.Name)))
            {
                message.Subject = Mail.Subject;
                message.Body = Mail.Body;

                var login = new NetworkCredential(_Server.Login, _Server.Password);
                using (var client = new SmtpClient(_Server.Adress, _Server.Port)
                { EnableSsl = _Server.UseSsl, Credentials = login })
                    await client.SendMailAsync(message).ConfigureAwait(false);
            }

        }
       /* public async Task SendAsync(Mail Message, Sender From, IEnumerable<Recipient> To)
        {
            await Task.WhenAll(To.Select(Recipient => SendAsync(Message, From, To))).ConfigureAwait(false);
        }
        (Асинхронная параллельная обработка данных)*/
        public async Task SendAsync(Mail Message, Sender From, IEnumerable<Recipient> To,
            CancellationToken Cancel = default)
        {
            Cancel.ThrowIfCancellationRequested();
            foreach (var recipient in To) await SendAsync(Message, From, To).ConfigureAwait(false);
        }
        ///Асинхронная последовательная обработка данных
     }
 }
