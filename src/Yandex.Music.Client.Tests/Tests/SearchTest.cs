using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(7)]
    [TestBeforeAfter]
    public class SearchTest : YandexTest
    {
        #region Поля

        private static string track = "All I Got";
        private static string album = "Black Is the Colour";
        private static string artist = "Arven";
        private static string playlist = "Лучшие песни русского рока";

        #endregion Поля

        [Fact]
        [Order(0)]
        public void Albums_ValidData_True()
        {
            YSearch response = Fixture.Client.Search(album, YSearchType.Album);
            response.Albums.Total.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(1)]
        public void Artist_ValidData_True()
        {
            YSearch response = Fixture.Client.Search(artist, YSearchType.Artist);
            response.Artists.Total.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(2)]
        public void Playlist_ValidData_True()
        {
            YSearch response = Fixture.Client.Search(playlist, YSearchType.Playlist);
            response.Playlists.Total.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(3)]
        public void Track_ValidData_True()
        {
            YSearch response = Fixture.Client.Search(track, YSearchType.Track);
            response.Tracks.Total.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(5)]
        public void Suggest_ValidData_True()
        {
            YSearchSuggest suggest = Fixture.Client.GetSearchSuggestions(artist);
            suggest.Suggestions.Count.Should().BeGreaterThan(0);
        }

        public SearchTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}