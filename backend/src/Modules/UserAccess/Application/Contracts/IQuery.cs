using MediatR;

namespace AutoHub.Modules.UserAccess.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}