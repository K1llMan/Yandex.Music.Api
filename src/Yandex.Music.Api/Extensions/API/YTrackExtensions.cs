using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.Extensions.API
{
    /// <summary>
    /// Методы-расширения для трека
    /// </summary>
    public static partial class YTrackExtensions
    {
        public static string GetLink(this YTrack track)
        {
            return GetLinkAsync(track).GetAwaiter().GetResult();
        }

        public static void Save(this YTrack track, string filePath)
        {
            SaveAsync(track, filePath).GetAwaiter().GetResult();
        }

        public static int AddLike(this YTrack track)
        {
            return AddLikeAsync(track).GetAwaiter().GetResult();
        }

        public static int RemoveLike(this YTrack track)
        {
            return RemoveLikeAsync(track).GetAwaiter().GetResult();
        }

        public static int AddDislike(this YTrack track)
        {
            return AddDislikeAsync(track).GetAwaiter().GetResult();
        }

        public static int RemoveDislike(this YTrack track)
        {
            return RemoveDislikeAsync(track).GetAwaiter().GetResult();
        }

        public static string SendPlayTrackInfo(this YTrack track, string from, bool fromCache = false, string playId = "", string playlistId = "", double totalPlayedSeconds = 0, double endPositionSeconds = 0)
        {
            return SendPlayTrackInfoAsync(track, from, fromCache, playId, playlistId, totalPlayedSeconds).GetAwaiter().GetResult();
        }

        public static YTrackSupplement Supplement(this YTrack track)
        {
            return SupplementAsync(track).GetAwaiter().GetResult();
        }

        public static YTrackSimilar Similar(this YTrack track)
        {
            return SimilarAsync(track).GetAwaiter().GetResult();
        }
    }
}
