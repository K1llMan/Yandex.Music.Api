using System;
using System.IO;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Client.Extensions;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(12)]
    [TestBeforeAfter]
    public class YUserGeneratedContentTest : YandexTest
    {
        private const string SampleFilePath = "Static/sample-3s.mp3";
        private const string SuccessUploadResult = "CREATED";

        public YUserGeneratedContentTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }

        [Fact]
        [Order(0)]
        public void UploadTrackToPlaylist_ValidData_True()
        {
            string fileName = Path.GetFileName(SampleFilePath);
            byte[] bytes = File.ReadAllBytes(SampleFilePath);
            YPlaylist playlist = CreatePlaylist();
            Fixture.Client.UploadTrackToPlaylist(playlist.Kind, fileName, bytes).Result.Should()
                .Be(SuccessUploadResult);
            playlist.Delete().Should().BeTrue();
        }

        [Fact]
        [Order(1)]
        public void UploadTrackStreamToPlaylist_ValidData_True()
        {
            YPlaylist playlist = CreatePlaylist();
            Fixture.Client.UploadTrackToPlaylist(playlist.Kind, SampleFilePath).Result.Should().Be(SuccessUploadResult);
            playlist.Delete().Should().BeTrue();
        }

        [Fact]
        [Order(2)]
        public void UploadTrackPathToPlaylist_ValidData_True()
        {
            string fileName = Path.GetFileName(SampleFilePath);
            using (Stream stream = new FileStream(SampleFilePath, FileMode.Open))
            {
                YPlaylist playlist = CreatePlaylist();
                Fixture.Client.UploadTrackToPlaylist(playlist.Kind, fileName, stream).Result.Should()
                    .Be(SuccessUploadResult);
                playlist.Delete().Should().BeTrue();
            }
        }

        private YPlaylist CreatePlaylist()
        {
            YPlaylist playlist = Fixture.Client.CreatePlaylist($"UploadTestPlaylist-{DateTime.UtcNow:s}");
            return playlist;
        }
    }
}