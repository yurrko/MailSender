using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisevich_MailSender.SupportClasses
{
    public class CustomSmtpClient
    {
        public string SmtpServer { get; private set; }
        public int Port { get; private set; }

        public CustomSmtpClient(string smtpServer, int port)
        {
            SmtpServer = smtpServer;
            Port = port;
        }
    }
}
