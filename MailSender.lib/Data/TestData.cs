using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;

namespace MailSender.lib.Data
{
    public class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server {Name = "Яндекс", Adress="smtp.yandex.ru", Port = 587, Login="UserLogin", Password = "UserPassord" }
        }
        public static List<Sender> Senders { get; }
        }
    }
}
