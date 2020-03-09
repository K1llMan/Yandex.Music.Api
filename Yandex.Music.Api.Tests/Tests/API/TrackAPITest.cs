using System.IO;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Responses;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness")]
    [Order(2)]
    public class TrackAPITest : YandexTest
    {
        #region Поля

        private string extractedFileName = "test.mp3";

        // Кино - "Группа крови"
        private string trackId = "106259";

        private static YTrack track;
        private static YTrackDownloadInfoResponse downloadInfo;
        private static YStorageDownloadFileResponse downloadFile;

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(0)]
        public void Get_ValidData_True()
        {
            track = Fixture.API.TrackAPI.Get(Fixture.StorageEncrypted, trackId);
            track.Title.Should().Be("Группа крови");
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(1)]
        public void GetMetadataForDownload_ValidData_True()
        {
            track.Should().NotBe(null);

            downloadInfo = Fixture.API.TrackAPI.GetMetadataForDownload(Fixture.StorageEncrypted, track.GetKey());

            downloadInfo.Src.Should().NotBeNullOrEmpty();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(2)]
        public void GetDownloadFileInfo_ValidData_True()
        {
            downloadInfo.Should().NotBe(null);

            downloadFile = Fixture.API.TrackAPI.GetDownloadFileInfo(Fixture.StorageEncrypted, downloadInfo);

            downloadFile.Path.Should().NotBeNullOrEmpty();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(3)]
        public void GetFileLink_ValidData_True()
        {
            track.Should().NotBe(null);

            string link = Fixture.API.TrackAPI.GetFileLink(Fixture.StorageEncrypted, track.GetKey());

            link.Should().NotBeNullOrEmpty();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(4)]
        public void ExtractToFile_ValidData_True()
        {
            File.Delete(extractedFileName);

            track.Should().NotBe(null);

            Fixture.API.TrackAPI.ExtractToFile(Fixture.StorageEncrypted, track.GetKey(), extractedFileName);

            File.Exists(extractedFileName).Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(5)]
        public void ChangeLikedTrue_ValidData_True()
        {

            track.Should().NotBe(null);

            YSetLikedTrackResponse response = Fixture.API.TrackAPI.SetLiked(Fixture.StorageEncrypted, track.GetKey(), true);

            response.Success.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(6)]
        public void ChangeLikedFalse_ValidData_True()
        {

            track.Should().NotBe(null);

            YSetLikedTrackResponse response = Fixture.API.TrackAPI.SetLiked(Fixture.StorageEncrypted, track.GetKey(), false);

            response.Success.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(7)]
        public void SetNotRecommend_ValidData_True()
        {

            track.Should().NotBe(null);

            YSetNotRecommendTrackResponse response = Fixture.API.TrackAPI.SetNotRecommend(Fixture.StorageEncrypted, track.GetKey(), true);

            response.Success.Should().BeTrue();
        }

        [Fact, YandexTrait(TraitGroup.TrackAPI)]
        [Order(8)]
        public void ChangeLiked_ValidData_True()
        {

            track.Should().NotBe(null);

            YSetNotRecommendTrackResponse response = Fixture.API.TrackAPI.SetNotRecommend(Fixture.StorageEncrypted, track.GetKey(), false);

            response.Success.Should().BeTrue();
        }

        public TrackAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}