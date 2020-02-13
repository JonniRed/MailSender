using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Recipient : PersonEntity
    {
        public override string Name
        {
            get => base.Name;
            set
            {
                if (value == "Иванов123") throw new ArgumentException("Иванов123 нам не подходит");
                base.Name = value;
            }
        }
    }
}

