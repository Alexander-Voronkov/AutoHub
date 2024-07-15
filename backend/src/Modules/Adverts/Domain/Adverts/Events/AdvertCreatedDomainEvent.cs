using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.Adverts.Domain.Adverts.Events;

public class AdvertCreatedDomainEvent : DomainEventBase
{
    public AdvertId AdvertId { get; }

    public AdvertCreatedDomainEvent(AdvertId advertId)
    {
        AdvertId = advertId;
    }
}