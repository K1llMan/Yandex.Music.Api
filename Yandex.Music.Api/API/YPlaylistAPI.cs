using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Playlist;
using Yandex.Music.Api.Requests.Track;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взамодействия с плейлистами
    /// </summary>
    public class YPlaylistAPI
    {
        #region Вспомогательные функции

        #endregion Вспомогательные функции

        #region Основные функции

        #region Список с главной

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<List<YPlaylist>> MainPagePersonalAsync(YAuthStorage storage)
        {
            return await new YGetPlaylistMainPageRequest(storage)
                .Create()
                .GetResponseAsyncList<YPlaylist>("$..[?(@.type == 'personal-playlist')].data.data");
        }

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public List<YPlaylist> MainPagePersonal(YAuthStorage storage)
        {
            return MainPagePersonalAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Список с главной

        #region Стандартные плейлисты

        /// <summary>
        /// Избранное
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YPlaylistFavoritesResponse> FavoritesAsync(YAuthStorage storage)
        {
            return await new YGetPlaylistFavoritesRequest(storage)
                .Create()
                .GetResponseAsync<YPlaylistFavoritesResponse>();
        }

        /// <summary>
        /// Избранное
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YPlaylistFavoritesResponse Favorites(YAuthStorage storage)
        {
            return FavoritesAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public async Task<YPlaylist> OfTheDayAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistOfDayRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public YPlaylist OfTheDay(YAuthStorage storage, string kinds)
        {
            return OfTheDayAsync(storage, kinds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public async Task<YPlaylist> DejaVuAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistDejaVuRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public YPlaylist DejaVu(YAuthStorage storage, string kinds)
        {
            return DejaVuAsync(storage, kinds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public async Task<YPlaylist> PremiereAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistPremiereRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public YPlaylist Premiere(YAuthStorage storage, string kinds)
        {
            return PremiereAsync(storage, kinds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public async Task<YPlaylist> MissedAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistMissedRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public YPlaylist Missed(YAuthStorage storage, string kinds)
        {
            return MissedAsync(storage, kinds).GetAwaiter().GetResult();
        }

        #endregion Стандартные плейлисты

        #region Операции над плейлистами

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public async Task<YPlaylist> GetAsync(YAuthStorage storage, string kinds)
        {
            return await new YGetPlaylistRequest(storage)
                .Create(kinds)
                .GetResponseAsync<YPlaylist>("playlist");
        }

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public YPlaylist Get(YAuthStorage storage, string kinds)
        {
            return GetAsync(storage, kinds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public async Task<YPlaylistChangeResponse> CreateAsync(YAuthStorage storage, string name)
        {
            return await new YPlaylistChangeRequest(storage)
                .Create(name)
                .GetResponseAsync<YPlaylistChangeResponse>();
        }

        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public YPlaylistChangeResponse Create(YAuthStorage storage, string name)
        {
            return CreateAsync(storage, name).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kind">Тип</param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(YAuthStorage storage, string kind)
        {
            try {
                await new YPlaylistRemoveRequest(storage)
                    .Create(kind)
                    .GetResponseAsync();

                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return false;
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kind">Тип</param>
        /// <returns></returns>
        public bool Remove(YAuthStorage storage, string kind)
        {
            return RemoveAsync(storage, kind).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавление трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <param name="albumId">Идентификатор альбома</param>
        /// <param name="playlistKind">Тип</param>
        /// <returns></returns>
        public async Task<YInsertTrackToPlaylistResponse> InsertTrackAsync(YAuthStorage storage, string trackId, string albumId,
            string playlistKind)
        {
            return await new YInsertTrackToPlaylistRequest(storage)
                .Create(0, trackId, albumId, playlistKind)
                .GetResponseAsync<YInsertTrackToPlaylistResponse>();
        }

        /// <summary>
        /// Добавление трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackId">Идентификатор трека</param>
        /// <param name="albumId">Идентификатор альбома</param>
        /// <param name="playlistKind">Тип</param>
        /// <returns></returns>
        public YInsertTrackToPlaylistResponse InsertTrack(YAuthStorage storage, string trackId, string albumId, string playlistKind)
        {
            return InsertTrackAsync(storage, trackId, albumId, playlistKind).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удаление треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="from">Начало интервала</param>
        /// <param name="to">Конец интервала</param>
        /// <param name="revision">Ревизия</param>
        /// <param name="playlistKind">Тип</param>
        /// <returns></returns>
        public async Task<YDeleteTrackFromPlaylistResponse> DeleteTrackAsync(YAuthStorage storage, int from, int to, int revision,
            string playlistKind)
        {
            return await new YDeleteTrackFromPlaylistRequest(storage)
                .Create(from, to, revision, playlistKind)
                .GetResponseAsync<YDeleteTrackFromPlaylistResponse>();
        }

        /// <summary>
        /// Удаление треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="from">Начало интервала</param>
        /// <param name="to">Конец интервала</param>
        /// <param name="revision">Ревизия</param>
        /// <param name="playlistKind">Тип</param>
        /// <returns></returns>
        public YDeleteTrackFromPlaylistResponse DeleteTrack(YAuthStorage storage, int from, int to, int revision, string playlistKind)
        {
            return DeleteTrackAsync(storage, from, to, revision, playlistKind).GetAwaiter().GetResult();
        }

        #endregion Операции над плейлистами

        #endregion Main function
    }
}