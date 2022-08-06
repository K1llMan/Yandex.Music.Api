using System.Collections.Generic;
using System.IO;
using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(2)]
    [TestBeforeAfter]
    public class TrackAPITest : YandexTest
    {
        #region Поля

        private string extractedFileName = "test.mp3";

        // Кино - "Группа крови"
        private string trackId = "106259";

        private static YResponse<List<YTrackDownloadInfo>> downloadInfo;
        private static YStorageDownloadFile downloadFile;

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Track = Fixture.API.Track.Get(Fixture.Storage, trackId).Result.FirstOrDefault();
            Fixture.Track.Title.Should().Be("Группа крови");
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(1)]
        public void GetMetadataForDownload_ValidData_True()
        {
            Fixture.Track.Should().NotBe(null);

            downloadInfo = Fixture.API.Track.GetMetadataForDownload(Fixture.Storage, Fixture.Track.GetKey().ToString());

            downloadInfo.Result.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(2)]
        public void GetDownloadFileInfo_ValidData_True()
        {
            downloadInfo.Result.Count.Should().BePositive();

            downloadFile = Fixture.API.Track.GetDownloadFileInfo(Fixture.Storage, downloadInfo.Result.First(m => m.Codec == "mp3"));

            downloadFile.Path.Should().NotBeNullOrEmpty();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(3)]
        public void GetFileLink_ValidData_True()
        {
            Fixture.Track.Should().NotBe(null);

            string link = Fixture.API.Track.GetFileLink(Fixture.Storage, Fixture.Track);

            link.Should().NotBeNullOrEmpty();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(4)]
        public void ExtractToFile_ValidData_True()
        {
            File.Delete(extractedFileName);

            Fixture.Track.Should().NotBe(null);

            Fixture.API.Track.ExtractToFile(Fixture.Storage, Fixture.Track, extractedFileName);

            File.Exists(extractedFileName).Should().BeTrue();
        }

        public TrackAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}