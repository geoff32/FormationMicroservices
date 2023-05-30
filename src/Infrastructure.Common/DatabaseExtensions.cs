using System;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class DatabaseExtensions
{

    public static IServiceCollection AddDatabase<TContext>(this IServiceCollection services, string dbName, bool enableSensitiveDataLogging = false)
        where TContext : DbContext
    {
        services.AddDbContext<TContext>(dbContextBuilder =>
        {
            dbContextBuilder.UseInMemoryDatabase(dbName);
            dbContextBuilder.EnableSensitiveDataLogging(enableSensitiveDataLogging);
            dbContextBuilder.EnableDetailedErrors();
        });

        return services;
    }
}

