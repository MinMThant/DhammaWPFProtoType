using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using WpfApplicationWithMahApps.Model;
using WpfApplicationWithMahApps.Repository;
using WpfApplicationWithMahApps.Views;

namespace WpfApplicationWithMahApps.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        private static PersonListViewModel _personListViewModel;
        private static PersonDetailViewModel _personDetailViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                if (_currentViewModel == value)
                    return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //Test Commit
            InitializeData();
            InitializeMessenger();
        }

        private void InitializeMessenger()
        {
            this.MessengerInstance.Register<MessengerInstanceToken>(this, (s) => NavigateBetweenViews(s));
        }

        private void NavigateBetweenViews(MessengerInstanceToken token)
        {
            switch (token.ViewModel)
            {
                case "PersonDetailView":
                    var person = (Person)token.Parameters;
                    Messenger.Default.Send(person);
                    CurrentViewModel = _personDetailViewModel;
                    break;
                case "PersonListView":
                    CurrentViewModel = _personListViewModel;
                    break;
                default: //TODO: Not sure.
                    CurrentViewModel = _personListViewModel;
                    break;
            }

            

        }

        private void InitializeData()
        {
            _personListViewModel = SimpleIoc.Default.GetInstance<PersonListViewModel>();
            _personDetailViewModel = SimpleIoc.Default.GetInstance<PersonDetailViewModel>();
            CurrentViewModel = MainViewModel._personListViewModel;
        }
    }
}