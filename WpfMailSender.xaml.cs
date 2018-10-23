using Denisevich_MailSender.SupportClasses;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace Denisevich_MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        private EmailSendServiceClass mailer;
        public WpfMailSender()
        {
            InitializeComponent();
            mailer = new EmailSendServiceClass();
        }

        private void SendButton_OnClick( object sender, RoutedEventArgs e )
        {

            var subject = string.IsNullOrWhiteSpace( TextBoxMailSubject.Text ) ? MyConst.MailSubject : TextBoxMailSubject.Text.ToString();
            var mailBody = string.IsNullOrWhiteSpace( TextBoxMailBody.Text ) ? MyConst.MailBody : TextBoxMailBody.Text.ToString();

            var res = mailer.SendMailMessage( MyConst.MailSender, MyConst.AddressList,
                MyConst.Yandex.SmtpServer, MyConst.Yandex.Port,
                subject, mailBody,
                UserNameTextBox.Text, PasswordPasswordBox.SecurePassword );

            if ( res.Item1 )
            {
                var dialog = new SendCompleteDialog( res.Item2 )
                {
                    Owner = this,
                };
                dialog.ShowDialog();
            }
            else
            {
                var errorWindow = new ErrorWindow( res.Item2 )
                {
                    Owner = this,
                };
                errorWindow.ShowDialog();
            }
        }
    }
}
