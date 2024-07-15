namespace AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;

public interface IRegistrationsEmailsRepository
{
    Task AddNewEmail(EmailMessage emailMessage);
}
