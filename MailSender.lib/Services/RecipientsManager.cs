using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Services;
using MailSender.lib.Entities;

namespace MailSender.lib.Services
{
    public class RecipientsManager
    {
        private RecipientStoreInMemory _Store;
        public RecipientsManager(RecipientStoreInMemory Store) { _Store = Store; }
    
        public IEnumerable<Recipient>GetAll()
        {
            return _Store.Get();
        }
        public void Add(Recipient NewRecipient)
        { 
            
        }

    }
}
