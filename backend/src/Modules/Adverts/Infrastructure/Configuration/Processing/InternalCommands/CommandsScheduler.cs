using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.BuildingBlocks.Infrastructure.Serialization;
using AutoHub.Modules.Adverts.Application.Configuration.Commands;
using AutoHub.Modules.Adverts.Application.Contracts;
using Dapper;
using Newtonsoft.Json;

namespace AutoHub.Modules.Adverts.Infrastructure.Configuration.Processing.InternalCommands;

public class CommandsScheduler : ICommandsScheduler
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public CommandsScheduler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task EnqueueAsync(ICommand command)
    {
        var connection = this._sqlConnectionFactory.GetOpenConnection();

        const string sqlInsert = "INSERT INTO `adverts_InternalCommands` (`Id`, `EnqueueDate` , `Type`, `Data`) VALUES " +
                                 "(@Id, @EnqueueDate, @Type, @Data)";

        await connection.ExecuteAsync(sqlInsert, new
        {
            command.Id,
            EnqueueDate = DateTime.UtcNow,
            Type = command.GetType().FullName,
            Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
            {
                ContractResolver = new AllPropertiesContractResolver()
            })
        });
    }

    public Task EnqueueAsync<T>(ICommand<T> command)
    {
        throw new NotImplementedException();
    }
}