using Hangfire;
using Hangfire.PostgreSql;
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

    public static void AddHangFireJobStorage(string connectionString)
    {
        // https://stackoverflow.com/questions/33427069/how-to-prevent-a-hangfire-recurring-job-from-restarting-after-30-minutes-of-cont
        var options = new PostgreSqlStorageOptions
        {
            InvisibilityTimeout = TimeSpan.FromHours(8)
        };

        JobStorage.Current = new PostgreSqlStorage(connectionString, options);
    }
}