using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Server : NamedEntity
    {
        public string Adress { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; } = true;

        public string Login { get; set;}
        public string Password { get; set; }

    }
}
