using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(3)]
    [TestBeforeAfter]
    public class AlbumAPITest : YandexTest
    {
        #region Поля

        // DragonForce - The Power Within
        private static string albumId = "621147";

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.AlbumAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Album = Fixture.API.Album.Get(Fixture.Storage, albumId);
            Fixture.Album.Result.Title.Should().Be("The Power Within");
        }

        [Fact, YandexTrait(TraitGroup.AlbumAPI)]
        [Order(1)]
        public void GetAlbums_ValidData_True()
        {
            YResponse<List<YAlbum>> albums = Fixture.API.Album.Get(Fixture.Storage, new[] { "5778040", "3350968" });
            albums.Result.Count.Should().BePositive();
        }

        public AlbumAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}