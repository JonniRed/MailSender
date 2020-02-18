using System.Diagnostics;
using MailSender.lib.Entities;

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
     }
}
