namespace AutoHub.BuildingBlocks.Infrastructure.Emails;

public class EmailsConfiguration
{
    public EmailsConfiguration(
        string fromEmail,
        int port,
        string smtpServer,
        string password)
    {
        FromEmail = fromEmail;
        Port = port;
        SmtpServer = smtpServer;
        Password = password;
    }

    public string FromEmail { get; }

    public string SmtpServer { get; }

    public int Port { get; }

    public string Password { get; }
}