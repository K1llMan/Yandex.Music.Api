using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Models.Landing.Entity.Entities;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Track;
using Yandex.Music.Api.Requests.Playlist;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для взамодействия с плейлистами
    /// </summary>
    public partial class YPlaylistAPI : YCommonAPI
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
            List<YResponse<YPlaylist>> list = await GetPersonalPlaylistsAsync(storage);
            return list.FirstOrDefault(e => string.Equals(e.Result.GeneratedPlaylistType, type.ToString(), StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Изменение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="changes">Список изменений</param>
        /// <returns>Плейлист после изменений</returns>
        private Task<YResponse<YPlaylist>> ChangePlaylist(AuthStorage storage, YPlaylist playlist, IEnumerable<YPlaylistChange> changes)
        {
            return new YPlaylistChangeBuilder(api, storage)
                .Build((playlist, changes))
                .GetResponseAsync();
        }

        private IEnumerable<YTrack> RemoveIdentical(IEnumerable<YTrack> tracks)
        {
            return tracks.Distinct();
        }

        #endregion Вспомогательные функции

        #region Основные функции

        public YPlaylistAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        #region Список с главной

        /// <summary>
        /// Получение списка персональных плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public async Task<List<YResponse<YPlaylist>>> GetPersonalPlaylistsAsync(AuthStorage storage)
        {
            YResponse<YLanding> landing = await api.Landing.GetAsync(storage, YLandingBlockType.PersonalPlaylists);

            IEnumerable<Task<YResponse<YPlaylist>>> tasks = landing
                .Result
                .Blocks
                .FirstOrDefault(b => b.Type == YLandingBlockType.PersonalPlaylists)
                ?.Entities
                .Select(e => api.Playlist.GetAsync(storage, ((YLandingEntityPersonalPlaylist)e).Data?.Data));

            return tasks == null
                ? new List<YResponse<YPlaylist>>()
                : new List<YResponse<YPlaylist>>(await Task.WhenAll(tasks));
        }

        #endregion Список с главной

        #region Стандартные плейлисты

        /// <summary>
        /// Избранное
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<List<YPlaylist>>> FavoritesAsync(AuthStorage storage)
        {
            return new YGetPlaylistFavoritesBuilder(api, storage)
                .Build(null)
                .GetResponseAsync();
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> OfTheDayAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.PlaylistOfTheDay);
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> DejaVuAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.NeverHeard);
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> PremiereAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.RecentTracks);
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> MissedAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.MissedLikes);
        }

        /// <summary>
        /// Кинопоиск
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> KinopoiskAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.Kinopoisk);
        }

        #endregion Стандартные плейлисты

        #region Получение плейлиста

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="user">Uid пользователя-владельца плейлиста</param>
        /// <param name="kind">Тип</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, string user, string kind)
        {
            return new YGetPlaylistBuilder(api, storage)
                .Build((user, kind))
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="ids">Список пар пользователь:тип</param>
        /// <returns></returns>
        public Task<YResponse<List<YPlaylist>>> GetAsync(AuthStorage storage, IEnumerable<(string user, string kind)> ids)
        {
            return new YGetPlaylistsBuilder(api, storage)
                .Build(ids)
                .GetResponseAsync();
        }

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Описание плейлиста, для которого будут запрошены треки</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, YPlaylist playlist)
        {
            return new YGetPlaylistBuilder(api, storage)
                .Build((playlist.Owner.Uid, playlist.Kind))
                .GetResponseAsync();
        }

        #endregion Получение плейлиста

        #region Операции над плейлистами

        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> CreateAsync(AuthStorage storage, string name)
        {
            return new YPlaylistCreateBuilder(api, storage)
                .Build(name)
                .GetResponseAsync();
        }

        /// <summary>
        /// Переименование
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Идентификатор плейлиста</param>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> RenameAsync(AuthStorage storage, string kinds, string name)
        {
            return new YPlaylistRenameBuilder(api, storage)
                .Build((kinds, name))
                .GetResponseAsync();
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
        /// Удаление
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="kinds">Тип</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(AuthStorage storage, string kinds)
        {
            try {
                await new YPlaylistRemoveBuilder(api, storage)
                    .Build(kinds)
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
        /// <param name="playlist">Плейлист</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(AuthStorage storage, YPlaylist playlist)
        {
            return DeleteAsync(storage, playlist.Kind);
        }

        /// <summary>
        /// Добавление трека
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="tracks">Треки для добавления</param>
        /// <returns></returns>
        public async Task<YResponse<YPlaylist>> InsertTracksAsync(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)
        {
            YResponse<YPlaylist> change = await ChangePlaylist(storage, playlist, new List<YPlaylistChange> { 
                    new() {
                        Operation = YPlaylistChangeType.Insert, 
                        At = 0, 
                        Tracks = tracks.Select(t => t.GetKey())
                    }
                });

            return await GetAsync(storage, change.Result);
        }

        /// <summary>
        /// Удаление треков
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlist">Плейлист</param>
        /// <param name="tracks">Треки для удаления</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> DeleteTracksAsync(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)
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

            return ChangePlaylist(storage, playlist, changes);
        }

        #endregion Операции над плейлистами

        #endregion Основные функции
    }
}