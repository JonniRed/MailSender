using MailSender.lib.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Data.EF
{
    public class MailSenderDBInitializer
    {
        private readonly MailSenderDB _db;
        public MailSenderDBInitializer(MailSenderDB db) => _db = db;
        public async Task InitializeAsync()
        {
            _db.Database.EnsureCreated();
            ///если бы освоили миграции, вызывали бы _db.Database.Migrate(); 
            await SeedAsync(_db.Mails);
            await SeedAsync(_db.Servers);
            await SeedAsync(_db.Senders);
            await SeedAsync(_db.Recipients);

            if(!await _db.MailingList.AnyAsync())
            {
                _db.MailingList.Add(new MailingList
                {
                    Name = "Mail list",
                    Recipients = await _db.Recipients.OrderBy(r => r.Id).Take(5).ToArrayAsync()
                });
                await _db.SaveChangesAsync();
            }

        }
        
        private async Task SeedAsync(DbSet<Mail> Mails)
        {
            if (await Mails.AnyAsync()) return;

            for (var i = 0; i < 10; i++) Mails.Add(new Mail { Subject = $"Письмо {i}", Body = $"Текст письма {i}" });
            await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Server> Servers)
        {
            if (await Servers.AnyAsync()) return;

            for (var i = 0; i < 10; i++) Servers.Add(new Server { Name = $"Сервер {i}", Adress = $"smtp.server {i}.ru",
            Login = "Login", Password = "Password"});
            await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Sender> Senders)
        {
            if (await Senders.AnyAsync()) return;

            for (var i = 0; i < 10; i++) Senders.Add(new Sender { Name = $"Отправитель {i}", Adress = $"sender{i}@server.ru" });
            await _db.SaveChangesAsync();
        }

        private async Task SeedAsync(DbSet<Recipient> Recipients)
        {
            if (await Recipients.AnyAsync()) return;

            for (var i = 0; i < 10; i++) Recipients.Add(new Recipient { Name = $"Получатель {i}", Adress = $"recipient{i}@server.ru" });
            await _db.SaveChangesAsync();
        }
    }
}
