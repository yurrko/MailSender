using SupportClasses;
using System;
using System.Linq;
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
            //mailer = new EmailSendServiceClass();
        }

        //private void SendButton_OnClick( object sender, RoutedEventArgs e )
        //{

        //    var subject = string.IsNullOrWhiteSpace( TextBoxMailSubject.Text ) ? MyConst.MailSubject : TextBoxMailSubject.Text.ToString();
        //    var mailBody = string.IsNullOrWhiteSpace( TextBoxMailBody.Text ) ? MyConst.MailBody : TextBoxMailBody.Text.ToString();

        //    try
        //    {

        //        mailer.SendMailMessage( MyConst.MailSender, MyConst.AddressList,
        //                                MyConst.Yandex.SmtpServer, MyConst.Yandex.Port,
        //                                subject, mailBody, UserNameTextBox.Text,
        //                                PasswordPasswordBox.SecurePassword );
        //    }
        //    catch ( Exception res )
        //    {

        //        var errorWindow = new ErrorWindow( res.Message )
        //        {
        //            Owner = this,
        //        };
        //        errorWindow.ShowDialog();
        //    }
        //}

        private void OnExitClick( object Sender, RoutedEventArgs E )
        {
            Close();
        }

        private void GoToPlannerButton_OnClick( object Sender, RoutedEventArgs E )
        {
            MainTabControl.SelectedItem = TimePlannerTab;
        }

        private void Button_Click_Send_Now( object sender, RoutedEventArgs e )
        {
            string strLogin = cbSenderSelect.Text;
            string strPassword = cbSenderSelect.SelectedValue.ToString();
            if ( string.IsNullOrEmpty( strLogin ) )
            {
                MessageBox.Show( "Выберите отправителя" );
                return;
            }
            if ( string.IsNullOrEmpty( strPassword ) )
            {
                MessageBox.Show( "Укажите пароль отправителя" );
                return;
            }
            var emailSender = new EmailSendServiceClass( strLogin, strPassword );
            emailSender.SendMailMessages( (IQueryable<Recepient>)DataGridRecepients.ItemsSource );
        }


        private void Button_Click_Send_Later( object sender, RoutedEventArgs e )
        {
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime( tbTimePicker.Text );
            if ( tsSendTime == new TimeSpan() )
            {
                MessageBox.Show( "Некорректный формат даты" );
                return;
            }
            DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add( tsSendTime );
            if ( dtSendDateTime < DateTime.Now )
            {
                MessageBox.Show( "Дата и время отправки писем не могут быть раньше, чем настоящее время" );
            return;
            }
            EmailSendServiceClass emailSender = new EmailSendServiceClass( cbSenderSelect.Text,
            cbSenderSelect.SelectedValue.ToString() );
            sc.SendEmails( dtSendDateTime, emailSender, (IQueryable<Recepient>)DataGridRecepients.ItemsSource );
        }
    }
}
