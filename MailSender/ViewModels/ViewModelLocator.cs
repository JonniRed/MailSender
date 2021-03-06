﻿using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Data.EF;


using MailSender.Infrastructure.Services.Interfaces;
using MailSender.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MailSender.lib.Services.EF;
using System.Threading.Tasks;
using MailSender.lib;

namespace MailSender.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var services = SimpleIoc.Default;
            services.Register(() => App.Configuration);


            services.Register<MainWindowViewModel>();

            services.Register<IRecipientManager, RecipientsManager>();
            services.Register<IServerStore, ServerStoreInMemory>();
            services.Register<ISenderStore, SenderStoreInMemory>();
            services.Register<IMailStore, MailStoreInMemory>();
            // services.Register<IRecipientStore, RecipientStoreInMemory>();
            services.Register<IRecipientStore, RecipientStoreEF>();

            services.Register<ISenderEditor, WindowSenderEditor>();

            services.Register<MailSenderDB>();
            services.Register(() => new DbContextOptionsBuilder<MailSenderDB>()
            .UseSqlServer(App.Configuration.GetConnectionString("DefaultConnection")).Options);

            services.Register<MailSenderDBInitializer>();
#if DEBUG
            services.Register<IMailSenderService, DebugMailSenderService>();
#else
            services.Register<IMailSenderService, MailSenderService>();
#endif

            var db_initializer = (MailSenderDBInitializer) services.GetService(typeof(MailSenderDBInitializer));
            var initialize_task = Task.Run(() => db_initializer.InitializeAsync()); //принудительно создаём поток, 
            //чтобы не создавать мёртвой блокировки при методе wait, ибо без другого потока основной tread 
            //замкнет себя
            initialize_task.Wait();
        }
        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
