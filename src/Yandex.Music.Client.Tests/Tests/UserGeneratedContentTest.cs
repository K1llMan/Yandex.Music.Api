using System;
using System.IO;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;
using Yandex.Music.Client.Extensions;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(10)]
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
            var fileName = Path.GetFileName(SampleFilePath);
            var bytes = File.ReadAllBytes(SampleFilePath);
            Fixture.Client.Authorize(Fixture.AppSettings.Token);
            var playlist = Fixture.Client.CreatePlaylist($"UploadTestPlaylist-{DateTime.UtcNow:s}");
            Fixture.Client.UploadTrackToPlaylist(playlist.Kind, fileName, bytes).Result.Should().Be(SuccessUploadResult);
            playlist.Delete().Should().BeTrue();
        }
    }
}

