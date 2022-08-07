using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Playlist;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взамодействия с плейлистами
    /// </summary>
    public class YPlaylistAPI : YCommonAPI
    {
        #region Вспомогательные функции

        /// <summary>
        /// Получение персональных плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="type">Тип</param>
        /// <returns>Плейлист</returns>
        private async Task<YResponse<YPlaylist>> GetPersonalPlaylist(AuthStorage storage, YGeneratedPlaylistType type)
        {
            return await LandingAsync(storage)
                .ContinueWith(list =>
                {
                    YPlaylist playlist = list.GetAwaiter().GetResult().Result.Blocks
                        .Where(b => b.Type == "personal-playlists")
                        .SelectMany(b => b.Entities)
                        .FirstOrDefault(e => e.Data.Type == type)
                        ?.Data
                        .Data;

                    return playlist == null
                        ? null
                        : Get(storage, playlist);
                });
        }

        /// <summary>
        /// Изменение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="changes">Список изменений</param>
        /// <returns>Плейлист после изменений</returns>
        private async Task<YResponse<YPlaylist>> ChangePlaylist(AuthStorage storage, YPlaylist playlist, List<YPlaylistChange> changes)
        {
            return await new YPlaylistChangeRequest(api, storage)
                .Create(playlist, changes)
                .GetResponseAsync();
        }

        private List<YTrack> RemoveIdentical(YTrack[] tracks)
        {
            return tracks.Distinct().ToList();
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public YPlaylistAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        #region Список с главной

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YResponse<YLanding>> LandingAsync(AuthStorage storage)
        {
            return await new YGetPlaylistMainPageRequest(api, storage)
                .Create()
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YLanding> Landing(AuthStorage storage)
        {
            return LandingAsync(storage).GetAwaiter().GetResult();
        }

        #endregion Список с главной

        #region Стандартные плейлисты

        /// <summary>
        /// Избранное
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YResponse<List<YPlaylist>>> FavoritesAsync(AuthStorage storage)
        {
            return await new YGetPlaylistFavoritesRequest(api, storage)
                .Create()
                .GetResponseAsync();
        }

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
        public async Task<YResponse<YPlaylist>> OfTheDayAsync(AuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.PlaylistOfTheDay);
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
        public async Task<YResponse<YPlaylist>> DejaVuAsync(AuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.NeverHeard);
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
        public async Task<YResponse<YPlaylist>> PremiereAsync(AuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.RecentTracks);
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
        public async Task<YResponse<YPlaylist>> MissedAsync(AuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.MissedLikes);
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
        /// Алиса
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YResponse<YPlaylist>> AliceAsync(AuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.Origin);
        }

        /// <summary>
        /// Алиса
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Alice(AuthStorage storage)
        {
            return MissedAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Подкасты
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YResponse<YPlaylist>> PodcastsAsync(AuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.Podcasts);
        }

        /// <summary>
        /// Подкасты
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YResponse<YPlaylist> Podcasts(AuthStorage storage)
        {
            return PodcastsAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Мой 2020
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YResponse<YPlaylist>> KinopoiskAsync(AuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.Kinopoisk);
        }

        /// <summary>
        /// Большая перемотка
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
        public async Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, string user, string kinds)
        {
            return await new YGetPlaylistRequest(api, storage)
                .Create(user, kinds)
                .GetResponseAsync();
        }

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
        /// <param name="playlist">Описание плейлиста, для которого будут запрошены треки</param>
        /// <returns></returns>
        public async Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, YPlaylist playlist)
        {
            return await new YGetPlaylistRequest(api, storage)
                .Create(playlist)
                .GetResponseAsync();
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
        public async Task<YResponse<YPlaylist>> CreateAsync(AuthStorage storage, string name)
        {
            return await new YPlaylistCreateRequest(api, storage)
                .Create(name)
                .GetResponseAsync();
        }

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
        public async Task<YResponse<YPlaylist>> RenameAsync(AuthStorage storage, string kinds, string name)
        {
            return await new YPlaylistRenameRequest(api, storage)
                .Create(kinds, name)
                .GetResponseAsync();
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
        public Task<YResponse<YPlaylist>> RenameAsync(AuthStorage storage, YPlaylist playlist, string name)
        {
            return RenameAsync(storage, playlist.Kind, name);
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
        public async Task<bool> DeleteAsync(AuthStorage storage, string kinds)
        {
            try {
                await new YPlaylistRemoveRequest(api, storage)
                    .Create(kinds)
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
        public Task<bool> DeleteAsync(AuthStorage storage, YPlaylist playlist)
        {
            return DeleteAsync(storage, playlist.Kind);
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
        public async Task<YResponse<YPlaylist>> InsertTracksAsync(AuthStorage storage, YPlaylist playlist, params YTrack[] tracks)
        {
            return await ChangePlaylist(storage, playlist, new List<YPlaylistChange> {
                    new()
                    {
                        Operation = YPlaylistChangeType.Insert,
                        At = 0,
                        Tracks = tracks.Select(t => t.GetKey()).ToList()
                    }
                })
                .ContinueWith(p => Get(storage, p.Result.Result));
        }

        /// <summary>
        /// Добавление трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="tracks">Треки для добавления</param>
        /// <returns></returns>
        public YResponse<YPlaylist> InsertTracks(AuthStorage storage, YPlaylist playlist, params YTrack[] tracks)
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
        public async Task<YResponse<YPlaylist>> DeleteTracksAsync(AuthStorage storage, YPlaylist playlist, params YTrack[] tracks)
        {
            List<YPlaylistChange> changes = RemoveIdentical(tracks)
                .Select(t => playlist.Tracks.Select(c => c.Track).ToList().IndexOf(t))
                .Where(i => i != -1)
                .Select(i => {
                    YTrackContainer t = playlist.Tracks[i];
                    return new YPlaylistChange {
                        Operation = YPlaylistChangeType.Delete,
                        From = i,
                        To = i + 1,
                        Tracks = new List<YTrackAlbumPair> {
                            t.Track.GetKey()
                        }
                    };
                })
                .ToList();

            return await ChangePlaylist(storage, playlist, changes);
        }

        /// <summary>
        /// Удаление треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="tracks">Треки для удаления</param>
        /// <returns></returns>
        public YResponse<YPlaylist> DeleteTracks(AuthStorage storage, YPlaylist playlist, params YTrack[] tracks)
        {
            return DeleteTracksAsync(storage, playlist, tracks).GetAwaiter().GetResult();
        }

        #endregion Операции над плейлистами

        #endregion Основные функции
    }
}