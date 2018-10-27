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
    /// Логика взаимодействия для SendCompleteDialog.xaml
    /// </summary>
    public partial class SendCompleteDialog : Window
    {
        public SendCompleteDialog(string message)
        {
            InitializeComponent();
            LabelMessageSendResult.Content = message;
        }

        private void OkButton_OnClick( object sender, RoutedEventArgs e )
        {
            Close();
        }
    }
}
