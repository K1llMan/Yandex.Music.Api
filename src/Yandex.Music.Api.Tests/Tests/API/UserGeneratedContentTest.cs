using System;
using System.IO;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Ugc;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(11)]
    [TestBeforeAfter]
    public class YUserGeneratedContentTest : YandexTest
    {
        private const string sampleFilePath = "Static/sample-3s.mp3";
        private const string successUploadResult = "CREATED";

        public YUserGeneratedContentTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        [Order(0)]
        public void UploadTrackStreamToPlaylist_ValidData_True()
        {
            YPlaylist playlist = Fixture.API.Playlist.Create(Fixture.Storage, $"UploadTestPlaylist-{DateTime.UtcNow:s}")
                .Result;

            YUgcUpload upload = Fixture.API.UserGeneratedContent.GetUgcUploadLink(Fixture.Storage, playlist, Path.GetFileName(sampleFilePath));
            upload.Should().NotBeNull();

            Fixture.API.UserGeneratedContent.UploadUgcTrack(Fixture.Storage, upload.PostTarget, sampleFilePath)
                .Result.Should().Be(successUploadResult);

            Fixture.API.Playlist.Delete(Fixture.Storage, playlist).Should().BeTrue();
        }

    }
}
