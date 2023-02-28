using System.Text.Json;
using System.Text.Json.Serialization;
using TestApi.Models;



namespace TestApi.Services
{
    public class Repo : IRepository
    {
        static readonly string filecontext = File.ReadAllText("Data/PersonData2.json");
        List<Person> persons = JsonSerializer.Deserialize<List<Person>>(filecontext);

        public Person GetById(int id)
        {
            return persons.FirstOrDefault(q => q.Id == id);        
        }
        public IEnumerable<Person> GetAllPersons()
        {
            return persons.ToList();        
        }
        public Person Add(Person added)
        {
            persons.Add(added);
            return added;
        }

        public void Delete(int id)
        {
            var person = GetById(id);
            if(person == null)
            {
                throw new ArgumentException("No Person by this id", nameof(id));
            }
            persons.Remove(person);
        }
    }
}
