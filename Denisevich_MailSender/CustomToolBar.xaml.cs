using MailSendLibrary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Denisevich_MailSender
{
    /// <summary>
    /// Логика взаимодействия для CustomToolBar.xaml
    /// </summary>
    public partial class CustomToolBar : UserControl
    {
        public event EventHandler OnAddButtonClick;
        public event EventHandler OnEditButtonClick;
        public event EventHandler OnDelButtonClick;

        public CustomToolBar()
        {
            InitializeComponent();
        }

        private string displayName;
        private object cbData;

        public string DisplayName
        {
            get { return displayName; }
            set
            {
                displayName = value;
                tbDisName.Text = value;
            }
        }

        public object CbData
        {
            get
            {
                return cbData;
            }
            set
            {
                IEnumerable<Sender> sender = value as IEnumerable<Sender>;
                if ( sender is null )
                {
                    IEnumerable<CustomSmtpClient> server = value as IEnumerable<CustomSmtpClient>;
                    if (server is null )
                    {
                        throw new Exception( "Неверный тип" );
                    }
                    cbSenderSelect.ItemsSource = server;
                    

                }
                else
                {
                    cbSenderSelect.ItemsSource = sender;
                }
            }
        }

        public object CurrentSelection { get; set; }
        //public static DependencyProperty CustomDisplayNameProperty = DependencyProperty.Register( "CustomDisplayName", typeof( string ), typeof( CustomToolBar ) );
        ////public string DataSource { get; set; } = "TestString";

        private void btnAddClick( object sender, RoutedEventArgs e )
        {
            OnAddButtonClick?.Invoke( this, EventArgs.Empty );
        }

        private void btnEditClick( object sender, RoutedEventArgs e )
        {
            OnEditButtonClick?.Invoke( this, EventArgs.Empty );
        }

        private void btnDelClick( object sender, RoutedEventArgs e )
        {
            OnDelButtonClick?.Invoke( this, EventArgs.Empty );
        }
    }
}
