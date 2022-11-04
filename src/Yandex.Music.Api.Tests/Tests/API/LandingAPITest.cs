using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(3)]
    [TestBeforeAfter]
    public class LandingAPITest : YandexTest
    {
        [Fact, YandexTrait(TraitGroup.AlbumAPI)]
        [Order(0)]
        public void GetFeed_ValidData_True()
        {
            YResponse<YFeed> feed = Fixture.API.Landing.GetFeed(Fixture.Storage);
            feed.Should().NotBe(null);
        }

        public LandingAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}