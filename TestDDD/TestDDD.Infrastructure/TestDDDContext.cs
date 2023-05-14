using Microsoft.EntityFrameworkCore;
using TestDDD.Domain.Entities;

namespace TestDDD.Infrastructure;

public class TestDDDContext: DbContext
{
    public TestDDDContext(DbContextOptions<TestDDDContext> options): base(options)
    {
        
    }

    public DbSet<PersonEntity> Persons { get; set; }
}