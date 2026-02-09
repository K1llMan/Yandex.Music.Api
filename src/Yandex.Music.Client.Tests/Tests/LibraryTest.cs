using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Landing.Entity.Entities.Context;
using Yandex.Music.Api.Models.Library;
using Yandex.Music.Api.Models.Playlist;
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

        [Fact]
        [Order(3)]
        public void GetLikedArtists_ValidData_True()
        {
            List<YArtist> artists = Fixture.Client.GetLikedArtists();

            artists.Should().NotBeNull();
        }

        [Fact]
        [Order(4)]
        public void GetDislikedArtists_ValidData_True()
        {
            List<YArtist> artists = Fixture.Client.GetDislikedArtists();

            artists.Should().NotBeNull();
        }

        [Fact]
        [Order(5)]
        public void GetLlikedPlaylists_ValidData_True()
        {
            List<YPlaylist> playlists = Fixture.Client.GetLikedPlaylists();

            playlists.Should().NotBeNull();
        }

        [Fact]
        [Order(6)]
        public void GetRecentlyListened_ValidData_True()
        {
            IEnumerable<YPlayContextType> types = new[]
            {
                YPlayContextType.Album, YPlayContextType.Artist, YPlayContextType.Playlist
            };
            int trackCount = 2;
            int contextCount = 5;

            List<YRecentlyListened> recentlyListened = Fixture.Client.GetRecentlyListened(types, trackCount, contextCount);

            recentlyListened.Should().NotBeNullOrEmpty();
            recentlyListened.First().Tracks.Should().NotBeNullOrEmpty();
            recentlyListened.First().ContextItem.Should().NotBeNull();
        }

        public LibraryTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}
