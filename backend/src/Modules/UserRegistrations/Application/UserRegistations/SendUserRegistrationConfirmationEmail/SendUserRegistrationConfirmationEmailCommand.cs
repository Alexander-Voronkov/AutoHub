using AutoHub.Modules.UserRegistrations.Application.Configuration.Commands;
using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;
using Newtonsoft.Json;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.SendUserRegistrationConfirmationEmail;

public class SendUserRegistrationConfirmationEmailCommand : InternalCommandBase
{
    [JsonConstructor]
    public SendUserRegistrationConfirmationEmailCommand(
        Guid id,
        UserRegistrationId userRegistrationId,
        string email,
        string confirmLink)
        : base(id)
    {
        UserRegistrationId = userRegistrationId;
        Email = email;
        ConfirmLink = confirmLink;
    }

    internal UserRegistrationId UserRegistrationId { get; }

    internal string Email { get; }

    internal string ConfirmLink { get; }
}