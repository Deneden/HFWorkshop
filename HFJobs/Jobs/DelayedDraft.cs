using Hangfire;
using HFJobs.Interfaces;

namespace HFJobs.Jobs;

/// <summary>
/// Test delayed job
/// </summary>
[Queue(Queues.Hot)]
public class DelayedDraft: IDelayedJob
{
    public TimeSpan Delay { get; init; } = TimeSpan.FromMinutes(5);
    
    public Task ExecuteAsync(CancellationToken ct)
    {
        Console.WriteLine("Example of Delayed job");

        return Task.CompletedTask;
    }
}