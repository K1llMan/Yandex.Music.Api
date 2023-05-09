using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для плейлиста
    /// </summary>
    public static partial class YPlaylistExtensions
    {
        private static bool CheckUser(YPlaylist playlist)
        {
            return playlist.Owner.Uid == playlist.Context.Storage.User.Uid;
        }

        public static YPlaylist WithTracks(this YPlaylist playlist)
        {
            return WithTracksAsync(playlist).GetAwaiter().GetResult();
        }

        public static string AddLike(this YPlaylist playlist)
        {
            return AddLikeAsync(playlist).GetAwaiter().GetResult();
        }

        public static string RemoveLike(this YPlaylist playlist)
        {
            return RemoveLikeAsync(playlist).GetAwaiter().GetResult();
        }

        public static YPlaylist Rename(this YPlaylist playlist, string newName)
        {
            return RenameAsync(playlist, newName).GetAwaiter().GetResult();
        }

        public static bool Delete(this YPlaylist playlist)
        {
            return DeleteAsync(playlist).GetAwaiter().GetResult();
        }

        public static YPlaylist InsertTracks(this YPlaylist playlist, params YTrack[] tracks)
        {
            return InsertTracksAsync(playlist, tracks).GetAwaiter().GetResult();
        }

        public static YPlaylist RemoveTracks(this YPlaylist playlist, params YTrack[] tracks)
        {
            return RemoveTracksAsync(playlist, tracks).GetAwaiter().GetResult();
        }
    }
}
