using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.YPlaylist;
using Yandex.Music.Api.Common.YTrack;
using Yandex.Music.Api.Requests.Playlist;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взамодействия с плейлистами
    /// </summary>
    public class YPlaylistAPI
    {
        #region Вспомогательные функции

        /// <summary>
        /// Получение персональных плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="type">Тип</param>
        /// <returns>Плейлист</returns>
        private async Task<YPlaylist> GetPersonalPlaylist(YAuthStorage storage, YGeneratedPlaylistType type)
        {
            return await MainPagePersonalAsync(storage)
                .ContinueWith(list => {
                    YPlaylist playlist = list.Result.FirstOrDefault(p => p.GeneratedPlaylistType == type);
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
        private async Task<YPlaylist> ChangePlaylist(YAuthStorage storage, YPlaylist playlist, List<YPlaylistChange> changes)
        {
            return await new YPlaylistChangeRequest(storage)
                .Create(playlist, changes)
                .GetResponseAsync<YPlaylist>();
        }

        private List<YTrack> RemoveIdentical(List<YTrack> tracks)
        {
            return tracks.Distinct().ToList();
        }

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
        public async Task<List<YPlaylist>> FavoritesAsync(YAuthStorage storage)
        {
            return await new YGetPlaylistFavoritesRequest(storage)
                .Create()
                .GetResponseAsyncList<YPlaylist>("[*]");
        }

        /// <summary>
        /// Избранное
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public List<YPlaylist> Favorites(YAuthStorage storage)
        {
            return FavoritesAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YPlaylist> OfTheDayAsync(YAuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.PlaylistOfTheDay);
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YPlaylist OfTheDay(YAuthStorage storage)
        {
            return OfTheDayAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YPlaylist> DejaVuAsync(YAuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.NeverHeard);
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YPlaylist DejaVu(YAuthStorage storage)
        {
            return DejaVuAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YPlaylist> PremiereAsync(YAuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.RecentTracks);
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YPlaylist Premiere(YAuthStorage storage)
        {
            return PremiereAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YPlaylist> MissedAsync(YAuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.MissedLikes);
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YPlaylist Missed(YAuthStorage storage)
        {
            return MissedAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Алиса
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YPlaylist> AliceAsync(YAuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.Origin);
        }

        /// <summary>
        /// Алиса
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YPlaylist Alice(YAuthStorage storage)
        {
            return MissedAsync(storage).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Подкасты
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<YPlaylist> PodcastsAsync(YAuthStorage storage)
        {
            return await GetPersonalPlaylist(storage, YGeneratedPlaylistType.Podcasts);
        }

        /// <summary>
        /// Подкасты
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public YPlaylist Podcasts(YAuthStorage storage)
        {
            return PodcastsAsync(storage).GetAwaiter().GetResult();
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
        public async Task<YPlaylist> GetAsync(YAuthStorage storage, string user, string kinds)
        {
            return await new YGetPlaylistRequest(storage)
                .Create(user, kinds)
                .GetResponseAsync<YPlaylist>();
        }

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="user">Uid пользователя-владельца плейлиста</param> 
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public YPlaylist Get(YAuthStorage storage, string user, string kinds)
        {
            return GetAsync(storage, user, kinds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Описание плейлиста, для которого будут запрошены треки</param>
        /// <returns></returns>
        public async Task<YPlaylist> GetAsync(YAuthStorage storage, YPlaylist playlist)
        {
            return await new YGetPlaylistRequest(storage)
                .Create(playlist)
                .GetResponseAsync<YPlaylist>();
        }

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Описание плейлиста, для которого будут запрошены треки</param>
        /// <returns></returns>
        public YPlaylist Get(YAuthStorage storage, YPlaylist playlist)
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
        public async Task<YPlaylist> CreateAsync(YAuthStorage storage, string name)
        {
            return await new YPlaylistCreateRequest(storage)
                .Create(name)
                .GetResponseAsync<YPlaylist>();
        }

        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public YPlaylist Create(YAuthStorage storage, string name)
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
        public async Task<YPlaylist> RenameAsync(YAuthStorage storage, string kinds, string name)
        {
            return await new YPlaylistRenameRequest(storage)
                .Create(kinds, name)
                .GetResponseAsync<YPlaylist>();
        }

        /// <summary>
        /// Переименование
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Идентификатор плейлиста</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public YPlaylist Rename(YAuthStorage storage, string kinds, string name)
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
        public Task<YPlaylist> RenameAsync(YAuthStorage storage, YPlaylist playlist, string name)
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
        public YPlaylist Rename(YAuthStorage storage, YPlaylist playlist, string name)
        {
            return RenameAsync(storage, playlist.Kind, name).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(YAuthStorage storage, string kinds)
        {
            try {
                await new YPlaylistRemoveRequest(storage)
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
        public bool Delete(YAuthStorage storage, string kinds)
        {
            return DeleteAsync(storage, kinds).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(YAuthStorage storage, YPlaylist playlist)
        {
            return DeleteAsync(storage, playlist.Kind);
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public bool Delete(YAuthStorage storage, YPlaylist playlist)
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
        public async Task<YPlaylist> InsertTracksAsync(YAuthStorage storage, YPlaylist playlist, List<YTrack> tracks)
        {
            return await ChangePlaylist(storage, playlist, new List<YPlaylistChange> {
                    new YPlaylistChange {
                        Operation = YPlaylistChangeType.Insert,
                        At = 0,
                        Tracks = tracks.Select(t => t.GetKey()).ToList()
                    }
                })
                .ContinueWith(p => Get(storage, p.Result));
        }

        /// <summary>
        /// Добавление трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="tracks">Треки для добавления</param>
        /// <returns></returns>
        public YPlaylist InsertTracks(YAuthStorage storage, YPlaylist playlist, List<YTrack> tracks)
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
        public async Task<YPlaylist> DeleteTrackAsync(YAuthStorage storage, YPlaylist playlist, List<YTrack> tracks)
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
        public YPlaylist DeleteTrack(YAuthStorage storage, YPlaylist playlist, List<YTrack> tracks)
        {
            return DeleteTrackAsync(storage, playlist, tracks).GetAwaiter().GetResult();
        }

        #endregion Операции над плейлистами

        #endregion Main function
    }
}