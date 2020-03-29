using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.YLibrary;
using Yandex.Music.Api.Common.YPlaylist;
using Yandex.Music.Api.Common.YTrack;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Requests.Library;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взаимодействия с библиотекой
    /// </summary>
    public class YLibraryAPI
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
        private async Task<List<T>> GetLibrarySection<T>(YAuthStorage storage, YLibrarySection section, YLibrarySectionType type = YLibrarySectionType.Likes, string jsonPath = "")
        {
            return await new YGetLibrarySectionRequest(storage)
                .Create(section, type)
                .GetResponseAsyncList<T>(jsonPath);
        }

        #endregion Вспомогательные функции

        #region Основные функции

        #region Лайки

        /// <summary>
        /// Получение лайкнутых треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<List<YLibraryTrack>> GetLikedTracksAsync(YAuthStorage storage)
        {
            return await GetLibrarySection<YLibraryTrack>(storage, YLibrarySection.Tracks, jsonPath: "library.tracks[*]");
        }

        /// <summary>
        /// Получение лайкнутых треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public List<YLibraryTrack> GetLikedTracks(YAuthStorage storage)
        {
            return GetLikedTracksAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение лайкнутых альбомов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<List<YLibraryAlbum>> GetLikedAlbumsAsync(YAuthStorage storage)
        {
            return await GetLibrarySection<YLibraryAlbum>(storage, YLibrarySection.Albums, jsonPath: "[*]");
        }

        /// <summary>
        /// Получение лайкнутых альбомов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public List<YLibraryAlbum> GetLikedAlbums(YAuthStorage storage)
        {
            return GetLikedAlbumsAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение лайкнутых исполнителей
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<List<YLibraryArtist>> GetLikedArtistsAsync(YAuthStorage storage)
        {
            return await GetLibrarySection<YLibraryArtist>(storage, YLibrarySection.Artists, jsonPath: "[*]");
        }

        /// <summary>
        /// Получение лайкнутых исполнителей
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public List<YLibraryArtist> GetLikedArtists(YAuthStorage storage)
        {
            return GetLikedArtistsAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение лайкнутых плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<List<YPlaylist>> GetLikedPlaylistsAsync(YAuthStorage storage)
        {
            return await GetLibrarySection<YPlaylist>(storage, YLibrarySection.Playlists, jsonPath: "[*].playlist");
        }

        /// <summary>
        /// Получение лайкнутых плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public List<YPlaylist> GetLikedPlaylists(YAuthStorage storage)
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
        public async Task<List<YLibraryTrack>> GetDislikedTracksAsync(YAuthStorage storage)
        {
            return await GetLibrarySection<YLibraryTrack>(storage, YLibrarySection.Tracks, YLibrarySectionType.Dislikes, "library.tracks[*]");
        }

        /// <summary>
        /// Получение дизлайкнутых треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public List<YLibraryTrack> GetDislikedTracks(YAuthStorage storage)
        {
            return GetDislikedTracksAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Дизлайки

        #region Добавление в списки лайков/дизлайков

        /// <summary>
        /// Добавить трек в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public async Task<int> AddTrackLikeAsync(YAuthStorage storage, YTrack track)
        {
            return await new YLibraryAddRequest(storage)
                .Create(track.GetKey().ToString(), YLibrarySection.Tracks)
                .GetResponseAsync<int>("revision");
        }

        /// <summary>
        /// Добавить трек в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public int AddTrackLike(YAuthStorage storage, YTrack track)
        {
            return AddTrackLikeAsync(storage, track).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить трек из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public async Task<int> RemoveTrackLikeAsync(YAuthStorage storage, YTrack track)
        {
            return await new YLibraryRemoveRequest(storage)
                .Create(track.GetKey().ToString(), YLibrarySection.Tracks)
                .GetResponseAsync<int>("revision");
        }

        /// <summary>
        /// Удалить трек из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public int RemoveTrackLike(YAuthStorage storage, YTrack track)
        {
            return RemoveTrackLikeAsync(storage, track).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавить трек в список дизлайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public async Task<int> AddTrackDislikeAsync(YAuthStorage storage, YTrack track)
        {
            return await new YLibraryAddRequest(storage)
                .Create(track.GetKey().ToString(), YLibrarySection.Tracks, YLibrarySectionType.Dislikes)
                .GetResponseAsync<int>("revision");
        }

        /// <summary>
        /// Добавить трек в список дизлайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public int AddTrackDislike(YAuthStorage storage, YTrack track)
        {
            return AddTrackDislikeAsync(storage, track).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить трек из списка дизлайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public async Task<int> RemoveTrackDislikeAsync(YAuthStorage storage, YTrack track)
        {
            return await new YLibraryRemoveRequest(storage)
                .Create(track.GetKey().ToString(), YLibrarySection.Tracks, YLibrarySectionType.Dislikes)
                .GetResponseAsync<int>("revision");
        }

        /// <summary>
        /// Удалить трек из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="track">Трек</param>
        /// <returns></returns>
        public int RemoveTrackDislike(YAuthStorage storage, YTrack track)
        {
            return RemoveTrackLikeAsync(storage, track).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавить альбом в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="album">Альбом</param>
        /// <returns></returns>
        public async Task<bool> AddAlbumLikeAsync(YAuthStorage storage, YAlbum album)
        {
            return await new YLibraryAddRequest(storage)
                .Create(album.Id, YLibrarySection.Albums)
                .GetResponseAsync<string>() == "ok";
        }

        /// <summary>
        /// Добавить альбом в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="album">Альбом</param>
        /// <returns></returns>
        public bool AddAlbumLike(YAuthStorage storage, YAlbum album)
        {
            return AddAlbumLikeAsync(storage, album).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить альбом из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="album">Альбом</param>
        /// <returns></returns>
        public async Task<bool> RemoveAlbumLikeAsync(YAuthStorage storage, YAlbum album)
        {
            return await new YLibraryRemoveRequest(storage)
               .Create(album.Id, YLibrarySection.Albums)
               .GetResponseAsync<string>() == "ok";
        }

        /// <summary>
        /// Удалить альбом из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="album">Альбом</param>
        /// <returns></returns>
        public bool RemoveAlbumLike(YAuthStorage storage, YAlbum album)
        {
            return RemoveAlbumLikeAsync(storage, album).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавить исполнителя в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artist">Исполнитель</param>
        /// <returns></returns>
        public async Task<bool> AddArtistLikeAsync(YAuthStorage storage, YArtist artist)
        {
            return await new YLibraryAddRequest(storage)
               .Create(artist.Id, YLibrarySection.Artists)
               .GetResponseAsync<string>() == "ok";
        }

        /// <summary>
        /// Добавить исполнителя в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artist">Исполнитель</param>
        /// <returns></returns>
        public bool AddArtistLike(YAuthStorage storage, YArtist artist)
        {
            return AddArtistLikeAsync(storage, artist).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить исполнителя из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artist">Исполнитель</param>
        /// <returns></returns>
        public async Task<bool> RemoveArtistLikeAsync(YAuthStorage storage, YArtist artist)
        {
            return await new YLibraryRemoveRequest(storage)
               .Create(artist.Id, YLibrarySection.Artists)
               .GetResponseAsync<string>() == "ok";
        }

        /// <summary>
        /// Удалить исполнителя из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artist">Исполнитель</param>
        /// <returns></returns>
        public bool RemoveArtistLike(YAuthStorage storage, YArtist artist)
        {
            return RemoveArtistLikeAsync(storage, artist).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавить плейлист в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public async Task<bool> AddPlaylistLikeAsync(YAuthStorage storage, YPlaylist playlist)
        {
            return await new YLibraryAddRequest(storage)
               .Create(playlist.GetKey().ToString(), YLibrarySection.Playlists)
               .GetResponseAsync<string>() == "ok";
        }

        /// <summary>
        /// Добавить плейлист в список лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public bool AddPlaylistLike(YAuthStorage storage, YPlaylist playlist)
        {
            return AddPlaylistLikeAsync(storage, playlist).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удалить плейлист из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public async Task<bool> RemovePlaylistLikeAsync(YAuthStorage storage, YPlaylist playlist)
        {
            return await new YLibraryRemoveRequest(storage)
               .Create(playlist.GetKey().ToString(), YLibrarySection.Playlists)
               .GetResponseAsync<string>() == "ok";
        }

        /// <summary>
        /// Удалить плейлист из списка лайкнутых
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public bool RemovePlaylistLike(YAuthStorage storage, YPlaylist playlist)
        {
            return RemovePlaylistLikeAsync(storage, playlist).GetAwaiter().GetResult();
        }

        #endregion Добавление/удаление в списки лайков/дизлайков

        #endregion Основные функции
    }
}