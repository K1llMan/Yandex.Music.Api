using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Responses;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(7)]
    [TestBeforeAfter]
    public class SearchAPITest : YandexTest
    {
        #region Поля

        private static string track = "All I Got";
        private static string album = "Black Is the Colour";
        private static string artist = "Arven";
        private static string playlist = "Лучшие песни русского рока";

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(0)]
        public void Albums_ValidData_True()
        {
            YSearchResponse response = Fixture.API.SearchAPI.Albums(Fixture.Storage, album);
            response.Albums.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(1)]
        public void Artist_ValidData_True()
        {
            YSearchResponse response = Fixture.API.SearchAPI.Artist(Fixture.Storage, artist);
            response.Artists.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(2)]
        public void Playlist_ValidData_True()
        {
            YSearchResponse response = Fixture.API.SearchAPI.Playlist(Fixture.Storage, playlist);
            response.Playlists.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(3)]
        public void Track_ValidData_True()
        {
            YSearchResponse response = Fixture.API.SearchAPI.Track(Fixture.Storage, track);
            response.Tracks.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(4)]
        public void Users_ValidData_True()
        {
            YSearchResponse response = Fixture.API.SearchAPI.Users(Fixture.Storage, Fixture.Storage.User.FirstName);
            response.Users.Total.Should().BeGreaterThan(0);
        }

        public SearchAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}