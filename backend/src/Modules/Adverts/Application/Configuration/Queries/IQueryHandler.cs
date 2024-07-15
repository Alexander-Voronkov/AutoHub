using AutoHub.Modules.Adverts.Application.Contracts;
using MediatR;

namespace AutoHub.Modules.Adverts.Application.Configuration.Queries;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}