
using BhvrIV.Application;
using BhvrIV.Persistence.Ef;
using Microsoft.EntityFrameworkCore;

namespace BhvrIV.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddPersistenceEf()
                        .AddApplication();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        await using (var scope = app.Services.CreateAsyncScope())
        {
            var dbContext = scope.ServiceProvider.GetService<AppWriteDbContext>() ??
                           throw new Exception("Database Context Not Found");
            dbContext.Database.MigrateAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}