using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace TigerParkBackend.Infrastructure.DataAccess;

/// <summary>
/// Основной контекст данных
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Конструктор <see cref="AppDbContext"/>
    /// </summary>
    /// <param name="options">Настройки контекста</param>
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
    }
}