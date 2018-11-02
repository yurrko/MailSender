using System.Collections.ObjectModel;
using System.Linq;
using MailSendLibrary;

namespace SupportClasses
{
    public class DataAccessServiceFromDb : IDataAccessService
    {
        private RecepientsDataContext _dataContext;

        public DataAccessServiceFromDb()
        {
            _dataContext = new RecepientsDataContext();
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
    }
}