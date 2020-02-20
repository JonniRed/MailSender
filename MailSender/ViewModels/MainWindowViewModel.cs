using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;
using MailSender.lib.Entities;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MailSender.Views;
using MailSender.Infrastructure.Services.Interfaces;

namespace MailSender.ViewModels 
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IRecipientManager _RecipientManager;
        private readonly IServerStore _ServerStore;
        private readonly ISenderStore _SenderStore;
        private readonly IMailStore _MailStore;
        private readonly ISenderEditor _SenderEditor;

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

        private Server _SelectedServer;
        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }

        private Sender _SelectedSender;
        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        private Mail _SelectedMail;
        public Mail SelectedMail
        {
            get => _SelectedMail;
            set => Set(ref _SelectedMail, value);
        }

        private ObservableCollection<Sender> _Sender;
        public ObservableCollection<Sender> Sender
        {
            get => _Sender;
            private set => Set(ref _Sender, value);
        }

        private ObservableCollection<Server> _Server;
        public ObservableCollection<Server> Server
        {
            get => _Server;
            private set => Set(ref _Server, value);
        }

        private ObservableCollection<Mail> _Mail;
        public ObservableCollection<Mail> Mail
        {
            get => _Mail;
            private set => Set(ref _Mail, value);
        }


        #region Команды
        public ICommand LoadRecipientsDataCommand { get; }
        public ICommand SaveRecipientChangesCommand { get; }
        public ICommand SenderEditCommand { get; }

        #endregion


        public MainWindowViewModel(IRecipientManager RecipientManager, ISenderStore SenderStore,
            IServerStore ServerStore, IMailStore MailStore, ISenderEditor SenderEditor)
        {
            _RecipientManager = RecipientManager;
            _MailStore = MailStore;
            _ServerStore = ServerStore;
            _SenderStore = SenderStore;
            _SenderEditor = SenderEditor;

            LoadRecipientsDataCommand = new RelayCommand(OnLoadRecipientsDataCommandExecuted, CanLoadRecipientsDataCommandExecute);
            SaveRecipientChangesCommand = new RelayCommand<Recipient>(OnSaveRecipientChangesCommandExecuted, CanSaveRecipientChangesCommandExecute);
            SenderEditCommand = new RelayCommand<Sender>(OnSenderEditCommandExecuted, CanSenderEditCommandExecute);
        }
        private bool CanSenderEditCommandExecute(Sender sender) => sender != null;
        private void OnSenderEditCommandExecuted(Sender sender) => _SenderEditor.Edit(sender);
        private bool CanLoadRecipientsDataCommandExecute() => true;
        private void OnLoadRecipientsDataCommandExecuted()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientManager.GetAll());
            Sender = new ObservableCollection<Sender>(_SenderStore.GetAll());
            Server = new ObservableCollection<Server>(_ServerStore.GetAll());
            Mail = new ObservableCollection<Mail>(_MailStore.GetAll());
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
       
    }
}
