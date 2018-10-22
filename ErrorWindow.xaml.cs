using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            ErrorMessageTextBlock.Text = message;
            Title = MyConst.ErrorMessage;
        }

        private void Button_Click_OK_Event( object sender, RoutedEventArgs e )
        {
            Close();
        }
    }
}