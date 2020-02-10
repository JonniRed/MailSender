using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class RecipientsManager : IRecipientManager
    {
        private IRecipientStore _Store;
        public RecipientsManager(RecipientStoreInMemory Store) { _Store = Store; }
    
        public IEnumerable<Recipient>GetAll()
        {
            return _Store.Get();
        }
        public void Add(Recipient NewRecipient)
        { 
            
        }
        public void Edit(Recipient Recipient)
        {
            _Store.Edit(Recipient.Id, Recipient);
        }
        public void SaveChanges()
        {
            _Store.SaveChanges();
        }

    }
}
