using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Yandex.Music.Client.Tests.Tests.Authorize
{
    public class AuthorizeTest : YandexTests
    {
        [Fact]
        public async Task AuthorizeTest_Authorize_ReturnSuccess()
        {
            var isAuthorized = await Client.AuthorizeAsync(AppSettings.Login, AppSettings.Password);

            isAuthorized.Should().BeTrue();
            Client.AuthUser.Should().NotBeNull();
        }
        
        [Fact]
        public async Task AuthorizeTest_Authorize_ReturnFail()
        {
            var isAuthorized = await Client.AuthorizeAsync("test", "test");

            isAuthorized.Should().BeFalse();
            Client.AuthUser.Should().BeNull();
        }
    }
}