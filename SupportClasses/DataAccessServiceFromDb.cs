using System.Collections.ObjectModel;
using System.Linq;
using MailSendLibrary;

namespace SupportClasses
{
    public class DataAccessServiceFromDb : IDataAccessService
    {
        private MyMailDataContext _dataContext;

        public DataAccessServiceFromDb()
        {
            _dataContext = new MyMailDataContext();
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
            return new ObservableCollection<Sender>( _dataContext.Sender.ToArray() );
        }

        public int CreateSender( Sender sender )
        {
            _dataContext.Sender.InsertOnSubmit( sender );
            _dataContext.SubmitChanges();
            return sender.Id;
        }

        public ObservableCollection<CustomSmtpClient> GetCustomSmtpClients()
        {
            return new ObservableCollection<CustomSmtpClient>( _dataContext.CustomSmtpClient.ToArray() );
        }

        public int CreateCustomSmtpClients( CustomSmtpClient customSmtpClient )
        {
            _dataContext.CustomSmtpClient.InsertOnSubmit(customSmtpClient);
            _dataContext.SubmitChanges();
            return customSmtpClient.Id;
        }
    }
}