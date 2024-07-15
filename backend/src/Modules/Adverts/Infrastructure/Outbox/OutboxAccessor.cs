using System.Configuration;
using AutoHub.BuildingBlocks.Application.Outbox;

namespace AutoHub.Modules.Adverts.Infrastructure.Outbox;

public class OutboxAccessor : IOutbox
{
    private readonly AdvertsContext _meetingsContext;

    internal OutboxAccessor(AdvertsContext meetingsContext)
    {
        _meetingsContext = meetingsContext;
    }

    public void Add(OutboxMessage message)
    {
        _meetingsContext.OutboxMessages.Add(message);
    }

    public Task Save()
    {
        return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
    }
}