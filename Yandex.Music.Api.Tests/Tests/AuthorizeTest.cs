using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests
{
  [Collection("Yandex Test Harness")]
  public class AuthorizeTest : YandexTest
  {
    public AuthorizeTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact, YandexTrait(TraitGroup.Authorize)]
    public void Authorize_ValidData_GenerateTrue()
    {
      var isAuthorized = Api.Authorize("login", "123");
      
      isAuthorized.Should().BeTrue();
    }
    
    [Fact, YandexTrait(TraitGroup.Authorize)]
    public void Authorize_InvalidData_GenerateFalse()
    {
      var isAuthorized = Api.Authorize("login", "123");
      
      isAuthorized.Should().BeFalse();
    }
    
    [Fact, YandexTrait(TraitGroup.Authorize)]
    public void Authorize_ValidData_GenerateTru()
    {
      var isAuthorized = Api.Authorize("Winster332", "Stas32MP3tanki");
      
      isAuthorized.Should().BeTrue();
      Api.CreatePlaylist("Test-1");
//      Api.GetAccounts();
    }
  }
}