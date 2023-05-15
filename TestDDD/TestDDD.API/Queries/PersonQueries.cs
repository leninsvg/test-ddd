using TestDDD.Domain.Entities;
using TestDDD.Domain.Repositories;

namespace TestDDD.API.Queries;

public class PersonQueries
{
    private readonly IPersonRepository _personRepository;

    public PersonQueries(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public PersonEntity GetPerson(string identification)
    {
        PersonEntity personEntity = this._personRepository.GetPerson(identification);
        return personEntity;
    }
    
    public List<PersonEntity> GetPeople()
    {
        List<PersonEntity> people = this._personRepository.GetPeople();
        return people;
    }
}