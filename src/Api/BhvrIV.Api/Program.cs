using BhvrIV.Application;
using BhvrIV.Persistence.Ef;

namespace BhvrIV.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // For ef core:
        //builder.Services.AddPersistenceEf();
        // For sp sql:
        builder.Services.AddPersistenceSql();
        builder.Services.AddApplication();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // For ef core:
        //await app.UpdateEfDb();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}