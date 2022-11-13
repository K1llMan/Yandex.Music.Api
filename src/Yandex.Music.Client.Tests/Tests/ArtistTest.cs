using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Artist;
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
        public void AddLike_ValidData_True()
        {
            Fixture.Artist.Should().NotBe(null);

            Fixture.Artist.Artist.AddLike().Should().Be("ok");
        }

        [Fact]
        [Order(3)]
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