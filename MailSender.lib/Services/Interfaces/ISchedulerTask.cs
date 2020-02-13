using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities;

namespace MailSender.lib.Services.Interfaces
{
    public interface ISchedulerTask : IDataStore<SchedulerTask> { }
}
