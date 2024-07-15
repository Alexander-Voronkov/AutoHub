﻿using MediatR;

namespace AutoHub.BuildingBlocks.Infrastructure.DomainEventsDispatching;

public class UnitOfWorkCommandHandlerDecorator<T> : IRequestHandler<T>
    where T : IRequest
{
    private readonly IRequestHandler<T> _decorated;
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkCommandHandlerDecorator(
        IRequestHandler<T> decorated,
        IUnitOfWork unitOfWork)
    {
        _decorated = decorated;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(T command, CancellationToken cancellationToken)
    {
        await _decorated.Handle(command, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);
    }
}