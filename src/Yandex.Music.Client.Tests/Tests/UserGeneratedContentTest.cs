using System;
using System.IO;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Extensions.API;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Client.Tests.Tests
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
            YPlaylist playlist = Fixture.Client.CreatePlaylist($"UploadTestPlaylist-{DateTime.UtcNow:s}");
            Fixture.Client.UploadTrackToPlaylist(playlist, Path.GetFileName(sampleFilePath), sampleFilePath).Should().Be(successUploadResult);
            playlist.Delete().Should().BeTrue();
        }
    }
}