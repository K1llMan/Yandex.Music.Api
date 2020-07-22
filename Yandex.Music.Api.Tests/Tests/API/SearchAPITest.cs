using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search;
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
            YResponse<YSearch> response = Fixture.API.SearchAPI.Albums(Fixture.Storage, album);
            response.Result.Albums.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(1)]
        public void Artist_ValidData_True()
        {
            YResponse<YSearch> response = Fixture.API.SearchAPI.Artist(Fixture.Storage, artist);
            response.Result.Artists.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(2)]
        public void Playlist_ValidData_True()
        {
            YResponse<YSearch> response = Fixture.API.SearchAPI.Playlist(Fixture.Storage, playlist);
            response.Result.Playlists.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(3)]
        public void Track_ValidData_True()
        {
            YResponse<YSearch> response = Fixture.API.SearchAPI.Track(Fixture.Storage, track);
            response.Result.Tracks.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(4)]
        public void Video_ValidData_True()
        {
            YResponse<YSearch> response = Fixture.API.SearchAPI.Videos(Fixture.Storage, track);
            response.Result.Videos.Total.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.SearchAPI)]
        [Order(5)]
        public void Suggest_ValidData_True()
        {
            YResponse<YSearchSuggest> suggest = Fixture.API.SearchAPI.Suggest(Fixture.Storage, artist);
            suggest.Result.Suggestions.Count.Should().BeGreaterThan(0);
        }

        public SearchAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}