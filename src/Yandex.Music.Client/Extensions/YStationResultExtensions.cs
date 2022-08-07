using System.Collections.Generic;

using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для радиостанции
    /// </summary>
    public static class YStationResultExtensions
    {
        public static List<YSequenceItem> GetTracks(this YStation station, string prevTrackId = "")
        {
            return station.Context.API.Radio.GetStationTracks(station.Context.Storage, station, prevTrackId).Result.Sequence;
        }

        public static string SetSettings2(this YStation station, YStationSettings2 settings)
        {
            return station.Context.API.Radio.SetStationSettings2(station.Context.Storage, station, settings).Result;
        }
    }
}
