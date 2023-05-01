using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(1)]
    [TestBeforeAfter]
    public class UserTest : YandexTest
    {
        public UserTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        [Order(0)]
        public void Authorize_ValidData_True()
        {
            if (!string.IsNullOrEmpty(Fixture.AppSettings.Token))
                Fixture.Client.Authorize(Fixture.AppSettings.Token);

            Fixture.Client.IsAuthorized.Should().BeTrue();
        }

        [Fact]
        [Order(1)]
        public void GetUserAuth_ValidData_True()
        {
            Fixture.Client.Account.Should().NotBeNull();
        }
    }
}