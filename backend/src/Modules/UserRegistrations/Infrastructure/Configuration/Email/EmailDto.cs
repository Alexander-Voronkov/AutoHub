namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Email;

public class EmailDto
{
    public Guid Id { get; set; }

    public string Content { get; set; }

    public string Receiver { get; set; }

    public string Subject { get; set; }

    public DateTime EnqueueDate { get; set; }

    public DateTime? SentDate { get; set; }

    public bool IsSent { get; set; }
}
