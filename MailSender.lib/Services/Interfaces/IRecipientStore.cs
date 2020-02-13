using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Data;
using MailSender.lib.Entities;
using MailSender.lib.Services;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientStore
    {
        IEnumerable<Recipient> GetAll();
        Recipient GetById(int id);
        int Create(Recipient Recipient);

        void Edit(int Id, Recipient recipient);
        Recipient Remove(int Id);
        void SaveChanges();
    }
}
