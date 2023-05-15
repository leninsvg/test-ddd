using Microsoft.AspNetCore.Mvc;
using TestDDD.API.ApplicationServices;
using TestDDD.API.Commands;
using TestDDD.API.Queries;
using TestDDD.Domain.Entities;

namespace TestDDD.API.Controllers;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase
{
    private readonly PersonServices _personServices;
    private readonly PersonQueries _personQueries;

    public PersonController(PersonServices personServices, PersonQueries personQueries)
    {
        _personServices = personServices;
        _personQueries = personQueries;
    }

    [HttpPost]
    public ActionResult CreatePerson([FromBody] CreatePersonCommand personCommand)
    {
        _personServices.CreatePerson(personCommand);
        return Ok();
    }

    [HttpPut("{identification}")]
    public ActionResult UpdatePerson([FromRoute] string identification, [FromBody] UpdatePersonCommand personCommand)
    {
        _personServices.UpdatePerson(identification, personCommand);
        return Ok();
    }

    [HttpDelete("{identification}")]
    public ActionResult DeletePerson([FromRoute] string identification)
    {
        _personServices.DeletePerson(identification);
        return Ok();
    }

    [HttpGet("{identification}")]
    public ActionResult<PersonEntity> GetPerson([FromRoute] string identification)
    {
        PersonEntity personEntity = _personQueries.GetPerson(identification);
        return Ok(personEntity);
    }
    
    [HttpGet]
    public ActionResult<List<PersonEntity>> GetPeople()
    {
        List<PersonEntity> people = _personQueries.GetPeople();
        return Ok(people);
    }
}