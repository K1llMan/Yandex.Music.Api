using FluentAssertions;
using Lofty.Modules.BddTests.Traits;
using Xunit;
using Xunit.Abstractions;

namespace Lofty.Modules.BddTests.Tests.Yandex
{
  [Collection("Lofi Test Harness")]
  public class AuthorizeTest : LofiTest
  {
    public AuthorizeTest(LofiTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
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
  }
}