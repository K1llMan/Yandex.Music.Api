using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client.Extensions
{
    /// <summary>
    /// Методы-расширения для плейлиста
    /// </summary>
    public static class YPlaylistExtensions
    {
        private static bool CheckUser(YPlaylist playlist)
        {
            return playlist.Owner.Uid == playlist.Context.Storage.User.Uid;
        }

        public static string AddLike(this YPlaylist playlist)
        {
            return playlist.Context.API.Library.AddPlaylistLike(playlist.Context.Storage, playlist).Result;
        }

        public static string RemoveLike(this YPlaylist playlist)
        {
            return playlist.Context.API.Library.RemovePlaylistLike(playlist.Context.Storage, playlist).Result;
        }

        public static YPlaylist Rename(this YPlaylist playlist, string newName)
        {
            return CheckUser(playlist)
                ? playlist.Context.API.Playlist.Rename(playlist.Context.Storage, playlist, newName).Result
                : playlist;
        }

        public static bool Delete(this YPlaylist playlist)
        {
            return CheckUser(playlist) && playlist.Context.API.Playlist.Delete(playlist.Context.Storage, playlist);
        }

        public static YPlaylist InsertTracks(this YPlaylist playlist, params YTrack[] tracks)
        {
            return CheckUser(playlist)
                ? playlist.Context.API.Playlist.InsertTracks(playlist.Context.Storage, playlist, tracks).Result
                : playlist;
        }

        public static YPlaylist RemoveTracks(this YPlaylist playlist, params YTrack[] tracks)
        {
            return CheckUser(playlist)
                ? playlist.Context.API.Playlist.DeleteTracks(playlist.Context.Storage, playlist, tracks).Result
                : playlist;
        }
    }
}
