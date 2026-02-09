using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(12)]
    [TestBeforeAfter]
    public class LabelTest : YandexTest
    {
        private YLabel sampleLabel = new()
        {
            Id = "841322"
        };

        public LabelTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        [Order(0)]
        public void GetLabelAlbums_ValidData_True()
        {
            List<YAlbum> albumsByLabel = Fixture.Client.GetAlbumsByLabel(sampleLabel);
            albumsByLabel.Should().NotBeNullOrEmpty();

            List<YLabel> labels = albumsByLabel.First().Labels;
            labels.Should().Contain(label => label.Id == sampleLabel.Id);
        }

        [Fact]
        [Order(1)]
        public void GetLabelArtists_ValidData_True()
        {
            List<YArtist> artistsByLabel = Fixture.Client.GetArtistsByLabel(sampleLabel);
            artistsByLabel.Should().NotBeNullOrEmpty();
        }
    }
}
