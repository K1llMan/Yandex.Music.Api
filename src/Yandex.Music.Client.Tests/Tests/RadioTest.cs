using System.Collections.Generic;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Extensions.API;
using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Client.Tests.Tests
{
    [Collection("Yandex Test Harness"), Order(8)]
    [TestBeforeAfter]
    public class RadioTest : YandexTest
    {
        #region Поля

        private static string track = "All I Got";
        private static string album = "Black Is the Colour";
        private static string artist = "Arven";
        private static string playlist = "Лучшие песни русского рока";

        #endregion Поля

        [Fact]
        [Order(0)]
        public void GetRadioDashboard_ValidData_True()
        {
            List<YStation> dashboard = Fixture.Client.GetRadioDashboard();
            dashboard.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(1)]
        public void GetRadioStations_ValidData_True()
        {
            List<YStation> stations = Fixture.Client.GetRadioStations();
            stations.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(2)]
        public void GetRadioStation_ValidData_True()
        {
            Fixture.Station = Fixture.Client.GetRadioStation(new YStationId {
                Type = "genre",
                Tag = "allrock"
            });

            Fixture.Station.Should().NotBeNull();
        }

        [Fact]
        [Order(3)]
        public void GetTracks_ValidData_True()
        {
            Fixture.Station.Should().NotBeNull();

            List<YSequenceItem> tracks = Fixture.Station.GetTracks();
            tracks.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        [Order(4)]
        public void Video_ValidData_True()
        {
            Fixture.Station.Should().NotBeNull();

            string result = Fixture.Station.SetSettings2(new YStationSettings2 {
                Language = "any",
                Diversity = "default",
                MoodEnergy = "all"
            });

            result.Should().Be("ok");
        }

        public RadioTest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}