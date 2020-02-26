using MailSender.lib.Data.EF;
using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Services.EF
{
   public class SenderStoreEF : StoreEF<Sender> 
    {
        public SenderStoreEF(MailSenderDB db) : base(db) { }
        public override void Edit(int Id, Sender item)
        {
            var db_item = GetById(Id);
            if (db_item == null) return;

            db_item.Name = item.Name;
            db_item.Adress = item.Adress;
        }
    }
}
