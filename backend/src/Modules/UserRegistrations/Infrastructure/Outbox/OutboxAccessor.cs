﻿using AutoHub.BuildingBlocks.Application.Outbox;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly RegistrationsContext _userAccessContext;

        public OutboxAccessor(RegistrationsContext userAccessContext)
        {
            _userAccessContext = userAccessContext;
        }

        public void Add(OutboxMessage message)
        {
            _userAccessContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}