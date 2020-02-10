using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientManager
    {
        IEnumerable<Recipient> GetAll();
        void Add(Recipient NewRecipient);

        void Edit(Recipient Recipient);
        void SaveChanges();
    }

}

    
