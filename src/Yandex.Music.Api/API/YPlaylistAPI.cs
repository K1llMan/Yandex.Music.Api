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
    public class YPlaylistAPI : YCommonAPI
    {
        #region Вспомогательные функции

        /// <summary>
        /// Получение персональных плейлистов
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="type">Тип</param>
        /// <returns>Плейлист</returns>
        private Task<YResponse<YPlaylist>> GetPersonalPlaylist(AuthStorage storage, YGeneratedPlaylistType type)
        {
            return GetPersonalPlaylistsAsync(storage)
                .ContinueWith(list => {
                    return list.GetAwaiter().GetResult()
                        .FirstOrDefault(e => e.Result.GeneratedPlaylistType == type);
                });
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
        public Task<List<YResponse<YPlaylist>>> GetPersonalPlaylistsAsync(AuthStorage storage)
        {
            return api.Landing.GetAsync(storage, YLandingBlockType.PersonalPlaylists)
                .ContinueWith(landing => landing.GetAwaiter().GetResult()
                    .Result
                    .Blocks
                    .FirstOrDefault(b => b.Type == YLandingBlockType.PersonalPlaylists)
                    ?.Entities
                    .Select(e => api.Playlist.Get(storage, ((YLandingEntityPersonalPlaylist)e).Data?.Data))
                    .ToList());
        }

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
        public Task<YResponse<List<YPlaylist>>> FavoritesAsync(AuthStorage storage)
        {
            return new YGetPlaylistFavoritesBuilder(api, storage)
                .Build(null)
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
        public Task<YResponse<YPlaylist>> OfTheDayAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.PlaylistOfTheDay);
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
        public Task<YResponse<YPlaylist>> DejaVuAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.NeverHeard);
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
        public Task<YResponse<YPlaylist>> PremiereAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.RecentTracks);
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
        public Task<YResponse<YPlaylist>> MissedAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.MissedLikes);
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
        /// Подкасты
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> PodcastsAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.Podcasts);
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
        /// Кинопоиск
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> KinopoiskAsync(AuthStorage storage)
        {
            return GetPersonalPlaylist(storage, YGeneratedPlaylistType.Kinopoisk);
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
        /// <param name="kind">Тип</param>
        /// <returns></returns>
        public Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, string user, string kind)
        {
            return new YGetPlaylistBuilder(api, storage)
                .Build((user, kind))
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
        public Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, YPlaylist playlist)
        {
            return new YGetPlaylistBuilder(api, storage)
                .Build((playlist.Owner.Uid, playlist.Kind))
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
        public Task<YResponse<YPlaylist>> CreateAsync(AuthStorage storage, string name)
        {
            return new YPlaylistCreateBuilder(api, storage)
                .Build(name)
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
        public Task<bool> DeleteAsync(AuthStorage storage, string kinds)
        {
            try {
                return new YPlaylistRemoveBuilder(api, storage)
                    .Build(kinds)
                    .GetResponseAsync()
                    .ContinueWith(r => true);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }

            return Task.FromResult(false);
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
        public Task<YResponse<YPlaylist>> InsertTracksAsync(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)
        {
            return ChangePlaylist(storage, playlist, new List<YPlaylistChange> { 
                    new() {
                        Operation = YPlaylistChangeType.Insert, 
                        At = 0, 
                        Tracks = tracks.Select(t => t.GetKey())
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