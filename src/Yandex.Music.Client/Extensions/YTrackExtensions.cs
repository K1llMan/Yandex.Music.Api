using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для трека
    /// </summary>
    public static class YTrackExtensions
    {
        public static string GetLink(this YTrack track)
        {
            return track.Context.API.Track.GetFileLink(track.Context.Storage, track);
        }

        public static void Save(this YTrack track, string filePath)
        {
            track.Context.API.Track.ExtractToFile(track.Context.Storage, track, filePath);
        }

        public static int AddLike(this YTrack track)
        {
            return track.Context.API.Library.AddTrackLike(track.Context.Storage, track).Result.Revision;
        }

        public static int RemoveLike(this YTrack track)
        {
            return track.Context.API.Library.RemoveTrackLike(track.Context.Storage, track).Result.Revision;
        }

        public static int AddDislike(this YTrack track)
        {
            return track.Context.API.Library.AddTrackDislike(track.Context.Storage, track).Result.Revision;
        }

        public static int RemoveDislike(this YTrack track)
        {
            return track.Context.API.Library.RemoveTrackDislike(track.Context.Storage, track).Result.Revision;
        }
    }
}
