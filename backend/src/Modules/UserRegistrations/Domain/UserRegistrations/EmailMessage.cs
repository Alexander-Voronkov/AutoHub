using AutoHub.BuildingBlocks.Domain;

namespace AutoHub.Modules.UserRegistrations.Domain.UserRegistrations;

public class EmailMessage : Entity, IAggregateRoot
{
    public EmailMessageId Id { get; private set; }

    private string _content;

    private string _subject;

    private string _receiver;

    private DateTime? _sentDate;

    private DateTime _enqueueDate;

    private bool _isSent;

    public static EmailMessage CreateEmail(
        string content,
        string subject,
        string receiver)
    {
        return new EmailMessage(
            Guid.NewGuid(),
            content,
            subject,
            receiver,
            DateTime.UtcNow);
    }

    private EmailMessage(
        Guid id,
        string content,
        string subject,
        string receiver,
        DateTime enqueueDate)
    {
        Id = new EmailMessageId(id);
        _isSent = false;
        _sentDate = null;
        _enqueueDate = enqueueDate;
        _content = content;
        _subject = subject;
        _receiver = receiver;
    }

    private EmailMessage()
    {
        // ef
    }
}