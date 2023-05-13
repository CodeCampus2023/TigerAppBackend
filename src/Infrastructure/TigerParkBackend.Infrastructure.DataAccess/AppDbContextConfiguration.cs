using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TigerParkBackend.Infrastructure.DataAccess.Interfaces;

namespace TigerParkBackend.Infrastructure.DataAccess;

/// <summary>
/// Конфигурация <see cref="AppDbContext"/> контекста 
/// </summary>
public class AppDbContextConfiguration : IDbContextOptionsConfigurator<AppDbContext>
{
    private const string PostgresConnectionStringName = "PostgresDb";
    
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

    /// <summary>
    /// Конструктор <see cref="AppDbContextConfiguration"/>
    /// </summary>
    /// <param name="configuration">Конфигурации</param>
    /// <param name="loggerFactory">Фабрика логгеров</param>
    public AppDbContextConfiguration(IConfiguration configuration, ILoggerFactory loggerFactory)
    {
        _configuration = configuration;
        _loggerFactory = loggerFactory;
    }
    
    /// <inheritdoc />
    /// <exception cref="InvalidOperationException">Строка подключения не найдена в конфигурациях</exception>
    public void Configure(DbContextOptionsBuilder<AppDbContext> options)
    {
        var connectionString = _configuration.GetConnectionString(PostgresConnectionStringName);
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException(
                $"Не найдена строка подключения с именем '{PostgresConnectionStringName}'");
        options.UseNpgsql(connectionString);
        options.UseLoggerFactory(_loggerFactory);
        options.UseLazyLoadingProxies();
    }
}