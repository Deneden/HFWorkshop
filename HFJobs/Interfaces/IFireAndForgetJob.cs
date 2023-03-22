namespace HFJobs.Interfaces;

public interface IFireAndForgetJob
{
    /// <summary>
    /// Executes job.
    /// </summary>
    Task ExecuteAsync(CancellationToken ct);
}