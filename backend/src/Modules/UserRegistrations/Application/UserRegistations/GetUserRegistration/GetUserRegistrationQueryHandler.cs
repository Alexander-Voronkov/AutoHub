using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.Modules.UserRegistrations.Application.Configuration.Queries;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.GetUserRegistration;

internal class GetUserRegistrationQueryHandler : IQueryHandler<GetUserRegistrationQuery, UserRegistrationDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetUserRegistrationQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public Task<UserRegistrationDto> Handle(GetUserRegistrationQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        return UserRegistrationProvider.GetById(connection, query.UserRegistrationId);
    }
}