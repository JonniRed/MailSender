using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Data;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.InMemory
{
    public class SenderStoreInMemory : DataStoreInMemory<Sender>, ISenderStore
    {
        public SenderStoreInMemory() : base(TestData.Senders) { }
        public override void Edit(int Id, Sender sender)
        {
            var db_sender = GetById(Id);
            if (db_sender is null) return;

            db_sender.Name = sender.Name;
            db_sender.Adress = sender.Adress;
         }
    }
}
