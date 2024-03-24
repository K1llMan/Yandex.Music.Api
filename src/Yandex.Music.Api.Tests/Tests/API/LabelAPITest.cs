using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Label;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(12)]
    [TestBeforeAfter]
    public class LabelAPITest : YandexTest
    {
        #region Поля

        private static YLabel sampleLabel = new YLabel
        {
            Id = "841322"
        };

        #endregion Поля

        public LabelAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact, YandexTrait(TraitGroup.LabelAPI)]
        [Order(0)]
        public async Task GetAlbumsFromLabel_ValidData_True()
        {
            YResponse<YLabelAlbums> labelAlbums =
                await Fixture.API.Label.GetAlbumsByLabelAsync(Fixture.Storage, sampleLabel, 0);
            labelAlbums.Result.Should().NotBeNull();
            if (labelAlbums.Result.Pager.Total > labelAlbums.Result.Pager.PerPage * (labelAlbums.Result.Pager.Page + 1))
            {
                labelAlbums = await Fixture.API.Label
                    .GetAlbumsByLabelAsync(Fixture.Storage, sampleLabel, labelAlbums.Result.Pager.Page++);
                labelAlbums.Result.Should().NotBeNull();
            }

            List<YLabel> albumLabels = labelAlbums.Result.Albums.First().Labels;
            albumLabels.Should().Contain(x => x.Id == sampleLabel.Id);
        }

        [Fact, YandexTrait(TraitGroup.LabelAPI)]
        [Order(1)]
        public async Task GetArtistsFromLabel_ValidData_True()
        {
            YResponse<YLabelArtists> labelAlbums =
                await Fixture.API.Label.GetArtistsByLabelAsync(Fixture.Storage, sampleLabel, 0);
            labelAlbums.Result.Should().NotBeNull();
            if (labelAlbums.Result.Pager.Total > labelAlbums.Result.Pager.PerPage * (labelAlbums.Result.Pager.Page + 1))
            {
                labelAlbums = await Fixture.API.Label
                    .GetArtistsByLabelAsync(Fixture.Storage, sampleLabel, labelAlbums.Result.Pager.Page++);
                labelAlbums.Result.Should().NotBeNull();
            }
        }
    }
}