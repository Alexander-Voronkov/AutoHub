using AutoHub.BuildingBlocks.Application;
using AutoHub.Modules.Adverts.Domain;

namespace AutoHub.Modules.Adverts.Application;

public class UserContext : IUserContext
{
    private readonly IExecutionContextAccessor _contextAccessor;

    public UserContext(
        IExecutionContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor; 
    }

    public UserId CurrentUserId => new UserId(_contextAccessor.UserId);
}