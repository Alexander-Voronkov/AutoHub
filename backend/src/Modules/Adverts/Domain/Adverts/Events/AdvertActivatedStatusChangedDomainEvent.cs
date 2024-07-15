using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.Adverts.Domain.Adverts.Events;

public class AdvertActivatedStatusChangedDomainEvent : DomainEventBase
{
    public AdvertId AdvertId { get; }

    public AdvertActivatedStatusChangedDomainEvent(
        AdvertId advertId)
    {
        AdvertId = advertId;
    }
}