using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Library;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(6)]
    [TestBeforeAfter]
    public class LibraryTest : YandexTest
    {
        [Fact]
        [Order(0)]
        public void GetLikedTracks_ValidData_True()
        {
            List<YTrack> tracks = Fixture.Client.GetLikedTracks();

            tracks.Count.Should().BePositive();
        }

        [Fact]
        [Order(1)]
        public void GetDislikedTracks_ValidData_True()
        {
            List<YTrack> tracks = Fixture.Client.GetDislikedTracks();

            tracks.Count.Should().BePositive();
        }

        [Fact]
        [Order(2)]
        public void GetLikedAlbums_ValidData_True()
        {
            List<YAlbum> albums = Fixture.Client.GetLikedAlbums();

            albums.Should().NotBeNull();
        }

        public LibraryTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}