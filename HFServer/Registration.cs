using Hangfire;
using Hangfire.PostgreSql;
using HFJobs;
using HFJobs.Interfaces;

namespace HFServer;

public static class Registration
{
    public static void AddHangFire(this IServiceCollection services)
    {
        var options = new PostgreSqlStorageOptions
        {
            // https://stackoverflow.com/questions/33427069/how-to-prevent-a-hangfire-recurring-job-from-restarting-after-30-minutes-of-cont
            InvisibilityTimeout = TimeSpan.FromHours(8)
        };

        const string connectionString = "Host=localhost;Port=5432;Database=hangfireWorkshop;Username=postgres;Password=postgres";

        services.AddHangfire(configuration =>
        {
            configuration
                // set minimal Hangfire version compatibility
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                // set serializer for more compact payloads
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(connectionString, options);
        });

        services.AddHangfireServer(serverOptions => serverOptions.Queues = new[] { Queues.DontCare, Queues.Default });
    }

    /// <summary>
    /// Runs monitoring recurring jobs.
    /// </summary>
    public static void RunMonitoringRecurringJobs(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var jobMonitoring = scope.ServiceProvider.GetRequiredService<IRecurringJobMonitoring>();
        var jobs = app.ApplicationServices.GetServices<IRecurringJob>();
        jobMonitoring.Run(jobs);
    }
}