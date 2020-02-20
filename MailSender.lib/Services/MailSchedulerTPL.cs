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
    public class MailSchedulerTPL
    {
        private readonly ISchedulerTaskStore _TaskStore;
        private volatile CancellationTokenSource _ProcessTaskCancellation;

        public MailSchedulerTPL(ISchedulerTaskStore TaskStore)
        {
            _TaskStore = TaskStore;
        }

        public async Task StartAsync()
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
            var task_time = task.Time;
            var delta = task.Time.Subtract(DateTime.Now);

            await Task.Delay(delta, Cancel).ConfigureAwait(false);

            await ExecuteTask(task, Cancel);
            _TaskStore.Remove(task.Id);
           await  StartAsync();
        }
        private async Task ExecuteTask(SchedulerTask task, CancellationToken Cancel)
        {

        }
    }
}
