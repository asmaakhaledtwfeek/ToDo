﻿using Scrutor;

namespace ToDo.API.Configurations;

internal static class AppServicesDIConfig
{
    internal static IServiceCollection AddAppServicesDIConfig(this IServiceCollection services)
    {
        services
            .Scan(
                selector => selector
                    .FromAssemblies(
                        Infrastructure.AssemblyReference.Assembly,
                        Application.AssemblyReference.Assembly,
                        Persistence.AssemblyReference.Assembly)
                    .AddClasses(false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        return services;
    }
}
