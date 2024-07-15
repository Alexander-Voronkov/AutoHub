using MediatR;

namespace AutoHub.Modules.UserRegistrations.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}