using Hangfire;
using HFJobs.Interfaces;

namespace HFJobs.Services;

/// <inheritdoc/>
public class DelayedExecutor<T> : IDelayedExecutor<T>
    where T : class, IDelayedJob
{
    private readonly T _job = Activator.CreateInstance<T>();

    public void RunAsync(CancellationToken ct)
    {
        BackgroundJob.Schedule(() => _job.ExecuteAsync(ct), _job.Delay);
    }
}