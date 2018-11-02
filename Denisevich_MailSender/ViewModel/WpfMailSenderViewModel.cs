using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MailSendLibrary;
using SupportClasses;
using System.Collections.ObjectModel;
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

        private Recepient _currentRecipient = new Recepient();

        public Recepient CurrentRecipient
        {
            get => _currentRecipient;
            set => Set( ref _currentRecipient, value );
        }
        public ICommand UpdateDataCommand { get; }
        public ICommand CreateNewRecipient { get; }
        public ICommand UpdateRecipient { get; }

        public WpfMailSenderViewModel( IDataAccessService dataAccessService )
        {
            _dataAccessService = dataAccessService;
            //Recipients = _dataAccessService.GetRecepients();

            UpdateDataCommand = new RelayCommand( OnUpdateCommandExecuted, UpdateCommandCanExecute );

            CreateNewRecipient = new RelayCommand( OnCreateNewRecipientExecuted );
            UpdateRecipient = new RelayCommand<Recepient>( OnUpdateRecipientExecuted, UpdateRecipientCanExecute );
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
