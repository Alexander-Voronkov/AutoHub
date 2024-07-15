using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.Adverts.Domain;

public class UserId : TypedIdValueBase
{
    public UserId(Guid value)
        : base(value)
    {
    }
}
