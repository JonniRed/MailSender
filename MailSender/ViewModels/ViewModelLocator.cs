﻿using System;
using System.Collections.Generic;
using System.Text;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;


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
            services.Register<IRecipientStore, RecipientStoreInMemory>();
        }
        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
