using AutoHub.Tests.ArchTests.SeedWork;
using NetArchTest.Rules;
using NUnit.Framework;

[TestFixture]
public class ApiTests : TestBase
{
    [Test]
    public void AdvertsApi_DoesNotHaveDependency_ToOtherModules()
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

        var result = Types.InAssembly(ApiAssembly)
            .That()
            .ResideInNamespace("AutoHub.API.Modules.Adverts")
            .Should()
            .NotHaveDependencyOnAny(otherModules.ToArray())
            .GetResult();

        AssertArchTestResult(result);
    }
}