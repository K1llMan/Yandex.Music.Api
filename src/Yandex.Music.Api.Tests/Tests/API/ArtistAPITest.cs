using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(4)]
    [TestBeforeAfter]
    public class ArtistAPITest : YandexTest
    {
        #region Поля

        // Metallica
        private static string artistId = "3121";

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.ArtistAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Artist = Fixture.API.Artist.Get(Fixture.Storage, artistId);
            Fixture.Artist.Result.Artist.Name.Should().Be("Metallica");
        }

        [Fact, YandexTrait(TraitGroup.ArtistAPI)]
        [Order(1)]
        public void GetList_ValidData_True()
        {
            YResponse<List<YArtist>> artists = Fixture.API.Artist.Get(Fixture.Storage, new[] { "157479", "48814" });
            artists.Result.Count.Should().Be(2);
        }

        public ArtistAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}