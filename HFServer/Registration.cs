using Hangfire;
using HFJobs;
using HFJobs.Interfaces;

namespace HFServer;

public static class Registration
{
    public static void AddHangFire(this IServiceCollection services)
    {
        services.AddHangfire(configuration =>
        {
            configuration
                // set minimal Hangfire version compatibility
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                // set serializer for more compact payloads
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings();
        });

        services.AddHangfireServer(serverOptions => serverOptions.Queues = new[] { Queues.DontCare, Queues.Default, Queues.Hot });
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