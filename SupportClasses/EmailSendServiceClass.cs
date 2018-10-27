using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace SupportClasses
{
    public class EmailSendServiceClass
    {
        private string _login;
        private string _password;
        private string _body;
        private string _subject;
        private string _smtpServer;
        private int _smtpPort;

        public EmailSendServiceClass( string login, string password, CustomSmtpClient server )
        {
            (_login, _password, _smtpServer, _smtpPort) = (login, password, server.SmtpServer, server.Port);
        }

        public void SendMailMessage( string address )
        {
            try
            {
                using ( var email = new MailMessage( _login, address )
                {
                    Subject = _subject,
                    Body = _body,
                    IsBodyHtml = false,
                } )
                {
                    using ( var client = new SmtpClient( _smtpServer, _smtpPort )
                    {
                        Credentials = new NetworkCredential( _login, _password ),
                        EnableSsl = true,
                    } )
                    {

                        client.Send( email );
                    }
                }
            }
            catch ( Exception error )
            {
                throw new InvalidOperationException( String.Concat( MyConst.ErrorMessage, " ", error.Message ) );
            }
        }

        public void SendMailMessages( IQueryable<Recepient> addressList )
        {
            foreach ( var address in addressList )
            {
                SendMailMessage( address.Email );
            }
        }
    }
}
