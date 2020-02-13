using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities.Base
{
    public abstract class PersonEntity : NamedEntity
    {
        public string Adress { get; set; }
    }
}
