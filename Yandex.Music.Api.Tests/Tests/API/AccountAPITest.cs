using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness")]
    [Order(3)]
    public class AccountAPITest : YandexTest
    {
        public AccountAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        [YandexTrait(TraitGroup.AccountAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            var response = Fixture.API.AccountsApi.Get(Fixture.StorageEncrypted);
            response.Accounts.Should().NotBeNull();

            var account = response.Accounts.FirstOrDefault();
            account.Should().NotBe(null);

            account?.Login.Should().Be(Fixture.StorageEncrypted.User.Login);
        }
    }
}