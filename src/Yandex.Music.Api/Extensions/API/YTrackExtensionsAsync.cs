using System.Threading.Tasks;

using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Extensions.API
{
    /// <summary>
    /// Методы-расширения для трека
    /// </summary>
    public static partial class YTrackExtensions
    {
        public static Task<string> GetLinkAsync(this YTrack track)
        {
            return track.Context.API.Track.GetFileLinkAsync(track.Context.Storage, track);
        }

        public static Task SaveAsync(this YTrack track, string filePath)
        {
            return track.Context.API.Track.ExtractToFileAsync(track.Context.Storage, track, filePath);
        }

        public static async Task<int> AddLikeAsync(this YTrack track)
        {
            return (await track.Context.API.Library.AddTrackLikeAsync(track.Context.Storage, track))
                .Result.Revision;
        }

        public static async Task<int> RemoveLikeAsync(this YTrack track)
        {
            return (await track.Context.API.Library.RemoveTrackLikeAsync(track.Context.Storage, track))
                .Result.Revision;
        }

        public static async Task<int> AddDislikeAsync(this YTrack track)
        {
            return (await track.Context.API.Library.AddTrackDislikeAsync(track.Context.Storage, track))
                .Result.Revision;
        }

        public static async Task<int> RemoveDislikeAsync(this YTrack track)
        {
            return (await track.Context.API.Library.RemoveTrackDislikeAsync(track.Context.Storage, track))
                ?.Result.Revision ?? -1;
        }

        public static Task<string> SendPlayTrackInfoAsync(this YTrack track, string from, bool fromCache = false, string playId = "", string playlistId = "", double totalPlayedSeconds = 0, double endPositionSeconds = 0)
        {
            _ = endPositionSeconds;
            return track.Context.API.Track.SendPlayTrackInfoAsync(track.Context.Storage, track, from, fromCache, playId, playlistId, totalPlayedSeconds);
        }

        public static async Task<YTrackSupplement> SupplementAsync(this YTrack track)
        {
            return (await track.Context.API.Track.GetSupplementAsync(track.Context.Storage, track))
                .Result;
        }

        public static async Task<YTrackSimilar> SimilarAsync(this YTrack track)
        {
            return (await track.Context.API.Track.GetSimilarAsync(track.Context.Storage, track))
                .Result;
        }
    }
}
