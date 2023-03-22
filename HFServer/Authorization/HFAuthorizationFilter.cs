using Hangfire.Dashboard;

namespace HFServer.Authorization;

internal sealed class HFAuthorizationFilter : IDashboardAuthorizationFilter
{
    // TODO: configure authorization of hangfire dashboard
    /// <inheritdoc />
    public bool Authorize(DashboardContext context) => true;
}