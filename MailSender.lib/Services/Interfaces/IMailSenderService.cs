using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    public interface IMailSenderService//тот, кто создаёт МэйлСэндер
    {
        IMailSender GetSender(Server Server);
    }
    public interface IMailSender//тот, кто занимается рассылкой почты
    {
        void Send(Mail Mail, Sender From, Recipient To);
        void Send(Mail Message, Sender From, IEnumerable<Recipient> To);
        Task SendAsync(Mail Mail, Sender From, Recipient To);
        Task SendAsync(Mail Message, Sender From, IEnumerable<Recipient> To,
            CancellationToken Cancel = default);
    }
}
