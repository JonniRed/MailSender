using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Data;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.InMemory
{
    public class ServerStoreInMemory : DataStoreInMemory<Server>, IServerStore
    { 
        public ServerStoreInMemory() : base(TestData.Servers) { }
        public override void Edit(int Id, Server server)
        {
            var db_server = GetById(Id);
            if (db_server is null) return;

            db_server.Name = db_server.Name;
            db_server.Adress = db_server.Adress;
            db_server.Port = db_server.Port;
            db_server.UseSsl = db_server.UseSsl;
            db_server.Login = db_server.Login;
            db_server.Password = db_server.Password;
        }
    }
}