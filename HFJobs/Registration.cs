using HFJobs.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HFJobs;

public static class Registration
{
    public static void AddHangFireRecurringJobs(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(classes => classes.AssignableTo<IRecurringJob>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());
    }

    public static void AddHangFireExecutors(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(classes => classes.AssignableTo(typeof(IFireAndForgetExecutor<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo(typeof(IDelayedExecutor<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo<IRecurringJobMonitoring>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}