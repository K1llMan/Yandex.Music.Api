using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness")]
    [Order(1)]
    public class UserAPITest : YandexTest
    {
        public UserAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(0)]
        public void Authorize_ValidData_True()
        {
            Fixture.API.UserAPI.Authorize(Fixture.StorageEncrypted);
            Fixture.StorageEncrypted.IsAuthorized.Should().BeTrue();
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(1)]
        public void GetUserAuth_ValidData_True()
        {
            var response = Fixture.API.UserAPI.GetUserAuth(Fixture.StorageEncrypted);
            response.Login.Should().Be(Fixture.StorageEncrypted.User.Login);
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(2)]
        public void GetUserAuthDetails_ValidData_True()
        {
            var response = Fixture.API.UserAPI.GetUserAuthDetails(Fixture.StorageEncrypted);
            response.User.Login.Should().Be(Fixture.StorageEncrypted.User.Login);
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(3)]
        public void GetYandexCookie_ValidData_True()
        {
            var response = Fixture.API.UserAPI.GetYandexCookie(Fixture.StorageEncrypted);
            response.Should().NotBe(null);
        }
    }
}