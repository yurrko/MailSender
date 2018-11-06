using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSendLibrary;
using SupportClasses;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Denisevich_MailSender.ViewModel
{
    public class WpfMailSenderViewModel : ViewModelBase
    {
        private readonly IDataAccessService _dataAccessService;

        private string _title = "Заголовок окна";

        public string Title
        {
            get => _title;
            set => Set( ref _title, value );
        }
        public ObservableCollection<Recepient> Recipients { get; private set; }
        public ObservableCollection<Sender> Senders { get; private set; }
        public ObservableCollection<CustomSmtpClient> CustomSmtpClients { get; private set; }

        private Recepient _currentRecipient = new Recepient();
        private int _currentSender = 100;
        private CustomSmtpClient _currentCustomSmtpClient = new CustomSmtpClient();

        public Recepient CurrentRecipient
        {
            get => _currentRecipient;
            set => Set( ref _currentRecipient, value );
        }

        public int CurrentSender
        {
            get => _currentSender;
            set => Set( ref _currentSender, value );
        }

        public CustomSmtpClient CurrentCustomSmtpClient
        {
            get => _currentCustomSmtpClient;
            set => Set( ref _currentCustomSmtpClient, value );
        }

        public ICommand UpdateDataCommand { get; }
        public ICommand CreateNewRecipient { get; }
        public ICommand UpdateRecipient { get; }
        public ICommand CreateNewSender { get; }

        public WpfMailSenderViewModel( IDataAccessService dataAccessService )
        {
            _dataAccessService = dataAccessService;
            //Recipients = _dataAccessService.GetRecepients();

            Senders = _dataAccessService.GetSenders();
            CustomSmtpClients = _dataAccessService.GetCustomSmtpClients();

            UpdateDataCommand = new RelayCommand( OnUpdateCommandExecuted, UpdateCommandCanExecute );

            CreateNewRecipient = new RelayCommand( OnCreateNewRecipientExecuted );
            UpdateRecipient = new RelayCommand<Recepient>( OnUpdateRecipientExecuted, UpdateRecipientCanExecute );

            CreateNewSender = new RelayCommand( OnCreateNewSenderExecuted );
        }

        private void OnCreateNewSenderExecuted()
        {
            MessageBox.Show( CurrentSender.ToString() );
            RaisePropertyChanged( nameof( CurrentSender ) );
        }

        private void OnCreateNewRecipientExecuted()
        {
            CurrentRecipient = new Recepient();
        }

        private void OnUpdateCommandExecuted()
        {
            Recipients = _dataAccessService.GetRecepients();
            RaisePropertyChanged( nameof( Recipients ) );
        }

        private bool UpdateCommandCanExecute() => true;

        private bool UpdateRecipientCanExecute( Recepient recipient ) => recipient != null;//|| _currentRecipient != null;

        private void OnUpdateRecipientExecuted( Recepient recipient )
        {
            if ( _dataAccessService.CreateRecipient( recipient ) > 0 )
                Recipients.Add( recipient );
        }
    }
}
