using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.Ordering;

using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Tests.Traits;

namespace Yandex.Music.Api.Tests.Tests.API
{
    [Collection("Yandex Test Harness"), Order(8)]
    [TestBeforeAfter]
    public class RadioAPITest : YandexTest
    {
        #region Поля

        // DragonForce - The Power Within
        private static string albumId = "621147";

        #endregion Поля

        [Fact, YandexTrait(TraitGroup.RadioAPI)]
        [Order(0)]
        public void GetStationsDashboard_ValidData_True()
        {
            YResponse<YStationsDashboard> stations = Fixture.API.Radio.GetStationsDashboard(Fixture.Storage);
            stations.Result.Stations.Count.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.RadioAPI)]
        [Order(1)]
        public void GetStations_ValidData_True()
        {
            YResponse<List<YStation>> stations = Fixture.API.Radio.GetStations(Fixture.Storage);
            stations.Result.Count.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.RadioAPI)]
        [Order(2)]
        public void GetStation_ValidData_True()
        {
            Fixture.Station = Fixture.API.Radio.GetStation(Fixture.Storage, new YStationId {
                Type = "genre",
                Tag = "allrock"
            });

            Fixture.Station.Result.Count.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.RadioAPI)]
        [Order(3)]
        public void GetStationTracks_ValidData_True()
        {
            Fixture.Station.Should().NotBeNull();
            Fixture.Station.Result.Count.Should().BeGreaterThan(0);

            YResponse<YStationSequence> sequence = Fixture.API.Radio.GetStationTracks(Fixture.Storage, Fixture.Station.Result.First());

            sequence.Result.Sequence.Count.Should().BeGreaterThan(0);
        }

        [Fact, YandexTrait(TraitGroup.RadioAPI)]
        [Order(4)]
        public void SetStationSettings2_ValidData_True()
        {
            Fixture.Station.Should().NotBeNull();
            Fixture.Station.Result.Count.Should().BeGreaterThan(0);

            YResponse<string> response = Fixture.API.Radio.SetStationSettings2(Fixture.Storage, Fixture.Station.Result.First(), new YStationSettings2 {
                Language = "any",
                Diversity = "default",
                MoodEnergy = "all"
            });

            response.Result.Should().Be("ok");
        }

        public RadioAPITest(YandexTestHarness fixture, ITestOutputHelper output) : base(fixture, output)
        {
        }
    }
}