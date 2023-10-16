using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Library;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Library;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с библиотекой
    /// </summary>
    public partial class YLibraryAPI : YCommonAPI
    {
        #region Вспомогательные функции

        /// <summary>
        /// Получение секции библиотеки
        /// </summary>
        /// <typeparam name="T">Тип объекта библиотеки</typeparam>
        /// <param name="storage">Хранилище</param>
        /// <param name="section">Секция</param>
        /// <param name="type">Тип</param>
        /// <returns>Список объектов из секции</returns>
        private Task<YResponse<T>> GetLibrarySection<T>(AuthStorage storage, YLibrarySection section, YLibrarySectionType type = YLibrarySectionType.Likes)
        {
            return new YGetLibrarySectionBuilder<T>(api, storage)
                .Build((section, type))
                .GetResponseAsync();
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public YLibraryAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        #region Лайки

        /// <summary>
        /// Получение лайкнутых треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YLibraryTracks>> GetLikedTracksAsync(AuthStorage storage)
        {
            return GetLibrarySection<YLibraryTracks>(storage, YLibrarySection.Tracks);
        }

        /// <summary>
        /// Получение лайкнутых альбомов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<List<YLibraryAlbum>>> GetLikedAlbumsAsync(AuthStorage storage)
        {
            return GetLibrarySection<List<YLibraryAlbum>>(storage, YLibrarySection.Albums);
        }

        /// <summary>
        /// Получение лайкнутых исполнителей
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<List<YArtist>>> GetLikedArtistsAsync(AuthStorage storage)
        {
            return GetLibrarySection<List<YArtist>>(storage, YLibrarySection.Artists);
        }

        /// <summary>
        /// Получение лайкнутых плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<List<YLibraryPlaylists>>> GetLikedPlaylistsAsync(AuthStorage storage)
        {
            return GetLibrarySection<List<YLibraryPlaylists>>(storage, YLibrarySection.Playlists);
        }

        #endregion Лайки

        #region Дизлайки

        /// <summary>
        /// Получение дизлайкнутых треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YLibraryTracks>> GetDislikedTracksAsync(AuthStorage storage)
        {
            return GetLibrarySection<YLibraryTracks>(storage, YLibrarySection.Tracks, YLibrarySectionType.Dislikes);
        }

        /// <summary>
        /// Получение дизлайкнутых исполнителей
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<List<YArtist>>> GetDislikedArtistsAsync(AuthStorage storage)
        {
            return GetLibrarySection<List<YArtist>>(storage, YLibrarySection.Artists, YLibrarySectionType.Dislikes);
        }

        #endregion Дизлайки

        #region Добавление в списки лайков/дизлайков

        /// <summary>
        /// Добавить трек в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> AddTrackLikeAsync(AuthStorage storage, YTrack track)
        {
            return new YLibraryAddBuilder<YPlaylist>(api, storage)
                .Build((track.GetKey().ToString(), YLibrarySection.Tracks, YLibrarySectionType.Likes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Удалить трек из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<YResponse<YRevision>> RemoveTrackLikeAsync(AuthStorage storage, YTrack track)
        {
            return new YLibraryRemoveBuilder<YRevision>(api, storage)
                .Build((track.GetKey().ToString(), YLibrarySection.Tracks, YLibrarySectionType.Likes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Добавить трек в список дизлайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<YResponse<YRevision>> AddTrackDislikeAsync(AuthStorage storage, YTrack track)
        {
            return new YLibraryAddBuilder<YRevision>(api, storage)
                .Build((track.GetKey().ToString(), YLibrarySection.Tracks, YLibrarySectionType.Dislikes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Удалить трек из списка дизлайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public Task<YResponse<YRevision>> RemoveTrackDislikeAsync(AuthStorage storage, YTrack track)
        {
            return new YLibraryRemoveBuilder<YRevision>(api, storage)
                .Build((track.GetKey().ToString(), YLibrarySection.Tracks, YLibrarySectionType.Dislikes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Добавить альбом в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="album">Альбом</param>
        /// <returns></returns>
        public Task<YResponse<string>> AddAlbumLikeAsync(AuthStorage storage, YAlbum album)
        {
            return new YLibraryAddBuilder<string>(api, storage)
                .Build((album.Id, YLibrarySection.Albums, YLibrarySectionType.Likes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Удалить альбом из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="album">Альбом</param>
        /// <returns></returns>
        public Task<YResponse<string>> RemoveAlbumLikeAsync(AuthStorage storage, YAlbum album)
        {
            return new YLibraryRemoveBuilder<string>(api, storage)
                .Build((album.Id, YLibrarySection.Albums, YLibrarySectionType.Likes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Добавить исполнителя в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artist">Исполнитель</param>
        /// <returns></returns>
        public Task<YResponse<string>> AddArtistLikeAsync(AuthStorage storage, YArtist artist)
        {
            return new YLibraryAddBuilder<string>(api, storage)
                .Build((artist.Id, YLibrarySection.Artists, YLibrarySectionType.Likes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Удалить исполнителя из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artist">Исполнитель</param>
        /// <returns></returns>
        public Task<YResponse<string>> RemoveArtistLikeAsync(AuthStorage storage, YArtist artist)
        {
            return new YLibraryRemoveBuilder<string>(api, storage)
                .Build((artist.Id, YLibrarySection.Artists, YLibrarySectionType.Likes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Добавить плейлист в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public Task<YResponse<string>> AddPlaylistLikeAsync(AuthStorage storage, YPlaylist playlist)
        {
            return new YLibraryAddBuilder<string>(api, storage)
                .Build((playlist.GetKey().ToString(), YLibrarySection.Playlists, YLibrarySectionType.Likes))
                .GetResponseAsync();
        }

        /// <summary>
        /// Удалить плейлист из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public Task<YResponse<string>> RemovePlaylistLikeAsync(AuthStorage storage, YPlaylist playlist)
        {
            return new YLibraryRemoveBuilder<string>(api, storage)
                .Build((playlist.GetKey().ToString(), YLibrarySection.Playlists, YLibrarySectionType.Likes))
                .GetResponseAsync();
        }

        #endregion Добавление/удаление в списки лайков/дизлайков

        #endregion Основные функции
    }
}