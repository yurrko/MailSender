using MailSendLibrary;
using SupportClasses;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Documents;

namespace Denisevich_MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

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
            //try
            //{
            //    var selectedSender = cbSenderSelect.SelectedItem as Sender;

            //    if ( selectedSender is null )
            //        throw new NullReferenceException( "Выбран некорректный объект" );

            //    var login = selectedSender.Name;
            //    var password = selectedSender.Password;

            //    var customSmtpClient = cbMailServerSelect.SelectedItem as CustomSmtpClient;
            //    if ( customSmtpClient is null )
            //        throw new NullReferenceException( "Выбран некорректный объект" );

            //    var body = new TextRange( rtbMailBody.Document.ContentStart, rtbMailBody.Document.ContentEnd );

            //    if ( string.IsNullOrWhiteSpace( body.Text ) )
            //    {
            //        MainTabControl.SelectedIndex = 2;
            //        throw new NullReferenceException( "Текст письма пуст" );
            //    }

            //    var emailSender = new EmailSendService( login, password, customSmtpClient, "", "" );
            //    emailSender.SendMailMessages( (IQueryable<Recepient>)DataGridRecepients.ItemsSource );
            //}
            //catch ( Exception ex )
            //{
            //    var errorWindow = new ErrorWindow( ex.Message )
            //    {
            //        Owner = this,
            //    };
            //    errorWindow.ShowDialog();
            //}
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

            //EmailSendService emailSender = new EmailSendService(
            //    (cbSenderSelect.SelectedValue as Sender)?.Email,
            //    (cbSenderSelect.SelectedValue as Sender)?.Password,
            //    (cbMailServerSelect.SelectedValue as CustomSmtpClient),
            //    "",""
            //    );

            //sc.SendEmails( dtSendDateTime, emailSender, (IQueryable<Recepient>)DataGridRecepients.ItemsSource );
        }
    }
}
