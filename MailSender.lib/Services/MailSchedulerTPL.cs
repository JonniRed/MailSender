using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace MailSender.lib.Services
{
    public class MailSchedulerTPL : IMailScheduler
    {
        private readonly ISchedulerTaskStore _TaskStore;
        private readonly IMailSenderService _MailSenderService;
        private volatile CancellationTokenSource _ProcessTaskCancellation;

        public MailSchedulerTPL(ISchedulerTaskStore TaskStore, IMailSenderService MailSenderService)
        {
            _TaskStore = TaskStore;
            _MailSenderService = MailSenderService;
        }

        public void  Start()
        {
            var cancellation = new CancellationTokenSource();
            Interlocked.Exchange(ref _ProcessTaskCancellation, cancellation)?.Cancel();

            var first_task = _TaskStore.GetAll().
                Where(task => task.Time > DateTime.Now).
                OrderBy(task => task.Time).FirstOrDefault();
            if (first_task is null) return;

            WaitTaskAsync(first_task, cancellation.Token);
        }
        private async void WaitTaskAsync(SchedulerTask task, CancellationToken Cancel)
        {
            Cancel.ThrowIfCancellationRequested();

            var task_time = task.Time;
            var delta = task.Time.Subtract(DateTime.Now);

            if(delta.TotalSeconds >0)
                 await Task.Delay(delta, Cancel).ConfigureAwait(false);
            Cancel.ThrowIfCancellationRequested();


            await ExecuteTask(task, Cancel);
            _TaskStore.Remove(task.Id);
           await Task.Run(Start, Cancel);
        }
        private async Task ExecuteTask(SchedulerTask task, CancellationToken Cancel)
        {
            Cancel.ThrowIfCancellationRequested();

            var sender = _MailSenderService.GetSender(task.Server);

            await sender.SendAsync(task.Mail, task.Sender, task.Recipient.Recipients, Cancel);
        }
    }
}
