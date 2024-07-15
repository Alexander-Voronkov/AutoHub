using System.Reflection;
using AutoHub.Modules.Adverts.Application.Contracts;
using AutoHub.Modules.Adverts.Domain.Adverts;
using AutoHub.Modules.Adverts.Infrastructure;
using AutoHub.Tests.ArchTests.SeedWork;
using MediatR;
using NetArchTest.Rules;
using NUnit.Framework;

namespace CompanyName.MyMeetings.ArchTests.Modules;

[TestFixture]
public class ModuleTests : TestBase
{
    [Test]
    public void AdvertsModule_DoesNotHave_Dependency_On_Other_Modules()
    {
        List<string> otherModules = [
            ArticlesNamespace,
            EmailsNamespace,
            FilesNamespace,
            MessagesNamespace,
            NotificationsNamespace,
            UsersNamespace,
            VehiclesNamespace
        ];

        List<Assembly> advertsAssemblies =
        [
            typeof(IAdvertsModule).Assembly,
            typeof(Advert).Assembly,
            typeof(AdvertsContext).Assembly
        ];

        var result = Types.InAssemblies(advertsAssemblies)
            .That()
                .DoNotImplementInterface(typeof(INotificationHandler<>))
                .And().DoNotHaveNameEndingWith("IntegrationEventHandler")
                .And().DoNotHaveName("EventsBusStartup")
            .Should()
            .NotHaveDependencyOnAny(otherModules.ToArray())
            .GetResult();

        AssertArchTestResult(result);
    }
}
