using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(4)]
    [TestBeforeAfter]
    public class ArtistAPITest : YandexTest
    {
        #region Поля

        // Metallica
        private static string artistId = "3121";

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.ArtistAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Artist = Fixture.API.ArtistAPI.Get(Fixture.Storage, artistId);
            Fixture.Artist.Artist.Name.Should().Be("Metallica");
        }

        public ArtistAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}