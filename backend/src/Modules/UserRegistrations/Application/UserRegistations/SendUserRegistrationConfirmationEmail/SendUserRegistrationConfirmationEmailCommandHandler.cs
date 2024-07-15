using AutoHub.Modules.UserRegistrations.Application.Configuration.Commands;
using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;
using MediatR;
using Org.BouncyCastle.Asn1.Ocsp;

namespace AutoHub.Modules.UserRegistrations.Application.UserRegistations.SendUserRegistrationConfirmationEmail;

internal class SendUserRegistrationConfirmationEmailCommandHandler : ICommandHandler<SendUserRegistrationConfirmationEmailCommand>
{
    private readonly IRegistrationsEmailsRepository _registrationsEmailsRepository;

    public SendUserRegistrationConfirmationEmailCommandHandler(
        IRegistrationsEmailsRepository registrationsEmailsRepository)
    {
        _registrationsEmailsRepository = registrationsEmailsRepository;
    }

    public async Task Handle(SendUserRegistrationConfirmationEmailCommand command, CancellationToken cancellationToken)
    {
        string link = $"<a href=\"{command.ConfirmLink}{command.UserRegistrationId.Value}\">link</a>";

        string content = $"Welcome to AutoHub application! Please confirm your registration using this {link}.";

        await _registrationsEmailsRepository.AddNewEmail(EmailMessage.CreateEmail(content, "AutoHub Confirmation", command.Email));
    }
}