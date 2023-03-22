using Hangfire;
using HFJobs.Interfaces;

namespace HFJobs.Jobs;

/// <summary>
/// Test recurring job
/// </summary>
public class RecurringDraft: IRecurringJob
{
    public string JobId { get; init; } = nameof(RecurringDraft);
    
    public Task ExecuteAsync()
    {
        Console.WriteLine("Example of Recurring job");
        
        return Task.CompletedTask;
    }

    public string Schedule { get; init; } = Cron.Minutely();
}