using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace BhvrIV.Persistence.Ef;

public static class PersistenceSqlConfigs
{
    public static IServiceCollection AddPersistenceSql(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();

        services.AddScoped<IDbConnection>(sp =>
                 new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
        //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        //services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}