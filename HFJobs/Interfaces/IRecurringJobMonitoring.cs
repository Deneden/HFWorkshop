namespace HFJobs.Interfaces;

/// <summary>
/// Service for monitoring recurring jobs.
/// </summary>
public interface IRecurringJobMonitoring
{
    /// <summary>
    /// Runs recurring jobs and delete jobs which don't exist.
    /// </summary>
    void Run(IEnumerable<IRecurringJob> jobs);
}