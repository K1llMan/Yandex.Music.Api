using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(5)]
    [TestBeforeAfter]
    public class PlaylistAPITest : YandexTest
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

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Playlist = Fixture.API.Playlist.Get(Fixture.Storage, userId, kinds).Result;
            Fixture.Playlist.Title.Should().Be(title);
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(1)]
        public void PersonalPlaylists_ValidData_True()
        {
            List<YResponse<YPlaylist>> mainPage = Fixture.API.Playlist.GetPersonalPlaylists(Fixture.Storage);

            mainPage.Should().NotBeNull();
            mainPage.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(2)]
        public void OfTheDay_ValidData_True()
        {
            YResponse<YPlaylist> response = Fixture.API.Playlist.OfTheDay(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(3)]
        public void Premiere_ValidData_True()
        {
            YResponse<YPlaylist> response = Fixture.API.Playlist.Premiere(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(4)]
        public void DejaVu_ValidData_True()
        {
            YResponse<YPlaylist> response = Fixture.API.Playlist.DejaVu(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(5)]
        public void Missed_ValidData_True()
        {
            YResponse<YPlaylist> response = Fixture.API.Playlist.Missed(Fixture.Storage);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(9)]
        public void Create_ValidData_True()
        {
            Fixture.CreatedPlaylist = Fixture.API.Playlist.Create(Fixture.Storage, "Test Playlist").Result;

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(10)]
        public void InsertTrack_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();
            Fixture.Track.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.API.Playlist.InsertTracks(Fixture.Storage, Fixture.CreatedPlaylist, new [] { Fixture.Track }).Result;

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(11)]
        public void DeleteTrack_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();
            Fixture.Track.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.API.Playlist.DeleteTracks(Fixture.Storage, Fixture.CreatedPlaylist, new[] { Fixture.Track }).Result;

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(12)]
        public void Rename_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();

            Fixture.CreatedPlaylist = Fixture.API.Playlist.Rename(Fixture.Storage, Fixture.CreatedPlaylist, "New Playlist").Result;

            Fixture.CreatedPlaylist.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(13)]
        public void Remove_ValidData_True()
        {
            Fixture.CreatedPlaylist.Should().NotBeNull();

            bool response = Fixture.API.Playlist.Delete(Fixture.Storage, Fixture.CreatedPlaylist);

            response.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(14)]
        public void GetList_ValidData_True()
        {
            YResponse<List<YPlaylist>> playlists = Fixture.API.Playlist.Get(Fixture.Storage, new [] { ( "103372440", "2007"), ("103372440", "1878") });
            playlists.Result.Count.Should().Be(2);
        }

        public PlaylistAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}