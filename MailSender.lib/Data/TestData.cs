using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;
using MailSender.lib.Service;

namespace MailSender.lib.Data
{
    public class TestData
    {
        public static List<Server> Servers { get; } = new List<Server>
        {
            new Server {Id=1, Name = "Яндекс", Adress="smtp.yandex.ru", Port = 587, Login="UserLogin", Password = "Password".Encode(3)},
            new Server {Id=2, Name = "Mail.ru", Adress="smtp.yandex.ru", Port = 587, Login="UserLogin", Password = "Password".Encode(3)},
            new Server {Id=3, Name = "Gmail", Adress="smtp.gmail.com", Port = 587, Login="UserLogin", Password = "Password".Encode(3) }

        };
        public static List<Sender> Senders { get; } = new List<Sender>
        {
            new Sender {Id=1, Name = "Иванов", Adress = "ivanov@server.ru"},
            new Sender {Id=2, Name = "Петров", Adress = "petrov@server.ru"},
             new Sender {Id=3, Name = "Сидоров", Adress = "sidorov@server.ru"}
        };

        public static List<Recipient> Recipient { get; } = new List<Recipient>
        {
            new Recipient {Id=1, Name = "Иванов", Adress = "ivanov@server.ru"},
            new Recipient {Id=2, Name = "Петров", Adress = "petrov@server.ru"},
            new Recipient {Id=3, Name = "Сидоров", Adress = "sidorov@server.ru"}
        };

    }
}
