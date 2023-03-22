using Hangfire;
using HFJobs;
using HFServer;
using HFServer.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangFireRecurringJobs();
builder.Services.AddHangFireExecutors();
builder.Services.AddHangFire();

var app = builder.Build();

app.UseHangfireDashboard("/jobs", new DashboardOptions()
{
    Authorization = new[] { new HFAuthorizationFilter() }
});

app.MapHangfireDashboard();
app.RunMonitoringRecurringJobs();
app.Run();