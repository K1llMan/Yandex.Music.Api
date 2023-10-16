using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Client.Extensions;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(5)]
    [TestBeforeAfter]
    public class PlaylistTest : YandexTest
    {
        #region Поля

        // Яндекс
        private static string userId = "139954184";

        // Лучшие песни русского рока
        private static string kinds = "2050";
        private static string title = "Лучшие песни русского рока";

        // Arven - Black Is the Colour - All I Got
        private static string trackId = "14318563";
        private static string albumId = "4256391";

        #endregion Поля

        [Fact]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Playlist = Fixture.Client.GetPlaylist(userId, kinds);
            Fixture.Playlist.Title.Should().Be(title);
        }

        [Fact]
        [Order(1)]
        public void GetList_ValidData_True()
        {
            List<YPlaylist> playlists = Fixture.Client.GetPlaylists(new[] { ("103372440", "2007"), ("103372440", "1878") });
            playlists.Count.Should().Be(2);
        }

        [Fact]
        [Order(2)]
        public void GetPersonalPlaylists_ValidData_True()
        {
            List<YPlaylist> response = Fixture.Client.GetPersonalPlaylists();

            response.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(3)]
        public void Favorites_ValidData_True()
        {
            List<YPlaylist> response = Fixture.Client.GetFavorites();

            response.Should().NotBeNull();
        }

        [Fact]
        [Order(4)]
        public void OfTheDay_ValidData_True()
        {
            YPlaylist response = Fixture.Client.GetOfTheDay();

            response.Should().NotBeNull();
        }

        [Fact]
        [Order(5)]
        public void Premiere_ValidData_True()
        {
            YPlaylist response = Fixture.Client.GetPremiere();

            response.Should().NotBeNull();
        }

        [Fact]
        [Order(6)]
        public void DejaVu_ValidData_True()
        {
            YPlaylist response = Fixture.Client.GetDejaVu();

            response.Should().NotBeNull();
        }

        [Fact]
        [Order(7)]
        public void Missed_ValidData_True()
        {
            YPlaylist response = Fixture.Client.GetMissed();

            response.Should().NotBeNull();
        }

        [Fact]
        [Order(11)]
        public void Create_ValidData_True()
        {
            Fixture.CreatedPlaylist = Fixture.Client.CreatePlaylist("Test Playlist");

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact]
        [Order(12)]
        public void InsertTrack_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();
            Fixture.Track.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.CreatedPlaylist.InsertTracks(Fixture.Track);

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact]
        [Order(13)]
        public void DeleteTrack_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();
            Fixture.Track.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.CreatedPlaylist.RemoveTracks(Fixture.Track);

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact]
        [Order(14)]
        public void Rename_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.CreatedPlaylist.Rename("New Playlist");

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact]
        [Order(15)]
        public void Remove_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();

            bool response = Fixture.CreatedPlaylist.Delete();

            response.Should().BeTrue();
        }

        public PlaylistTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}