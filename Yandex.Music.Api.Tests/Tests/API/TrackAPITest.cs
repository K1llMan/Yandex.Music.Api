using System.Collections.Generic;
using System.IO;
using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Responses;
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

        private static List<YTrackDownloadInfoResponse> downloadInfo;
        private static YStorageDownloadFileResponse downloadFile;

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Track = Fixture.API.TrackAPI.Get(Fixture.Storage, trackId);
            Fixture.Track.Title.Should().Be("Группа крови");
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(1)]
        public void GetMetadataForDownload_ValidData_True()
        {
            Fixture.Track.Should().NotBe(null);

            downloadInfo = Fixture.API.TrackAPI.GetMetadataForDownload(Fixture.Storage, Fixture.Track.GetKey().ToString());

            downloadInfo.Count.Should().BePositive();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(2)]
        public void GetDownloadFileInfo_ValidData_True()
        {
            downloadInfo.Count.Should().BePositive();

            downloadFile = Fixture.API.TrackAPI.GetDownloadFileInfo(Fixture.Storage, downloadInfo.First(m => m.Codec == "mp3"));

            downloadFile.Path.Should().NotBeNullOrEmpty();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(3)]
        public void GetFileLink_ValidData_True()
        {
            Fixture.Track.Should().NotBe(null);

            string link = Fixture.API.TrackAPI.GetFileLink(Fixture.Storage, Fixture.Track);

            link.Should().NotBeNullOrEmpty();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(4)]
        public void ExtractToFile_ValidData_True()
        {
            File.Delete(extractedFileName);

            Fixture.Track.Should().NotBe(null);

            Fixture.API.TrackAPI.ExtractToFile(Fixture.Storage, Fixture.Track, extractedFileName);

            File.Exists(extractedFileName).Should().BeTrue();
        }

        public TrackAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}