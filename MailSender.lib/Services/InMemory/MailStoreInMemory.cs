using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using System.Linq;

namespace MailSender.lib.Services.InMemory
{
    public class MailStoreInMemory : DataStoreInMemory<Mail>, IMailStore
    {
        public MailStoreInMemory() : base(Enumerable.Range(1, 10).Select(i => new Mail { Id = i, Subject = $"Message {i}",
            Body = $"Message body {i}" }).ToList()) 
        {

        }
        public override void Edit(int Id, Mail mail)
        {
            var db_mail = GetById(Id);
            if (db_mail is null) return;

            db_mail.Subject = db_mail.Subject;
            db_mail.Body = db_mail.Body;
        }
    }
}