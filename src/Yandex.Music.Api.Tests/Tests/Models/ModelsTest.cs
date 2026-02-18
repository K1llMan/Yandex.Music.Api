using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness")]
    [TestBeforeAfter]
    public class ModelsTest : YandexTest
    {
        public ModelsTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        [YandexTrait(TraitGroup.Models)]
        public void YTrackAlbumPair_ValidData_True()
        {
            YTrackAlbumPair pair = new()
            {
                Id = "1"
            };

            pair.ToString().Should().Be("1");

            pair.AlbumId = "1";
            pair.ToString().Should().Be("1:1");
        }
    }
}
