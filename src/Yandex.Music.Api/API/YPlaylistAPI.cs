using System.Collections.Generic;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взамодействия с плейлистами
    /// </summary>
    public partial class YPlaylistAPI
    {
        #region Основные функции

        #region Список с главной

        /// <summary>
        /// Получение списка персональных плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public List<YResponse<YPlaylist>> GetPersonalPlaylists(AuthStorage storage)
        {
            return GetPersonalPlaylistsAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Список с главной

        #region Стандартные плейлисты

        /// <summary>
        /// Избранное
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<List<YPlaylist>> Favorites(AuthStorage storage)
        {
            return FavoritesAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YPlaylist> OfTheDay(AuthStorage storage)
        {
            return OfTheDayAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YPlaylist> DejaVu(AuthStorage storage)
        {
            return DejaVuAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Premiere(AuthStorage storage)
        {
            return PremiereAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Missed(AuthStorage storage)
        {
            return MissedAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Кинопоиск
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Kinopoisk(AuthStorage storage)
        {
            return KinopoiskAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Стандартные плейлисты

        #region Получение плейлиста

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="user">Uid пользователя-владельца плейлиста</param> 
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Get(AuthStorage storage, string user, string kinds)
        {
            return GetAsync(storage, user, kinds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="ids">Список пар пользователь:тип</param>
        /// <returns></returns>
        public YResponse<List<YPlaylist>> Get(AuthStorage storage, IEnumerable<(string user, string kind)> ids)
        {
            return GetAsync(storage, ids).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Описание плейлиста, для которого будут запрошены треки</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Get(AuthStorage storage, YPlaylist playlist)
        {
            return GetAsync(storage, playlist).GetAwaiter().GetResult();
        }

        #endregion Получение плейлиста

        #region Операции над плейлистами

        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Create(AuthStorage storage, string name)
        {
            return CreateAsync(storage, name).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Переименование
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Идентификатор плейлиста</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Rename(AuthStorage storage, string kinds, string name)
        {
            return RenameAsync(storage, kinds, name).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Переименование
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Rename(AuthStorage storage, YPlaylist playlist, string name)
        {
            return RenameAsync(storage, playlist.Kind, name).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public bool Delete(AuthStorage storage, string kinds)
        {
            return DeleteAsync(storage, kinds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public bool Delete(AuthStorage storage, YPlaylist playlist)
        {
            return DeleteAsync(storage, playlist.Kind).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Добавление трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="tracks">Треки для добавления</param>
        /// <returns></returns>
        public YResponse<YPlaylist> InsertTracks(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)
        {
            return InsertTracksAsync(storage, playlist, tracks).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удаление треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="tracks">Треки для удаления</param>
        /// <returns></returns>
        public YResponse<YPlaylist> DeleteTracks(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)
        {
            return DeleteTracksAsync(storage, playlist, tracks).GetAwaiter().GetResult();
        }

        #endregion Операции над плейлистами

        #endregion Основные функции
    }
}