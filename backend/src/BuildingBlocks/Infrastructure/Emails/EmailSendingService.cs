using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Serilog;

namespace AutoHub.BuildingBlocks.Infrastructure.Emails;

public class EmailSendingService : IEmailSendingService
{
    private readonly EmailsConfiguration _configuration;

    public EmailSendingService(
        EmailsConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMail(string receiver, string subject, string htmlContent, string senderName)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(senderName, _configuration.FromEmail));
        message.To.Add(new MailboxAddress(receiver, receiver));
        message.Subject = subject;

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = htmlContent
        };

        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            try
            {
                await client.ConnectAsync(_configuration.SmtpServer, _configuration.Port, false);
                await client.AuthenticateAsync(_configuration.FromEmail, _configuration.Password);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
                client.Dispose();
            }
        }
    }
}
