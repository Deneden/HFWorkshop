using Hangfire;
using HFJobs.Interfaces;

namespace HFJobs.Services;

/// <inheritdoc/>
public sealed class FireAndForgetExecutor<T> : IFireAndForgetExecutor<T>
    where T : class, IFireAndForgetJob
{
    public void Enqueue(CancellationToken ct)
    {
        BackgroundJob.Enqueue<T>(job => job.ExecuteAsync(ct));
    }
}