using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Client.Extensions;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(3)]
    [TestBeforeAfter]
    public class AlbumAPITest : YandexTest
    {
        #region Поля

        // DragonForce - The Power Within
        private static string albumId = "621147";

        #endregion Поля

        [Fact]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Album = Fixture.Client.GetAlbum(albumId);
            Fixture.Album.Title.Should().Be("The Power Within");
        }

        [Fact]
        [Order(1)]
        public void GetAlbums_ValidData_True()
        {
            List<YAlbum> albums = Fixture.Client.GetAlbums(new[] { "5778040", "3350968" });
            albums.Count.Should().BePositive();
        }

        [Fact]
        [Order(2)]
        public void AddLike_ValidData_True()
        {
            Fixture.Album.Should().NotBe(null);

            Fixture.Album.AddLike().Should().Be("ok");
        }

        [Fact]
        [Order(3)]
        public void RemoveLike_ValidData_True()
        {
            Fixture.Album.Should().NotBe(null);

            Fixture.Album.RemoveLike().Should().Be("ok");
        }

        public AlbumAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}