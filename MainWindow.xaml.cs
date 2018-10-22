using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace Denisevich_MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmailSendServiceClass mailer;
        public MainWindow()
        {
            InitializeComponent();
            mailer = new EmailSendServiceClass();
        }

        private void SendButton_OnClick( object sender, RoutedEventArgs e )
        {

            var res = mailer.SendMailMessage( MyConst.MailSender, MyConst.AddressList,
                MyConst.Yandex.SmtpServer, MyConst.Yandex.Port,
                UserName_TextBox.Text, Password_PasswordBox.SecurePassword );

            if ( res.Item1 )
            {
                var dialog = new SendCompleteDialog
                {
                    Owner = this,
                };
                dialog.ShowDialog();
            } else
            {
                var errorWindow = new 
            }

        }
    }
}
