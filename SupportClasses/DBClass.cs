using MailSendLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportClasses
{
    public class DbClass
    {
        private readonly MyMailDataContext _dataContext = new MyMailDataContext();

        public IQueryable<Recepient> Recepients => _dataContext.Recepient;
        public IQueryable<Sender> Senders => _dataContext.Sender;
        public IQueryable<CustomSmtpClient> CustomSmtpClients => _dataContext.CustomSmtpClient;
    }
}
