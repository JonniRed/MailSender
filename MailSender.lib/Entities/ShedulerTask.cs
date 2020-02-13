using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class SchedulerTask : BaseEntity
    {
        /// <summary>
        /// время выполнения задания
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// отправитель почты в задании
        /// </summary>
        public Sender Sender { get; set; }
        /// <summary>
        /// список получателей писем
        /// </summary>
        public MailingList Recipient { get; set; }
        /// <summary>
        /// сервес, чеерз который надо выполнить отправку почты
        /// </summary>
        public Server Server { get; set; }
        /// <summary>
        /// письмо, которое требуется разослать
        /// </summary>
        public Mail Mail { get; set; }
    }
}
