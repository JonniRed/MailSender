using System;
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

namespace MailSender.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var services = SimpleIoc.Default;
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
        }
        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
