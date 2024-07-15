using MediatR;

namespace AutoHub.Modules.Adverts.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}