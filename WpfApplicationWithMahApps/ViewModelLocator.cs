/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfApplicationWithMahApps"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WpfApplicationWithMahApps.Repository;
using WpfApplicationWithMahApps.ViewModel;

namespace WpfApplicationWithMahApps
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //ViewModel registration
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PersonListViewModel>();
            SimpleIoc.Default.Register<PersonDetailViewModel>();
            
            //Services registration
            SimpleIoc.Default.Register<IPersonRepository, PersonRepository>();
     
            //View registration
            //TODO: May be we can register it with code instead of App Resources Declaration?
        }

        #region ViewModel exposure
        
        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public PersonListViewModel PersonListViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PersonListViewModel>();
            }
        }


        public PersonDetailViewModel PersonDetailViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PersonDetailViewModel>();
            }
        }

        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }


}