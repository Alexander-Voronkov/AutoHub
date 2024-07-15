using AutoHub.Modules.UserRegistrations.Application.Contracts;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.ConfirmUserRegistration;

public class ConfirmUserRegistrationCommand : CommandBase
{
    public ConfirmUserRegistrationCommand(Guid userRegistrationId)
    {
        UserRegistrationId = userRegistrationId;
    }

    public Guid UserRegistrationId { get; }
}