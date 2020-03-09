using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Responses;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness")]
    [Order(5)]
    public class LibraryAPITest : YandexTest
    {
        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            YLibraryPlaylistResponse response = Fixture.API.LibraryAPI.Get(Fixture.StorageEncrypted);
            response.Owner.Login.Should().Be(Fixture.StorageEncrypted.User.Login);
        }

        [Fact, YandexTrait(TraitGroup.LibraryAPI)]
        [Order(1)]
        public void GetHistory_ValidData_True()
        {
            YLibraryHistoryResponse response = Fixture.API.LibraryAPI.GetHistory(Fixture.StorageEncrypted);
            response.Owner.Login.Should().Be(Fixture.StorageEncrypted.User.Login);
        }

        public LibraryAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}