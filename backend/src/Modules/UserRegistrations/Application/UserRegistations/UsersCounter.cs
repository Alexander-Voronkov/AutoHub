using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;
using Dapper;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations;

public class UsersCounter : IUsersCounter
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public UsersCounter(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public int CountUsersWithLogin(string login)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = """
                                SELECT COUNT(*) 
                                FROM registrations_UserRegistrations AS UserRegistration
                                WHERE UserRegistration.Login = @Login
                                """;
        return connection.QuerySingle<int>(
            sql,
            new
            {
                login
            });
    }
}