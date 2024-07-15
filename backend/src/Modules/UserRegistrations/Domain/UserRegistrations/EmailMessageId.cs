using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;

public class EmailMessageId : TypedIdValueBase
{
    public EmailMessageId(Guid value)
        : base(value)
    {
    }
}
