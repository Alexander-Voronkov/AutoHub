using AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Domain.UserRegistrations;

public class RegistrationsEmailsRepository : IRegistrationsEmailsRepository
{
    private readonly RegistrationsContext _context;

    public RegistrationsEmailsRepository(RegistrationsContext context)
    {
        _context = context;
    }

    public async Task AddNewEmail(EmailMessage emailMessage)
    {
        await _context.Emails.AddAsync(emailMessage);
    }
}
