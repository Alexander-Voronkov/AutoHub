using AutoHub.Modules.UserAccess.Application.Authentication;
using AutoHub.Modules.UserAccess.Application.Contracts;

namespace AutoHub.Modules.UserAccess.Application.Users.GetAuthenticatedUser;

public class GetAuthenticatedUserQuery : QueryBase<UserDto>
{
    public GetAuthenticatedUserQuery()
    {
    }
}