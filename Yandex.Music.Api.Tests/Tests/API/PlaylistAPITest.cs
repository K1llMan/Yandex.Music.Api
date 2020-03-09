using System.Linq;
using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Responses;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness")]
    [Order(6)]
    public class PlaylistAPITest : YandexTest
    {
        #region Поля

        // Лучшие песни русского рока
        private static string kinds = "2050";
        private static string title = "Лучшие песни русского рока";

        // Arven - Black Is the Colour - All I Got
        private static string trackId = "14318563";
        private static string albumId = "4256391";

        private static List<YPlaylist> mainPage;
        private static YPlaylist createdPlaylist;

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            YPlaylist response = Fixture.API.PlaylistAPI.Get(Fixture.StorageEncrypted, kinds);
            response.Title.Should().Be(title);
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(1)]
        public void MainPagePersonal_ValidData_True()
        {
            mainPage = Fixture.API.PlaylistAPI.MainPagePersonal(Fixture.StorageEncrypted);
            mainPage.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(2)]
        public void OfTheDay_ValidData_True()
        {
            mainPage.Should().NotBeNull();

            string kind = mainPage.First(p => p.GeneratedPlaylistType == YGeneratedPlaylistType.PlaylistOfTheDay).Kind;
            YPlaylist response = Fixture.API.PlaylistAPI.OfTheDay(Fixture.StorageEncrypted, kind);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(3)]
        public void Premiere_ValidData_True()
        {
            mainPage.Should().NotBeNull();

            string kind = mainPage.First(p => p.GeneratedPlaylistType == YGeneratedPlaylistType.RecentTracks).Kind;
            YPlaylist response = Fixture.API.PlaylistAPI.Premiere(Fixture.StorageEncrypted, kind);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(4)]
        public void DejaVu_ValidData_True()
        {
            mainPage.Should().NotBeNull();

            string kind = mainPage.First(p => p.GeneratedPlaylistType == YGeneratedPlaylistType.NeverHeard).Kind;
            YPlaylist response = Fixture.API.PlaylistAPI.DejaVu(Fixture.StorageEncrypted, kind);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(5)]
        public void Missed_ValidData_True()
        {
            mainPage.Should().NotBeNull();

            string kind = mainPage.First(p => p.GeneratedPlaylistType == YGeneratedPlaylistType.MissedLikes).Kind;
            YPlaylist response = Fixture.API.PlaylistAPI.Missed(Fixture.StorageEncrypted, kind);

            response.Should().NotBeNull();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(6)]
        public void Create_ValidData_True()
        {
            YPlaylistChangeResponse response = Fixture.API.PlaylistAPI.Create(Fixture.StorageEncrypted, "Test Playlist");

            response.Success.Should().BeTrue();
            createdPlaylist = response.Playlist;
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(7)]
        public void InsertTrack_ValidData_True()
        {
            createdPlaylist.Should().NotBe(null);

            YInsertTrackToPlaylistResponse response = Fixture.API.PlaylistAPI.InsertTrack(Fixture.StorageEncrypted, trackId, albumId, createdPlaylist.Kind);

            response.Success.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(8)]
        public void DeleteTrack_ValidData_True()
        {
            createdPlaylist.Should().NotBe(null);

            YDeleteTrackFromPlaylistResponse response = Fixture.API.PlaylistAPI.DeleteTrack(Fixture.StorageEncrypted, 0, 0, 0, createdPlaylist.Kind);

            response.Success.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.PlaylistAPI)]
        [Order(9)]
        public void Remove_ValidData_True()
        {
            createdPlaylist.Should().NotBe(null);

            bool response = Fixture.API.PlaylistAPI.Remove(Fixture.StorageEncrypted, createdPlaylist.Kind);

            response.Should().BeTrue();
        }

        public PlaylistAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}