using TestDDD.API.Commands;
using TestDDD.Domain.Entities;
using TestDDD.Domain.Repositories;
using TestDDD.Domain.ValueObjects;

namespace TestDDD.API.ApplicationServices;

public class PersonServices
{
    private readonly IPersonRepository _personRepository;

    public PersonServices(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public void CreatePerson(CreatePersonCommand personCommand)
    {
        PersonEntity personEntity = new()
        {
            Age = personCommand.age,
            Gender = personCommand.gender,
            FirstNames = personCommand.firstNames,
            LastNames = personCommand.lastNames,
            Identification = Identification.Create(personCommand.identification).Value 
        };
        this._personRepository.AddPerson(personEntity);
    }

    public void UpdatePerson(string identification, UpdatePersonCommand personCommand)
    {
        PersonEntity personEntity = this._personRepository.GetPerson(identification);
        personEntity.Age = personCommand.age;
        personEntity.FirstNames = personCommand.firstNames;
        personEntity.LastNames = personCommand.lastNames;
        personEntity.Gender = personCommand.gender;
        this._personRepository.UpdatePerson(personEntity);
    }
    
    public void DeletePerson(string identification)
    {
        PersonEntity personEntity = this._personRepository.GetPerson(identification);
        this._personRepository.DeletePerson(personEntity);
    }
}