using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Common;
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
        public void AuthorizeTypes_ValidData_True()
        {
            YAuthTypes types = Fixture.API.User.CreateAuthSession(Fixture.Storage, Fixture.AppSettings.Login);

            types.Should().NotBeNull();
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(1)]
        public void Authorize_ValidData_True()
        {
            if (!string.IsNullOrEmpty(Fixture.AppSettings.Token))
                Fixture.API.User.Authorize(Fixture.Storage, Fixture.AppSettings.Token);

            Fixture.Storage.IsAuthorized.Should().BeTrue();
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(2)]
        public void GetUserAuth_ValidData_True()
        {
            YResponse<YAccountResult> response = Fixture.API.User.GetUserAuth(Fixture.Storage);
            response.Result.Account.Login.Should().Be(Fixture.Storage.User.Login);
        }

        [Fact]
        [YandexTrait(TraitGroup.UserAPI)]
        [Order(3)]
        public void GetLoginInfo_ValidData_True()
        {
            YLoginInfo response = Fixture.API.User.GetLoginInfo(Fixture.Storage);
            response.Login.Should().Be(Fixture.Storage.User.Login);
        }
    }
}