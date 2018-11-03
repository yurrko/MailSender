using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSendLibrary;

namespace SupportClasses
{
    public interface IDataAccessService
    {
        ObservableCollection<Recepient> GetRecepients();
        int CreateRecipient( Recepient recipient );
    }
}
