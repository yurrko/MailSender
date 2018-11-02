using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace MailSendLibrary
{
    public class EmailSendService
    {
        private string _login;
        private string _password;
        private string _body;
        private string _subject;
        private string _smtpServer;
        private int _smtpPort;

        public EmailSendService( string login, string password, CustomSmtpClient server, string body, string subject )
        {
            (_login, _password, _smtpServer, _smtpPort, Body, Subject) =
                (login, password, server.SmtpServer, server.Port, body, subject);
        }

        public string Body { get => _body; set => _body = value; }
        public string Subject { get => _subject; set => _subject = value; }

        public void SendMailMessage( string address )
        {
            try
            {
                using ( var email = new MailMessage( _login, address )
                {
                    Subject = Subject,
                    Body = Body,
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
                throw new InvalidOperationException( String.Concat( "Произошла ошибка", " ", error.Message ) );
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
