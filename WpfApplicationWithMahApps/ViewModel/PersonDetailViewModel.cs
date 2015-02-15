using System;
using System.ComponentModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfApplicationWithMahApps.Model;
using WpfApplicationWithMahApps.Repository;
using WpfApplicationWithMahApps.Views;

namespace WpfApplicationWithMahApps.ViewModel
{
    public class PersonDetailViewModel : ViewModelBase
    {
        public RelayCommand<object> DownloadFilesCommand { get; set; }

        private readonly IPersonRepository _personRepository;
        private Person _selectedPerson;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
               RaisePropertyChanged("SelectedPerson");
                
            }
        }

        private Person _temp;

        public PersonDetailViewModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            Messenger.Default.Register<Person>(this, OnPersonSelected);
        
            InitalizeCommands();
        }

        private void OnPersonSelected(Person obj)
        {
            SelectedPerson = obj;
            _temp = obj;
        }


        private void InitalizeCommands()
        {
            DownloadFilesCommand = new RelayCommand<object>((s) =>
                {
                    //SelectedPerson = new Person(){ Name = DateTime.Now.ToString()};
                    
                });
        }
    }
}
