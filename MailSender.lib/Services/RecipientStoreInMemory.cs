using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;
using MailSender.lib.Data;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class RecipientStoreInMemory : IRecipientStore
    {
        public IEnumerable<Recipient> GetAll() => TestData.Recipient;
        public void Edit(int Id, Recipient recipient) { }
        public void SaveChanges() { }
    }
}
