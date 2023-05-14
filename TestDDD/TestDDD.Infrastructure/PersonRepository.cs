using TestDDD.Domain.Entities;
using TestDDD.Domain.Repositories;

namespace TestDDD.Infrastructure;

public class PersonRepository : IPersonRepository
{
    private readonly TestDDDContext _testDddContext;

    public PersonRepository(TestDDDContext testDddContext)
    {
        _testDddContext = testDddContext;
    }

    public PersonEntity GetPerson(string identification)
    {
        return this._testDddContext.Persons.Find(identification);
    }

    public void AddPerson(PersonEntity person)
    {
        this._testDddContext.Persons.Add(person);
        this._testDddContext.SaveChanges();
    }

    public void UpdatePerson(PersonEntity person)
    {
        this._testDddContext.Persons.Update(person);
        this._testDddContext.SaveChanges();
    }

    public void DeletePerson(PersonEntity person)
    {
        this._testDddContext.Remove(person);
        this._testDddContext.SaveChanges();
    }
}