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
        void Edit(int Id, Recipient recipient);
        void SaveChanges();
    }
}
