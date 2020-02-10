using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight;
using MailSender.lib.Services;
using MailSender.lib.Entities;
using System.Windows.Input;
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

        #region Команды
        public ICommand LoadRecipientsDataCommand { get; }
        public ICommand SaveRecipientChangesCommand { get; }

        public MainWindowViewModel(RecipientsManager RecipientManager)
        {
            _RecipientManager = RecipientManager;

            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientsDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangesCommand = new RelayCommand<Recipient>(OnSaveRecipientChangesCommandExecuted, CanSaveRecipientChangesCommandExecute);

        }
        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void OnLoadRecipientsDataCommandExecuted()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientManager.GetAll());
        }

        private bool CanSaveRecipientChangesCommandExecute(Recipient recipient)
        {
            System.Diagnostics.Debug.WriteLine("Проверка состояния команды"+ recipient?.Name);
            return recipient != null;
        }
        private void OnSaveRecipientChangesCommandExecuted(Recipient recipient)
        {
            _RecipientManager.Edit(recipient);
            _RecipientManager.SaveChanges();
        }
        #endregion
    }
}
