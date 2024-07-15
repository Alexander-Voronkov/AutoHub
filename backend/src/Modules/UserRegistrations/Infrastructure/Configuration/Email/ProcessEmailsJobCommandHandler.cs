using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.BuildingBlocks.Infrastructure;
using AutoHub.BuildingBlocks.Infrastructure.Emails;
using AutoHub.Modules.UserRegistrations.Application.Configuration.Commands;
using Dapper;
using MediatR;

namespace AutoHub.Modules.UserRegistrations.Infrastructure.Configuration.Email;

public class ProcessEmailsJobCommandHandler : ICommandHandler<ProcessEmailsCommand>
{
    private readonly ISqlConnectionFactory _connectionFactory;
    private readonly IEmailSendingService _emailSendingService;

    public ProcessEmailsJobCommandHandler(
        ISqlConnectionFactory sqlConnectionFactory,
        IEmailSendingService emailSendingService)
    {
        _connectionFactory = sqlConnectionFactory;
        _emailSendingService = emailSendingService;
    }

    public async Task Handle(ProcessEmailsCommand request, CancellationToken cancellationToken)
    {
        var connection = _connectionFactory.GetOpenConnection();

        const string sql = $"""
                               SELECT 
                                   `Email`.`Id` AS `{nameof(EmailDto.Id)}`, 
                                   `Email`.`Receiver` AS `{nameof(EmailDto.Receiver)}`, 
                                   `Email`.`Content` AS `{nameof(EmailDto.Content)}`,
                                   `Email`.`Subject` AS `{nameof(EmailDto.Subject)}`,
                                   `Email`.`EnqueueDate` AS `{nameof(EmailDto.EnqueueDate)}`,
                                   `Email`.`SentDate` AS `{nameof(EmailDto.SentDate)}` 
                               FROM `registrations_Emails` AS `Email` 
                               WHERE `Email`.`IsSent` = 0
                            """;

        const string updateEmailStatusSql = $"""
                                                UPDATE `registrations_Emails`
                                                SET 
                                                    `IsSent` = 1,
                                                    `SentDate` = @SentDate
                                                WHERE `Id` = @EmailId
                                            """;

        var result = await connection.QueryAsync<EmailDto>(sql);

        var emails = result.AsList();

        foreach (var email in emails)
        {
            await _emailSendingService.SendMail(email.Receiver, email.Subject, email.Content, "autohub_noreply");
            await connection.ExecuteAsync(
                updateEmailStatusSql,
                new
                {
                    SentDate = DateTime.UtcNow,
                    EmailId = email.Id,
                });
        }
    }
}
