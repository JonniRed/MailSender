﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Entities
{
    public class Sender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public override string ToString() => $"{Name}:{Adress}";
    }
}
