using AutoHub.BuildingBlocks.Application.Outbox;
using AutoHub.BuildingBlocks.Infrastructure.InternalCommands;
using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;
using AutoHub.Modules.UserRegistrations.Infrastructure.Domain.UserRegistrations;
using AutoHub.Modules.UserRegistrations.Infrastructure.InternalCommands;
using AutoHub.Modules.UserRegistrations.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoHub.Modules.UserRegistrations.Infrastructure
{
    public class RegistrationsContext : DbContext
    {
        public DbSet<UserRegistration> UserRegistrations { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        public DbSet<EmailMessage> Emails { get; set; }

        private readonly ILoggerFactory _loggerFactory;

        public RegistrationsContext(DbContextOptions options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        internal RegistrationsContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}