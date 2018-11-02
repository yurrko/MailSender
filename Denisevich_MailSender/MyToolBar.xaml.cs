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
    /// Логика взаимодействия для MyToolBar.xaml
    /// </summary>
    public partial class MyToolBar : UserControl
    {
        public MyToolBar()
        {
            InitializeComponent();
        }

        #region DisplayName : string - Имя панели

        /// <summary>Имя панели</summary>
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register(
                nameof( DisplayName ),
                typeof( string ),
                typeof( CustomToolBar ),
                new PropertyMetadata( default( string ) ) );

        /// <summary>Имя панели</summary>
        public string DisplayName
        {
            get => (string)GetValue( DisplayNameProperty );
            set => SetValue( DisplayNameProperty, value );
        }

        #endregion
    }
}
