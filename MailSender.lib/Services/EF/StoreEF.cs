﻿using MailSender.lib.Data.EF;
using MailSender.lib.Entities.Base;
using MailSender.lib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSender.lib.Services.EF
{
    public abstract class StoreEF<T> : IDataStore<T> where T : BaseEntity
    {
        private readonly MailSenderDB _db;
        private readonly DbSet<T> _Set;
        protected StoreEF(MailSenderDB db) 
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public IEnumerable<T> GetAll() => _Set.AsEnumerable();

        //  public T GetById(int id) => _Set.FirstOrDefault(entity => entity.Id == id);
        public T GetById(int Id) => _Set.Find(Id);

        public int Create(T item)
        {
            _Set.Add(item);
            return item.Id;
        }

        public abstract void Edit(int Id, T item);

        public T Remove(int Id)
        {
            var db_item = GetById(Id);
            if (db_item != null) _db.Entry(db_item).State = EntityState.Deleted;

            return db_item;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
