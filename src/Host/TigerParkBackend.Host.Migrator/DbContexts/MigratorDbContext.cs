using Microsoft.EntityFrameworkCore;
using TigerParkBackend.Infrastructure.DataAccess;

namespace TigerParkBackend.Host.Migrator.DbContexts;

/// <summary>
/// Контекст для мигратора
/// </summary>
public class MigratorDbContext : AppDbContext
{
    public MigratorDbContext(DbContextOptions options) : base(options)
    {
    }
}