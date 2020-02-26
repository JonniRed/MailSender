using MailSender.lib.Data.EF;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Services.EF
{
   public class ServerStoreEF : StoreEF<Server>//, IServerStore
    {
        public ServerStoreEF(MailSenderDB db) : base(db) { }

        public override void Edit(int Id, Server item)
        {
            var db_item = GetById(Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Adress = item.Adress;
            db_item.Port = item.Port;
            db_item.UseSsl = item.UseSsl;
            db_item.Login = item.Login;
            db_item.Password = item.Password;
        }
    }
}
