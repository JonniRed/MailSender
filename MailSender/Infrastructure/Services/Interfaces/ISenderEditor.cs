using MailSender.lib.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Infrastructure.Services.Interfaces
{
    public interface ISenderEditor
    {
        void Edit(Sender sender);
    }
}
