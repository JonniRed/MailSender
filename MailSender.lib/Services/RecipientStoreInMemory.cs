using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Entities;
using MailSender.lib.Data;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class RecipientStoreInMemory : IRecipientStore
    {
        public IEnumerable<Recipient> GetAll() => TestData.Recipient;
        public Recipient GetById(int Id) => TestData.Recipient.FirstOrDefault(r => r.Id == Id);
        public int Create(Recipient Recipient)
        {
            if (TestData.Recipient.Contains(Recipient)) return Recipient.Id;
            Recipient.Id = TestData.Recipient.Count == 0 ? 1 : TestData.Recipient.Max(r => r.Id) + 1;
            TestData.Recipient.Add(Recipient);
            return Recipient.Id;
        }
        public void Edit(int Id, Recipient recipient)
        {
            var db_recipient = GetById(Id);
            if (db_recipient is null) return;

            db_recipient.Name = recipient.Name;
            db_recipient.Adress = recipient.Adress;
        }
        public Recipient Remove (int Id)
        {
            var db_recipient = GetById(Id);
            if(db_recipient != null)
            TestData.Recipient.Remove(db_recipient);
            return db_recipient;
        }
        public void SaveChanges()
        {
            System.Diagnostics.Debug.WriteLine("Сохранение изменений в хранилище");
        }
    }
}
