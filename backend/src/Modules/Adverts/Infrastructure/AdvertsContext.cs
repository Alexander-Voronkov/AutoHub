using AutoHub.BuildingBlocks.Application.Outbox;
using AutoHub.BuildingBlocks.Infrastructure.InternalCommands;
using AutoHub.Modules.Adverts.Domain.Adverts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoHub.Modules.Adverts.Infrastructure;

public class AdvertsContext : DbContext
{
    public DbSet<Advert> Adverts { get; set; }

    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public DbSet<InternalCommand> InternalCommands { get; set; }

    private readonly ILoggerFactory _loggerFactory;

    public AdvertsContext(
        DbContextOptions options,
        ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    internal AdvertsContext(DbContextOptions options)
        : base(options)
    {
        // ef migrations
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}