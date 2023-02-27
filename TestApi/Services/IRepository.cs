using TestApi.Models;

namespace TestApi.Services
{
    public interface IRepository
    {
        public Person GetById(int id);

        public IEnumerable<Person> GetAllPersons();

        public Person Add(Person add);

        public void Delete(int id);
    }
}
