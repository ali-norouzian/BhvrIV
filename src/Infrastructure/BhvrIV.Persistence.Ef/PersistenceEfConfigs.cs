﻿using BhvrIV.Domain.Contracts.Persistence;
using BhvrIV.Persistence.Ef.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BhvrIV.Persistence.Ef;

public static class PersistenceEfConfigs
{
    public static IServiceCollection AddPersistenceEf(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();

        services.AddDbContextPool<AppWriteDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        });

        services.AddDbContextPool<AppReadDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}