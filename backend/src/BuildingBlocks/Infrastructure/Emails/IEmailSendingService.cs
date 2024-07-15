namespace AutoHub.BuildingBlocks.Infrastructure.Emails;

public interface IEmailSendingService
{
    public Task SendMail(string receiver, string subject, string htmlContent, string senderName);
}