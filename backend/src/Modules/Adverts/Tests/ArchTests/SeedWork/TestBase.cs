using System.Reflection;
using AutoHub.Modules.Adverts.Application.Contracts;
using AutoHub.Modules.Adverts.Domain.Adverts;
using AutoHub.Modules.Adverts.Infrastructure;
using NetArchTest.Rules;
using NUnit.Framework;

namespace AutoHub.Modules.Adverts.ArchTests.SeedWork
{
    public abstract class TestBase
    {
        protected static Assembly ApplicationAssembly => typeof(CommandBase).Assembly;

        protected static Assembly DomainAssembly => typeof(Advert).Assembly;

        protected static Assembly InfrastructureAssembly => typeof(AdvertsContext).Assembly;

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
}