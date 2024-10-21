using BhvrIV.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace BhvrIV.Api.Extensions;

public static class EfDbExtensions
{
    public static async Task<IApplicationBuilder> UpdateEfDb(this IApplicationBuilder app)
    {
        await using (var scope = app.ApplicationServices.CreateAsyncScope())
        {
            var dbContext = scope.ServiceProvider.GetService<AppWriteDbContext>() ??
                           throw new Exception("Database Context Not Found");
            try
            {
                dbContext.Database.MigrateAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            catch
            {
            }
        }

        return app;
    }
}
