using Hangfire;
using Hangfire.PostgreSql;

namespace AppApi;

public static class Registration
{
    public static void AddHangFireJobStorage(this IServiceCollection services)
    {
        var options = new PostgreSqlStorageOptions
        {
            InvisibilityTimeout = TimeSpan.FromHours(8)
        };

        const string connectionString = "Host=localhost;Port=5432;Database=hangfireWorkshop;Username=postgres;Password=postgres";
        
        JobStorage.Current = new PostgreSqlStorage(connectionString, options);
    }
}