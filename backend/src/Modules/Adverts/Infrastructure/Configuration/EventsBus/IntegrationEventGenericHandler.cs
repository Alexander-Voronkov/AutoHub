using Autofac;
using AutoHub.BuildingBlocks.Application.Data;
using AutoHub.BuildingBlocks.Infrastructure.EventBus;
using AutoHub.BuildingBlocks.Infrastructure.Serialization;
using Dapper;
using Newtonsoft.Json;

namespace AutoHub.Modules.Adverts.Infrastructure.Configuration.EventsBus;

internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T>
        where T : IntegrationEvent
{
    public async Task Handle(T @event)
    {
        using (var scope = AdvertsCompositionRoot.BeginLifetimeScope())
        {
            using (var connection = scope.Resolve<ISqlConnectionFactory>().GetOpenConnection())
            {
                string type = @event.GetType().FullName;
                var data = JsonConvert.SerializeObject(@event, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                });

                var sql = "INSERT INTO `adverts_InboxMessages` (Id, OccurredOn, Type, Data) " +
                          "VALUES (@Id, @OccurredOn, @Type, @Data)";

                await connection.ExecuteScalarAsync(sql, new
                {
                    @event.Id,
                    @event.OccurredOn,
                    type,
                    data
                });
            }
        }
    }
}