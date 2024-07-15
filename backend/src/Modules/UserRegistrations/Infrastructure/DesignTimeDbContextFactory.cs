using AutoHub.BuildingBlocks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AutoHub.Modules.UserRegistrations.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RegistrationsContext>
{
    public RegistrationsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RegistrationsContext>();

#if DEBUG
        var connstring = "Server=db;Port=3306;Database=autohubdb;Uid=root;Pwd=qweasdzxc;";
#else
        var connstring = "Server=172.16.11.5;Port=3306;Database=autohubdb;User=root;Password=qweasdzxc;";
#endif

        optionsBuilder.UseMySql(
            connstring,
            MySqlServerVersion.AutoDetect(connstring),
            b => b.SchemaBehavior(
                MySqlSchemaBehavior.Translate,
                (schema, entity) => $"{schema ?? "dbo"}_{entity}"));

        optionsBuilder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

        return new RegistrationsContext(optionsBuilder.Options);
    }
}