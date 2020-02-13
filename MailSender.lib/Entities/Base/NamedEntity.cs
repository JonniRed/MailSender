using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Entities.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        public virtual string Name { get; set; }
    }

}
