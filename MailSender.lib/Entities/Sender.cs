﻿using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Sender : PersonEntity
    {
       public override string ToString() => $"{Name}:{Adress}";
    }
}
