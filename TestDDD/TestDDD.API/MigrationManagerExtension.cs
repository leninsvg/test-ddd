using Microsoft.EntityFrameworkCore;
using TestDDD.Infrastructure;

namespace TestDDD.API
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<TestDDDContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception e)
                    {
                        //Log errors or do anything you think it's needed
                        throw e;
                    }
                }
            }
            return webApp;
        }
    }
}
