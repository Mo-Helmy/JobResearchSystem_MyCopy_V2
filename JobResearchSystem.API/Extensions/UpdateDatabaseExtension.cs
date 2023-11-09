using JobResearchSystem.API;
using JobResearchSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace JobResearchSystem.API.Extensions
{
    public static class UpdateDatabaseExtension
    {
        public static async Task UpdateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                await dbContext.Database.MigrateAsync();

                await AppContextSeed.SeedAsync(dbContext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Database updating failed !");
            }
        }
    }
}
