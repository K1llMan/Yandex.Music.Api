using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Client.Extensions;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(4)]
    [TestBeforeAfter]
    public class ArtistAPITest : YandexTest
    {
        #region Поля

        // Metallica
        private static string artistId = "3121";

        #endregion Поля

        [Fact]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Artist = Fixture.Client.GetArtist(artistId);
            Fixture.Artist.Artist.Name.Should().Be("Metallica");
        }

        [Fact]
        [Order(1)]
        public void GetList_ValidData_True()
        {
            List<YArtist> artists = Fixture.Client.GetArtists(new[] { "157479", "48814" });
            artists.Count.Should().Be(2);
        }

        [Fact]
        [Order(2)]
        public void GetTracks_ValidData_True()
        {
            YTracksPage tracks = Fixture.Artist.Artist.GetTracks(1, 30);
            tracks.Tracks.Count.Should().Be(30);
        }

        [Fact]
        [Order(3)]
        public void GetAllTracks_ValidData_True()
        {
            List<YTrack> tracks = Fixture.Artist.Artist.GetAllTracks();
            tracks.Count.Should().BeGreaterThan(30);
        }

        [Fact]
        [Order(4)]
        public void AddLike_ValidData_True()
        {
            Fixture.Artist.Should().NotBe(null);

            Fixture.Artist.Artist.AddLike().Should().Be("ok");
        }

        [Fact]
        [Order(5)]
        public void RemoveLike_ValidData_True()
        {
            Fixture.Artist.Should().NotBe(null);

            Fixture.Artist.Artist.RemoveLike().Should().Be("ok");
        }

        public ArtistAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}