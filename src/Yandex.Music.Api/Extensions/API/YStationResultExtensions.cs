using System.Collections.Generic;

using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Extensions.API
{
    /// <summary>
    /// Методы-расширения для радиостанции
    /// </summary>
    public static partial class YStationResultExtensions
    {
        public static List<YSequenceItem> GetTracks(this YStation station, string prevTrackId = "")
        {
            return GetTracksAsync(station, prevTrackId).GetAwaiter().GetResult();
        }

        public static string SetSettings2(this YStation station, YStationSettings2 settings)
        {
            return SetSettings2Async(station, settings).GetAwaiter().GetResult();
        }

        public static string SendFeedBack(this YStation station, YStationFeedbackType type, YTrack track = null, string batchId = "", double totalPlayedSeconds = 0)
        {
            return SendFeedBackAsync(station, type, track, batchId, totalPlayedSeconds).GetAwaiter().GetResult();
        }
    }
}
