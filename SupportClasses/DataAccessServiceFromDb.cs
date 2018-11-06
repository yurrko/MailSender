using System.Collections.ObjectModel;
using System.Linq;
using MailSendLibrary;

namespace SupportClasses
{
    public class DataAccessServiceFromDb : IDataAccessService
    {
        private RecepientsDataContext _dataContext;
        private SendersDataContext _sendersDataContext;
        private CustomSmtpClientsDataContext _customSmtpClientsDataContext;

        public DataAccessServiceFromDb()
        {
            _dataContext = new RecepientsDataContext();
            _sendersDataContext = new SendersDataContext();
            _customSmtpClientsDataContext = new CustomSmtpClientsDataContext();
        }

        public ObservableCollection<Recepient> GetRecepients()
        {
            return new ObservableCollection<Recepient>( _dataContext.Recepient.ToArray() );
        }

        public int CreateRecipient( Recepient recipient )
        {
            _dataContext.Recepient.InsertOnSubmit( recipient );
            _dataContext.SubmitChanges();
            return recipient.Id;
        }

        public ObservableCollection<Sender> GetSenders()
        {
            return new ObservableCollection<Sender>( _sendersDataContext.Sender.ToArray() );
        }

        public int CreateSender( Sender sender )
        {
            _dataContext.Recepient.InsertOnSubmit( recipient );
            _dataContext.SubmitChanges();
            return recipient.Id;
        }

        public ObservableCollection<CustomSmtpClient> GetCustomSmtpClients()
        {
            return new ObservableCollection<CustomSmtpClient>( _customSmtpClientsDataContext.CustomSmtpClient.ToArray() );
        }

        public int CreateCustomSmtpClients( CustomSmtpClient customSmtpClient )
        {
            _customSmtpClientsDataContext.CustomSmtpClient.InsertOnSubmit(customSmtpClient);
            _customSmtpClientsDataContext.SubmitChanges();
            return customSmtpClient.Id;
        }
    }
}