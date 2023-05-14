using Microsoft.EntityFrameworkCore;
using TestDDD.API;
using TestDDD.API.ApplicationServices;
using TestDDD.API.Queries;
using TestDDD.Domain.Repositories;
using TestDDD.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TestDDDContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("TestDDD")); });


builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<PersonQueries>();
builder.Services.AddScoped<PersonServices>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.Run();

// using (IServiceScope scope = )
// {
//     // ApplicationDbContext
//
//     //applicationDb.Database.EnsureCreated();
//     // IdentityDbContext
//     //var identityDb = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
//     //identityDb.Database.Migrate();
//     // db.Database.EnsureCreated();           
// }