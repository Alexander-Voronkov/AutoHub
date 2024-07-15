using AutoHub.Modules.UserRegistrations.Application.Contracts;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.GetUserRegistration;

public class GetUserRegistrationQuery : QueryBase<UserRegistrationDto>
{
    public GetUserRegistrationQuery(Guid userRegistrationId)
    {
        UserRegistrationId = userRegistrationId;
    }

    public Guid UserRegistrationId { get; }
}