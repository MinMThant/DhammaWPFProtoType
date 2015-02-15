using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WpfApplicationWithMahApps.Model;

namespace WpfApplicationWithMahApps.Repository
{
    //TODO: Replace Fake Repo with Real Repo.
    public class PersonRepository : IPersonRepository
    {
        public Person GetPersonByName(string name)
        {
           return GetPersons().FirstOrDefault(x => x.Name == name);
        }

        public ObservableCollection<Person> GetPersons()
        {
            var employees = new ObservableCollection<Person>();
            for (int i = 0; i < 10; i++)
            {
                employees.Add(new Person() { Name = "Washington", Title = "President " + i, HasDetails = true, ProfilePic = @"/Assets/Blue hills.jpg" });
                employees.Add(new Person() { Name = "Adams", Title = "President " + i, HasDetails = false, ProfilePic = @"/Assets/Sunset.jpg" });
                employees.Add(new Person() { Name = "Jefferson", Title = "President " + i, HasDetails = true, ProfilePic = @"/Assets/Winter.jpg" });
                employees.Add(new Person() { Name = "Madison", Title = "President " + i, HasDetails = true, ProfilePic = @"/Assets/Water lilies.jpg" });
                employees.Add(new Person() { Name = "Monroe", Title = "President " + i, HasDetails = true, ProfilePic = @"/Assets/Arbiter.jpg" });
            }


            //employees.Add( new Person() { Name = "Washington", Title = "President 1", HasDetails = true, Affiliation = Party.Independent } );
            //employees.Add( new Person() { Name = "Adams", Title = "President 2", HasDetails = false, Affiliation = Party.Federalist } );
            //employees.Add( new Person() { Name = "Jefferson", Title = "President 3", HasDetails = true, Affiliation = Party.DemocratRepublican } );
            //employees.Add( new Person() { Name = "Madison", Title = "President 4", HasDetails = true, Affiliation = Party.DemocratRepublican } );
            //employees.Add( new Person() { Name = "Monroe", Title = "President 5", HasDetails = true, Affiliation = Party.DemocratRepublican } );
            return employees;
        }

    }

}
