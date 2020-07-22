using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Library;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(6)]
    [TestBeforeAfter]
    public class LibraryAPITest : YandexTest
    {
        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(0)]
        public void AddTrackLike_ValidData_True()
        {
            Fixture.Track.Should().NotBeNull();

            int revision = Fixture.API.LibraryAPI.AddTrackLike(Fixture.Storage, Fixture.Track).Result.Revision;

            revision.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(1)]
        public void AddAlbumLike_ValidData_True()
        {
            Fixture.Album.Should().NotBeNull();

            bool added = Fixture.API.LibraryAPI.AddAlbumLike(Fixture.Storage, new YAlbum {
                Id = Fixture.Album.Result.Id
            }).Result == "ok";

            added.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(2)]
        public void AddArtistLike_ValidData_True()
        {
            Fixture.Artist.Should().NotBeNull();

            bool added = Fixture.API.LibraryAPI.AddArtistLike(Fixture.Storage, new YArtist {
                Id = Fixture.Artist.Result.Artist.Id
            }).Result == "ok";

            added.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(3)]
        public void AddPlaylistLike_ValidData_True()
        {
            Fixture.Playlist.Should().NotBeNull();

            bool added = Fixture.API.LibraryAPI.AddPlaylistLike(Fixture.Storage, Fixture.Playlist).Result == "ok";

            added.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(4)]
        public void GetLikedTracks_ValidData_True()
        {
            YLibraryTracks tracks = Fixture.API.LibraryAPI.GetLikedTracks(Fixture.Storage).Result;

            tracks.Library.Tracks.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(5)]
        public void GetLikedAlbums_ValidData_True()
        {
            List<YLibraryAlbum> albums = Fixture.API.LibraryAPI.GetLikedAlbums(Fixture.Storage).Result;

            albums.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(6)]
        public void GetLikedArtists_ValidData_True()
        {
            List<YArtist> artists = Fixture.API.LibraryAPI.GetLikedArtists(Fixture.Storage).Result;

            artists.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(7)]
        public void GetLikedPlaylists_ValidData_True()
        {
            List<YLibraryPlaylists> playlists = Fixture.API.LibraryAPI.GetLikedPlaylists(Fixture.Storage).Result;

            playlists.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(8)]
        public void RemoveTrackLike_ValidData_True()
        {
            Fixture.Track.Should().NotBeNull();

            YRevision revision = Fixture.API.LibraryAPI.RemoveTrackLike(Fixture.Storage, Fixture.Track).Result;

            revision.Revision.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(9)]
        public void RemoveAlbumLike_ValidData_True()
        {
            Fixture.Album.Should().NotBeNull();

            bool removed = Fixture.API.LibraryAPI.RemoveAlbumLike(Fixture.Storage, new YAlbum {
                Id = Fixture.Album.Result.Id
            }).Result == "ok";

            removed.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(10)]
        public void RemoveArtistLike_ValidData_True()
        {
            Fixture.Artist.Should().NotBeNull();

            bool removed = Fixture.API.LibraryAPI.RemoveArtistLike(Fixture.Storage, new YArtist {
                Id = Fixture.Artist.Result.Artist.Id
            }).Result == "ok";

            removed.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(11)]
        public void RemovePlaylistLike_ValidData_True()
        {
            Fixture.Playlist.Should().NotBeNull();

            bool removed = Fixture.API.LibraryAPI.RemovePlaylistLike(Fixture.Storage, Fixture.Playlist).Result == "ok";

            removed.Should().BeTrue();
        }


        public LibraryAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}