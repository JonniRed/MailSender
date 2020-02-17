using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Services.InMemory;


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
            services.Register<IRecipientStore, RecipientStoreInMemory>();
        }
        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
