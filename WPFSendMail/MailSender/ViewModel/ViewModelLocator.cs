/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MailSender"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Lib.Data.Linq2SQL;
using MailSender.Lib.Services.Linq2SQL;
using MailSender.Lib.Services.Interfaces;

namespace MailSender.ViewModel
{

    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            var services = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => services);

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

            services.Register<MainViewModel>();
            services.Register<SenderEditorViewModel>();
            services.Register<IDataProvider<Sender>, Linq2SSQLSenderDataProvider>();
            services.Register<IDataProvider<Recipient>, Linq2SSQLReipientDataProvider>();
            if (!services.IsRegistered<MailSenderDBDataContext>())
                services.Register(() => new MailSenderDBDataContext());            
        }

        public MainViewModel MainViewModel=>ServiceLocator.Current.GetInstance<MainViewModel>();
        public SenderEditorViewModel SenderEditorVM => ServiceLocator.Current.GetInstance<SenderEditorViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}