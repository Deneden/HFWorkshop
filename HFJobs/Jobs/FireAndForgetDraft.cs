using Hangfire;
using HFJobs.Interfaces;

namespace HFJobs.Jobs;

/// <summary>
/// Test fire and forget job
/// </summary>
[Queue(Queues.DontCare)]
public class FireAndForgetDraft : IFireAndForgetJob
{
    public Task ExecuteAsync(CancellationToken ct)
    {
        Console.WriteLine("Example of Fire and forget");

        return Task.CompletedTask;
    }
}