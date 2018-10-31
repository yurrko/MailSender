using SupportClasses;
using System.Windows;

namespace Denisevich_MailSender
{
    /// <summary>
    /// Логика взаимодействия для ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        private string Message { get; set; }

        public ErrorWindow(string message)
        {
            InitializeComponent();
            ErrorMessageTextBlock.Content = message;
            Title = MyConst.ErrorMessage;
        }

        private void Button_Click_OK_Event( object sender, RoutedEventArgs e )
        {
            Close();
        }
    }
}