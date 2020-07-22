using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(1)]
    [TestBeforeAfter]
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
            if (!string.IsNullOrEmpty(Fixture.AppSettings.Token))
                Fixture.API.UserAPI.Authorize(Fixture.Storage, Fixture.AppSettings.Token);
            else
                Fixture.API.UserAPI.Authorize(Fixture.Storage, Fixture.AppSettings.Login, Fixture.AppSettings.Password);

            Fixture.Storage.IsAuthorized.Should().BeTrue();
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(1)]
        public void GetUserAuth_ValidData_True()
        {
            var response = Fixture.API.UserAPI.GetUserAuth(Fixture.Storage);
            response.Result.Account.Login.Should().Be(Fixture.Storage.User.Login);
        }

        /*
        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(2)]
        public void GetUserAuthDetails_ValidData_True()
        {
            var response = Fixture.API.UserAPI.GetUserAuthDetails(Fixture.Storage);
            response.User.Login.Should().Be(Fixture.Storage.User.Login);
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(3)]
        public void GetYandexCookie_ValidData_True()
        {
            var response = Fixture.API.UserAPI.GetYandexCookie(Fixture.Storage);
            response.Should().NotBe(null);
        }
        */
    }
}