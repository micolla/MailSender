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
using MailSender.Lib.DataProviders.Linq2SQL;
using MailSender.Lib.DataProviders.Interfaces;
using MailServer.ViewModel;
using MailSender.Lib.DataProviders.InMemory;

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
            services.Register<ISenderDataProvider, Linq2SQLSenderDataProvider>();
            services.Register<IRecipientDataProvider, Linq2SQLRecipientDataProvider>();
            services.Register<ISMTPServerDataProvider, Linq2SQLSMTPServerDataProvider>();
            services.Register<IRecipientsListDataProvider, InRecipientsListDataProvider>();
            if (!services.IsRegistered<MailSenderDBDataContext>())
                services.Register(() => new MailSenderDBDataContext());            
        }

        public MainViewModel MainViewModel=>ServiceLocator.Current.GetInstance<MainViewModel>();
        public SenderEditorViewModel SenderEditorVM => ServiceLocator.Current.GetInstance<SenderEditorViewModel>();
        public ServerEditorVM ServerEditorVM => ServiceLocator.Current.GetInstance<ServerEditorVM>();
        

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}