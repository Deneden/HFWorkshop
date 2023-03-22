namespace HFJobs.Interfaces;

/// <summary>
/// Service for executing jobs with Delayed type.
/// </summary>
public interface IDelayedExecutor<T>
    where T  : class, IDelayedJob
{
    /// <summary>
    /// Executes delayed job by enqueuing it into hangfire storage.
    /// </summary>
    void RunAsync(CancellationToken ct);
}