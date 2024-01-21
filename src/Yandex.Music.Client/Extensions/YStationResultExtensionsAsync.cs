using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для радиостанции
    /// </summary>
    public static partial class YStationResultExtensions
    {
        public static async Task<List<YSequenceItem>> GetTracksAsync(this YStation station, string prevTrackId = "")
        {
            return (await station.Context.API.Radio.GetStationTracksAsync(station.Context.Storage, station, prevTrackId))
                .Result.Sequence;
        }

        public static async Task<string> SetSettings2Async(this YStation station, YStationSettings2 settings)
        {
            return (await station.Context.API.Radio.SetStationSettings2Async(station.Context.Storage, station, settings))
                .Result;
        }

        public static Task<string> SendFeedBackAsync(this YStation station, YStationFeedbackType type, YTrack track = null, string batchId = "", double totalPlayedSeconds = 0)
        {
            return station.Context.API.Radio.SendStationFeedBackAsync(station.Context.Storage, station, type, track, batchId, totalPlayedSeconds);
        }
    }
}
