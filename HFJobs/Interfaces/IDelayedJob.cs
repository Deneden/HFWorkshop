namespace HFJobs.Interfaces;

public interface IDelayedJob
{
    /// <summary>
    /// Delay of job.
    /// </summary>
    TimeSpan Delay { get; }

    /// <summary>
    /// Executes job.
    /// </summary>
    Task ExecuteAsync(CancellationToken ct);
}