namespace AutoHub.Tests.ArchTests.SeedWork;

using System.Reflection;
using AutoHub.API;
using NetArchTest.Rules;
using NUnit.Framework;

public abstract class TestBase
{
    protected static Assembly ApiAssembly => typeof(Startup).Assembly;

    public const string AdvertsNamespace = "AutoHub.Modules.Adverts";

    public const string ArticlesNamespace = "AutoHub.Modules.Articles";

    public const string EmailsNamespace = "AutoHub.Modules.Emails";

    public const string FilesNamespace = "AutoHub.Modules.Files";

    public const string MessagesNamespace = "AutoHub.Modules.Messages";

    public const string NotificationsNamespace = "AutoHub.Modules.Notifications";

    public const string UsersNamespace = "AutoHub.Modules.Users";

    public const string VehiclesNamespace = "AutoHub.Modules.Vehicles";

    protected static void AssertAreImmutable(IEnumerable<Type> types)
    {
        List<Type> failingTypes = [];
        foreach (var type in types)
        {
            if (type.GetFields().Any(x => !x.IsInitOnly) || type.GetProperties().Any(x => x.CanWrite))
            {
                failingTypes.Add(type);
                break;
            }
        }

        AssertFailingTypes(failingTypes);
    }

    protected static void AssertFailingTypes(IEnumerable<Type> types)
    {
        Assert.That(types, Is.Null.Or.Empty);
    }

    protected static void AssertArchTestResult(TestResult result)
    {
        AssertFailingTypes(result.FailingTypes);
    }
}