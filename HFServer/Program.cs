using Hangfire;
using HFJobs;
using HFServer;
using HFServer.Authorization;

var builder = WebApplication.CreateBuilder(args);

const string connectionString = "Host=localhost;Port=5432;Database=hangfireWorkshop;Username=postgres;Password=postgres";
        
HFJobs.Registration.AddHangFireJobStorage(connectionString);
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