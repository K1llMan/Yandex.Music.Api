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
    }
}
