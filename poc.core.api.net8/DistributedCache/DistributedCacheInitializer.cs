using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using poc.core.api.net8.AppSettings;
using poc.core.api.net8.DistributedCache.Configuration;
using poc.core.api.net8.DistributedCache.Redis;
using poc.core.api.net8.Interface;
using StackExchange.Redis;

namespace poc.core.api.net8.DistributedCache;

public class DistributedCacheInitializer
{
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {

        services.AddSingleton<IConfiguration>(provider => configuration);
        services.AddSingleton<RedisConnection>();
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("CacheConnection")));
        services.AddScoped(typeof(IRedisCacheService<>), typeof(RedisCacheService<>));
        services.Configure<CacheOptions>(configuration.GetSection("CacheOptions"));
    }

}
