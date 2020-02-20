using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using MailSender.lib.Entities;
using System.Threading;

namespace MailSender.lib
{
    public class DebugMailSender
    {
        private readonly Server _Server;

        public DebugMailSender(Server Server) => _Server = Server;
      
        public void Send(Mail mail, Sender from, Recipient to)
        {
            Debug.WriteLine("Отправка почты от {0} к {1} через {2}:{3}[4]", from.Adress, to.Adress, _Server.Adress,
               _Server.Port, _Server.UseSsl ? "SSL" : "no SSL", mail.Subject, mail.Body);
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
    }
}
