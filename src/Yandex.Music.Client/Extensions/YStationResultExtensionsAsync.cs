using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Models.Radio;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для радиостанции
    /// </summary>
    public static partial class YStationResultExtensions
    {
        public static Task<List<YSequenceItem>> GetTracksAsync(this YStation station, string prevTrackId = "")
        {
            return station.Context.API.Radio.GetStationTracksAsync(station.Context.Storage, station, prevTrackId)
                .ContinueWith(t => t.Result.Result.Sequence);
        }

        public static Task<string> SetSettings2Async(this YStation station, YStationSettings2 settings)
        {
            return station.Context.API.Radio.SetStationSettings2Async(station.Context.Storage, station, settings)
                .ContinueWith(t => t.Result.Result);
        }
    }
}
