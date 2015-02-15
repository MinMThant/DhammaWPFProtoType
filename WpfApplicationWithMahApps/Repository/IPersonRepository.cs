using System.Collections.ObjectModel;
using WpfApplicationWithMahApps.Model;

namespace WpfApplicationWithMahApps.Repository
{
    public interface IPersonRepository
    {
        ObservableCollection<Person> GetPersons();
        Person GetPersonByName(string name);
    }
}