namespace HFJobs.Interfaces;

public interface IRecurringJob
{
    /// <summary>
    /// ID of recurring job.
    /// </summary>
    public string JobId { get; }

    /// <summary>
    /// Executes some action of job.
    /// </summary>
    public Task ExecuteAsync();

    /// <summary>
    /// Schedule of recurring job.
    /// </summary>
    public string Schedule { get; }
}