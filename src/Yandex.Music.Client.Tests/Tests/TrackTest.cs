using System.Collections.Generic;
using System.IO;
using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Client.Extensions;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(2)]
    [TestBeforeAfter]
    public class TrackTest : YandexTest
    {
        #region Поля

        private string extractedFileName = "test.mp3";

        // Кино - "Группа крови"
        private string trackId = "106259";

        private static YResponse<List<YTrackDownloadInfo>> downloadInfo;
        private static YStorageDownloadFile downloadFile;

        #endregion Поля

        [Fact]
        [Order(0)]
        public void Get_ValidData_True()
        {
            Fixture.Track = Fixture.Client.GetTrack(trackId);
            Fixture.Track.Title.Should().Be("Группа крови");
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

        public TrackTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}