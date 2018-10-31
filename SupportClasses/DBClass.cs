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
        private readonly RecepientsDataContext _recepients = new RecepientsDataContext();

        public IQueryable<Recepient> Recepients => _recepients.Recepient;
    }
}
