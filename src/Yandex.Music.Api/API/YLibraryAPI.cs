using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Library;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с библиотекой
    /// </summary>
    public partial class YLibraryAPI
    {
        #region Основные функции

        #region Лайки

        /// <summary>
        /// Получение лайкнутых треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YLibraryTracks> GetLikedTracks(AuthStorage storage)
        {
            return GetLikedTracksAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение лайкнутых альбомов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<List<YLibraryAlbum>> GetLikedAlbums(AuthStorage storage)
        {
            return GetLikedAlbumsAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение лайкнутых исполнителей
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<List<YArtist>> GetLikedArtists(AuthStorage storage)
        {
            return GetLikedArtistsAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение лайкнутых плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<List<YLibraryPlaylists>> GetLikedPlaylists(AuthStorage storage)
        {
            return GetLikedPlaylistsAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Лайки

        #region Дизлайки

        /// <summary>
        /// Получение дизлайкнутых треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YLibraryTracks> GetDislikedTracks(AuthStorage storage)
        {
            return GetDislikedTracksAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение дизлайкнутых исполнителей
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<List<YArtist>> GetDislikedArtists(AuthStorage storage)
        {
            return GetDislikedArtistsAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Дизлайки

        #region Добавление в списки лайков/дизлайков

        /// <summary>
        /// Добавить трек в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public YResponse<YPlaylist> AddTrackLike(AuthStorage storage, YTrack track)
        {
            return AddTrackLikeAsync(storage, track).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить трек из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public YResponse<YRevision> RemoveTrackLike(AuthStorage storage, YTrack track)
        {
            return RemoveTrackLikeAsync(storage, track).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавить трек в список дизлайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public YResponse<YRevision> AddTrackDislike(AuthStorage storage, YTrack track)
        {
            return AddTrackDislikeAsync(storage, track).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить трек из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public YResponse<YRevision> RemoveTrackDislike(AuthStorage storage, YTrack track)
        {
            return RemoveTrackDislikeAsync(storage, track).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавить альбом в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="album">Альбом</param>
        /// <returns></returns>
        public YResponse<string> AddAlbumLike(AuthStorage storage, YAlbum album)
        {
            return AddAlbumLikeAsync(storage, album).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить альбом из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="album">Альбом</param>
        /// <returns></returns>
        public YResponse<string> RemoveAlbumLike(AuthStorage storage, YAlbum album)
        {
            return RemoveAlbumLikeAsync(storage, album).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавить исполнителя в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artist">Исполнитель</param>
        /// <returns></returns>
        public YResponse<string> AddArtistLike(AuthStorage storage, YArtist artist)
        {
            return AddArtistLikeAsync(storage, artist).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить исполнителя из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artist">Исполнитель</param>
        /// <returns></returns>
        public YResponse<string> RemoveArtistLike(AuthStorage storage, YArtist artist)
        {
            return RemoveArtistLikeAsync(storage, artist).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавить плейлист в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public YResponse<string> AddPlaylistLike(AuthStorage storage, YPlaylist playlist)
        {
            return AddPlaylistLikeAsync(storage, playlist).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить плейлист из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public YResponse<string> RemovePlaylistLike(AuthStorage storage, YPlaylist playlist)
        {
            return RemovePlaylistLikeAsync(storage, playlist).GetAwaiter().GetResult();
        }

        #endregion Добавление/удаление в списки лайков/дизлайков

        #endregion Основные функции
    }
}