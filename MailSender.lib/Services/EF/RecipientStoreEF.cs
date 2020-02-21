using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Entities;
using MailSender.lib.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MailSender.lib.Services.EF
{
    public class RecipientStoreEF : IRecipientStore
    {
        private readonly MailSenderDB _db;

        public RecipientStoreEF(MailSenderDB db)  =>_db = db; 

        public IEnumerable<Recipient> GetAll() => _db.Recipients.AsEnumerable();

        public Recipient GetById(int id) => _db.Recipients.FirstOrDefault(r => r.Id == id);

        public int Create(Recipient item)
        {
            _db.Recipients.Add(item);
            SaveChanges();
            return item.Id;
        }
        public void Edit(int Id, Recipient item)
        {
            if (item is null) throw new ArgumentException(nameof(item));
            var db_item = GetById(Id);
            db_item.Name = item.Name;
            db_item.Adress = item.Adress;
            SaveChanges();
        }

        public Recipient Remove(int Id)
        {
            var db_item = GetById(Id);
            if (db_item is null) return null;
            //   _db.Recipients.Remove(db_item);
            _db.Entry(db_item).State = EntityState.Deleted;
            SaveChanges();
            return db_item;
        }
        public void SaveChanges() => _db.SaveChanges();
    }
}
