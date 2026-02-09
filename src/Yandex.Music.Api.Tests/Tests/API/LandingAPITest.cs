using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(10)]
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

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(1)]
        public void Landing_ValidData_True()
        {
            YLanding landing = Fixture.API.Landing.Get(Fixture.Storage,
                YLandingBlockType.Chart,
                YLandingBlockType.Mixes,
                YLandingBlockType.PersonalPlaylists,
                YLandingBlockType.PlayContexts,
                YLandingBlockType.Playlists,
                YLandingBlockType.Podcasts,
                YLandingBlockType.Promotions,
                YLandingBlockType.NewReleases,
                YLandingBlockType.NewPlaylists
            ).Result;

            landing.Should().NotBeNull();
            landing.Blocks.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.AlbumAPI)]
        [Order(2)]
        public void GetChildrenLanding_ValidData_True()
        {
            YResponse<YChildrenLanding> landing = Fixture.API.Landing.GetChildrenLanding(Fixture.Storage);
            landing.Should().NotBeNull();
            landing.Result.Blocks.Should().NotBeNullOrEmpty();
            landing.Result.Blocks.All(x => x.Entities?.Count > 0).Should().BeTrue();
        }

        public LandingAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}
