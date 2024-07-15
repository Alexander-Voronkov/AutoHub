using AutoHub.Modules.UserAccess.Application.Contracts;

namespace AutoHub.Modules.UserAccess.Application.Users.GetUser;

public class GetUserQuery : QueryBase<UserDto>
{
    public GetUserQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; }
}