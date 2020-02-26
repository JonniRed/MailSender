using MailSender.lib.Data.EF;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Services.EF
{
    public class MailsStoreEF : StoreEF<Mail>, IMailStore
    {
        public MailsStoreEF(MailSenderDB db) : base(db) { }
        public override void Edit(int Id, Mail item) 
        {
            var db_item = GetById(Id);
            if (db_item == null) return;

            db_item.Subject = item.Subject;
            db_item.Body = item.Body;
        }
    }
    
}
