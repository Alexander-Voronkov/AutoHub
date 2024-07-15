using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.Adverts.Domain.Adverts;

public class AdvertId : TypedIdValueBase
{
    public AdvertId(Guid value)
        : base(value)
    {
    }
}