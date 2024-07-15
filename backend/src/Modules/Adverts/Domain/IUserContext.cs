namespace AutoHub.Modules.Adverts.Domain;

public interface IUserContext
{
    UserId CurrentUserId { get; }
}