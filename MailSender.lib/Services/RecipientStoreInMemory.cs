using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;
using MailSender.lib.Data;

namespace MailSender.lib.Services
{
    public class RecipientStoreInMemory
    {
        public IEnumerable<Recipient> Get() => TestData.Recipient;
    }
}
