using CoreStorage.StorageContext;
using Microsoft.EntityFrameworkCore;

namespace LicensePermssion.StartupCoreModules.SqlService;

public static class SqlService
{
    public static void RunSqlService(this IServiceCollection service, IConfiguration configuration)
    {
        var storageConnection = configuration.GetConnectionString("DefaultConnection");
        service.AddDbContextPool<ApplicationContext>(option =>
        {
            option.UseSqlServer(storageConnection, x =>
            {
                x.EnableRetryOnFailure(3);
                x.MinBatchSize(5);
                x.MaxBatchSize(50);
                x.UseNodaTime();
            }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            option.AddInterceptors();
            option.EnableDetailedErrors();
            option.EnableSensitiveDataLogging();
            option.LogTo(Console.WriteLine);
        });
    }
}