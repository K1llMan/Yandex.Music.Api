using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

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
            Fixture.Album = Fixture.API.AlbumAPI.Get(Fixture.Storage, albumId);
            Fixture.Album.Title.Should().Be("The Power Within");
        }

        public AlbumAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}