using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfApplicationWithMahApps.Model;
using WpfApplicationWithMahApps.Repository;

namespace WpfApplicationWithMahApps.ViewModel
{
    public class PersonListViewModel : ViewModelBase
    {
        private readonly IPersonRepository _personRepository;
        public RelayCommand<object> DisplayDetails { get; set; }

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                RaisePropertyChanged("Persons");
            }
        }

        public PersonListViewModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            Initialize(null);
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            DisplayDetails = new RelayCommand<object>((s) =>
            {
                if (s != null)
                {
                    var token = new MessengerInstanceToken()
                        {
                            ViewModel = "PersonDetailsPage",
                            Parameters = s
                        };  

                    this.MessengerInstance.Send<MessengerInstanceToken>(token);
                }
            });
        }

        public void Initialize(object parameter)
        {
            Persons = _personRepository.GetPersons();
        }
    }
}
