using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using System.Collections.ObjectModel;

namespace MailSender.ViewModels 
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly RecipientsManager _RecipientManager;
        private string _Title = "Рассыльщик почты";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        private ObservableCollection<Recipient> _Recipients;
        public ObservableCollection<Recipient> Recipients 
        {   
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }
        private Recipient _SelectedRecipient;
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }
        public MainWindowViewModel(RecipientsManager RecipientManager)
        {
            _RecipientManager = RecipientManager;
            _Recipients = new ObservableCollection<Recipient>(_RecipientManager.GetAll());        }
    }
}
