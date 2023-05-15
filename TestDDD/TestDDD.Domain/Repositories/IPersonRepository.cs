using TestDDD.Domain.Entities;

namespace TestDDD.Domain.Repositories;

public interface IPersonRepository
{
    PersonEntity GetPerson(string identification);
    void AddPerson(PersonEntity person);
    void UpdatePerson(PersonEntity person);
    void DeletePerson(PersonEntity person);
    List<PersonEntity> GetPeople();
}