using System.Collections.Generic;
using System.IO;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Extensions.API;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(2)]
    [TestBeforeAfter]
    public class TrackTest : YandexTest
    {
        #region Поля

        private string extractedFileName = "test.mp3";

        // Metallica - Enter Sandman
        private string trackId = "57703";

        private static YResponse<List<YTrackDownloadInfo>> downloadInfo;
        private static YStorageDownloadFile downloadFile;

        #endregion Поля

        [Fact]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Track = Fixture.Client.GetTrack(trackId);
            Fixture.Track.Title.Should().Be("Enter Sandman");
        }

        [Fact]
        [Order(1)]
        public void GetFileLink_ValidData_True()
        {
            Fixture.Track.Should().NotBe(null);

            string link = Fixture.Track.GetLink();

            link.Should().NotBeNullOrEmpty();
        }

        [Fact]
        [Order(2)]
        public void ExtractToFile_ValidData_True()
        {
            File.Delete(extractedFileName);

            Fixture.Track.Should().NotBe(null);

            Fixture.Track.Save(extractedFileName);

            File.Exists(extractedFileName).Should().BeTrue();
        }

        [Fact]
        [Order(3)]
        public void AddLike_ValidData_True()
        {
            Fixture.Track.Should().NotBe(null);

            int revision = Fixture.Track.AddLike();
            revision.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(4)]
        public void RemoveLike_ValidData_True()
        {
            int revision = Fixture.Track.RemoveLike();
            revision.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(5)]
        public void AddDislike_ValidData_True()
        {
            Fixture.Track.Should().NotBe(null);

            int revision = Fixture.Track.AddDislike();
            revision.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(6)]
        public void RemoveDislike_ValidData_True()
        {
            int revision = Fixture.Track.RemoveDislike();
            revision.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(7)]
        public void Supplement_ValidData_True()
        {
            YTrackSupplement supplement = Fixture.Track.Supplement();
            supplement.Should().NotBeNull();
        }

        [Fact]
        [Order(8)]
        public void Similar_ValidData_True()
        {
            YTrackSimilar similar = Fixture.Track.Similar();
            similar.Should().NotBeNull();
        }

        [Fact]
        [Order(9)]
        public void GetTracks_ValidData_True()
        {
            List<YTrack> tracks = Fixture.Client.GetTracks(new[] { "43422600", "28061202" });
            tracks.Count.Should().Be(2);
        }

        public TrackTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}
