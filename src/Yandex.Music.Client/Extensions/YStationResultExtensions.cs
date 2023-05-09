using System.Collections.Generic;

using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Client.Extensions
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
    }
}
