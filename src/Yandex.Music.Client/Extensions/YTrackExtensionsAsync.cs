using System.Threading.Tasks;

using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Extensions
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

        public static Task<int> AddLikeAsync(this YTrack track)
        {
            return track.Context.API.Library.AddTrackLikeAsync(track.Context.Storage, track)
                .ContinueWith(t => t.Result.Result.Revision);
        }

        public static Task<int> RemoveLikeAsync(this YTrack track)
        {
            return track.Context.API.Library.RemoveTrackLikeAsync(track.Context.Storage, track)
                .ContinueWith(t => t.Result.Result.Revision);
        }

        public static Task<int> AddDislikeAsync(this YTrack track)
        {
            return track.Context.API.Library.AddTrackDislikeAsync(track.Context.Storage, track)
                .ContinueWith(t => t.Result.Result.Revision);
        }

        public static Task<int> RemoveDislikeAsync(this YTrack track)
        {
            return track.Context.API.Library.RemoveTrackDislikeAsync(track.Context.Storage, track)
                .ContinueWith(t => t.Result?.Result ?? -1);
        }

        public static Task<YTrackSupplement> SupplementAsync(this YTrack track)
        {
            return track.Context.API.Track.GetSupplementAsync(track.Context.Storage, track)
                .ContinueWith(t => t.Result.Result);
        }

        public static Task<YTrackSimilar> SimilarAsync(this YTrack track)
        {
            return track.Context.API.Track.GetSimilarAsync(track.Context.Storage, track)
                .ContinueWith(t => t.Result.Result);
        }
    }
}
