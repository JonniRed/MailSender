using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Entities.Base
{
    public abstract class SecureEntity : NamedEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
