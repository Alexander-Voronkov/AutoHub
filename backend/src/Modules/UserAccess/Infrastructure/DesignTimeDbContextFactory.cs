using AutoHub.BuildingBlocks.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AutoHub.Modules.UserAccess.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UserAccessContext>
{
    public UserAccessContext CreateDbContext(string[] args)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<UserAccessContext>();

#if DEBUG
        var databaseConnectionString = "Server=db;Port=3306;Database=autohubdb;Uid=root;Pwd=qweasdzxc;";
#else
        var databaseConnectionString = "Server=db;Port=3306;Database=autohubdb;Uid=root;Pwd=qweasdzxc;";
#endif

        dbContextOptionsBuilder.UseMySql(
            databaseConnectionString,
            MySqlServerVersion.AutoDetect(databaseConnectionString),
            b => b.SchemaBehavior(
                MySqlSchemaBehavior.Translate,
                (schema, entity) => $"{schema ?? "dbo"}_{entity}"));

        dbContextOptionsBuilder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

        return new UserAccessContext(dbContextOptionsBuilder.Options);
    }
}