using AutoHub.BuildingBlocks.Domain;
using AutoHub.Modules.Adverts.Domain.Adverts.Events;

namespace AutoHub.Modules.Adverts.Domain.Adverts;

public class Advert : Entity
{
    public AdvertId Id { get; private set; }

    private string _title;

    private string _description;

    private UserId _ownerId;

    private Cost _cost;

    private bool _isEnabled;

    private Advert()
    {
        // for ef
    }

    public static Advert CreateAdvert(
        string title,
        string description,
        UserId ownerId,
        Cost cost)
    {
        return new Advert(
            Guid.NewGuid(),
            title,
            description,
            ownerId,
            cost);
    }

    private Advert(
        Guid id,
        string title,
        string description,
        UserId ownerId,
        Cost cost)
    {
        Id = new AdvertId(id);
        _title = title;
        _description = description;
        _ownerId = ownerId;
        _cost = cost;

        _isEnabled = true;

        AddDomainEvent(new AdvertCreatedDomainEvent(Id));
    }

    public void Activate()
    {
        _isEnabled = true;

        AddDomainEvent(new AdvertActivatedStatusChangedDomainEvent(Id));
    }

    public void Deactivate()
    {
        _isEnabled = false;

        AddDomainEvent(new AdvertActivatedStatusChangedDomainEvent(Id));
    }
}