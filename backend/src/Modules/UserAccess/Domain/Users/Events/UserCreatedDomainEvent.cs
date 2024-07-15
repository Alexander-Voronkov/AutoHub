﻿using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.UserAccess.Domain.Users.Events;

public class UserCreatedDomainEvent : DomainEventBase
{
    public UserCreatedDomainEvent(UserId id)
    {
        Id = id;
    }

    public new UserId Id { get; }
}