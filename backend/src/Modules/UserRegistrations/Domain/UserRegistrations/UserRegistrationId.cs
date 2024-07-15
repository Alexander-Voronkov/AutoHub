using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;

public class UserRegistrationId : TypedIdValueBase
{
    public UserRegistrationId(Guid value)
        : base(value)
    {
    }
}