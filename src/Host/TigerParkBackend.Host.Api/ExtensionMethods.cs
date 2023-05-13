using Microsoft.EntityFrameworkCore;
using TigerParkBackend.Infrastructure.DataAccess;
using TigerParkBackend.Infrastructure.DataAccess.Interfaces;

namespace TigerParkBackend.Host.Api;

/// <summary>
/// Методы расширения для класса <see cref="Program"/>
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// Добавить DbContext с конфигурациями в DI
    /// </summary>
    /// <param name="serviceCollection">Сервисы программы</param>
    public static void AddDbContextWithConfigurations(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IDbContextOptionsConfigurator<AppDbContext>, AppDbContextConfiguration>();
        serviceCollection.AddDbContext<AppDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
            ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<AppDbContext>>()
                .Configure((DbContextOptionsBuilder<AppDbContext>)dbOptions)));
        serviceCollection.AddScoped((Func<IServiceProvider, DbContext>) (sp => sp.GetRequiredService<AppDbContext>()));
    }
}