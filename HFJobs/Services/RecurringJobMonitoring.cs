using Hangfire;
using Hangfire.Storage;
using HFJobs.Interfaces;

namespace HFJobs.Services;

/// <inheritdoc/>
public class RecurringJobMonitoring : IRecurringJobMonitoring
{
    public void Run(IEnumerable<IRecurringJob> jobs)
    {
        var ensuredJobs = new List<IRecurringJob>();

        foreach (var job in jobs)
        {
            RecurringJob.AddOrUpdate(job.JobId, () => job.ExecuteAsync(), job.Schedule);
            ensuredJobs.Add(job);
        }

        var existingJobs = GetIdOfRecurringJobs();
        var configuredJobs = ensuredJobs.Select(c => c.JobId);

        var jobsToDelete = existingJobs.Except(configuredJobs, StringComparer.Ordinal);

        foreach (var jobId in jobsToDelete)
        {
            RecurringJob.RemoveIfExists(jobId);
        }
    }

    private static IEnumerable<string> GetIdOfRecurringJobs()
    {
        return JobStorage.Current.GetConnection().GetRecurringJobs().Select(s => s.Id);
    }
}