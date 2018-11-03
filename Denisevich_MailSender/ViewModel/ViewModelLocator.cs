using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using SupportClasses;

namespace Denisevich_MailSender.ViewModel
{
    public class ViewModelLocator
    {

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public WpfMailSenderViewModel WpfMailSenderViewModel =>
            ServiceLocator.Current.GetInstance<WpfMailSenderViewModel>();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider( () => SimpleIoc.Default );

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<IDataAccessService, DataAccessServiceFromDb>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WpfMailSenderViewModel>();
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}