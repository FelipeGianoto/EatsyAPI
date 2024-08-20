using EatsyAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EatsyAPI.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using EatsyContext dbContext = scope.ServiceProvider.GetRequiredService<EatsyContext>();

            dbContext.Database.Migrate();
        }
    }
}
