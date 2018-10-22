using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Denisevich_MailSender
{
    public class EmailSendServiceClass
    {
        public EmailSendServiceClass()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailSender">Почта отправителя</param>
        /// <param name="addressList">Список рассылки</param>
        /// <param name="mailSubject">Тема письма</param>
        /// <param name="mailBody">Сожержание письма</param>
        /// <param name="smtpServer">Smtp сервер</param>
        /// <param name="smtpPort">Порт Smtp сервера</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public (bool, string) SendMailMessage( string mailSender, IEnumerable<string> addressList,
            string smtpServer, int smtpPort,
            string mailSubject, string mailBody,
            string login, System.Security.SecureString password )
        {
            try
            {
                foreach ( var address in addressList )
                {
                    using ( var email = new MailMessage( mailSender, address ) )
                    {
                        email.Subject = mailSubject;
                        email.Body = mailBody;

                        using ( var client = new SmtpClient( smtpServer, smtpPort ) )
                        {
                            client.Credentials = new NetworkCredential( login, password );
                            client.EnableSsl = true;

                            client.Send( email );
                        }
                    }
                }
            }
            catch ( Exception error )
            {
                //MessageBox.Show( error.Message, MyConst.ErrorMessage, MessageBoxButton.OK,
                //    MessageBoxImage.Error );
                return (false, error.Message);
            }
            return (true, MyConst.Success);
        }
    }
}
