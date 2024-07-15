using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.UserAccess.Domain;

public class UserId : TypedIdValueBase
{
    public UserId(Guid id)
        : base(id)
    {
    }
}