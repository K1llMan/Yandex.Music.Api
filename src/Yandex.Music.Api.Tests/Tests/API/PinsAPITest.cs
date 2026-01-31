using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Models.Pins;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(13)]
    [TestBeforeAfter]
    public class PinsAPITest : YandexTest
    {
        [Fact, YandexTrait(TraitGroup.AlbumAPI)]
        [Order(0)]
        public void Pins_ValidData_True()
        {
            YResponse<YPins> pins = Fixture.API.Pins.Get(Fixture.Storage);
            pins.Should().NotBe(null);
        }
        
        public PinsAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}