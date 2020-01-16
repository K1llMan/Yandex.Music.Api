using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.Authorize
{
    [Collection("Yandex Test Harness")]
    public class LoginTest : YandexTest
    {
        public LoginTest(YandexTestHarness fixture, ITestOutputHelper output = null) : base(fixture, output)
        {
        }

        [Fact, YandexTrait(TraitGroup.Authorize)]
        public void Authorize_ValidData_GenerateTrue()
        {
            var isAuthorized = Api.Authorize(AppSettings.Login, AppSettings.Password);

            isAuthorized.IsAuthorized.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.Authorize)]
        public void Authorize_InvalidData_GenerateFalse()
        {
            var isAuthorized = Api.Authorize("invalid-login", "invalid-password");

            isAuthorized.IsAuthorized.Should().BeFalse();
        }
    }
}