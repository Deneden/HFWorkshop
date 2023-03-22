namespace HFJobs.Interfaces;

/// <summary>
/// Service for executing jobs with Fire and forget type.
/// </summary>
public interface IFireAndForgetExecutor<T>
    where T : class, IFireAndForgetJob
{
    /// <summary>
    /// Executes fire and forget job by enqueuing it into hangfire storage.
    /// </summary>
    void Enqueue(CancellationToken ct);
}