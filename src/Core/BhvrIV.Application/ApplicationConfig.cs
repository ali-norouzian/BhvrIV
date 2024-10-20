using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BhvrIV.Application;
public static class ApplicationConfig
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //var projectName = Assembly.GetExecutingAssembly().GetName().Name;

        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
            options.Namespace = "BhvrIV.Application.Mediator";
        });

        // Todo: add validation
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateCommandBehavior<,>));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

}

