using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using HFJobs;
using HFServer;

var builder = WebApplication.CreateBuilder(args);

const string connectionString = "Host=localhost;Port=5432;Database=hangfireWorkshop;Username=postgres;Password=postgres";

HFJobs.Registration.AddHangFireJobStorage(connectionString);
builder.Services.AddHangFireRecurringJobs();
builder.Services.AddHangFireExecutors();
builder.Services.AddHangFire();

var app = builder.Build();

app.UseHangfireDashboard("/jobs", new DashboardOptions
{
    Authorization = new[]
    {
        new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
        {
            RequireSsl = false,
            SslRedirect = false,
            LoginCaseSensitive = true,
            Users = new[]
            {
                new BasicAuthAuthorizationUser
                {
                    Login = "admin",
                    PasswordClear = "login"
                }
            }
        })
    }
});

app.RunMonitoringRecurringJobs();
app.Run();