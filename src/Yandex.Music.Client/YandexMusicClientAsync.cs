using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Yandex.Music.Api;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Common.Debug;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Feed;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Queue;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Models.Search;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client
{
    /// <summary>
    /// Асинхронный клиент Яндекс.Музыка
    /// </summary>
    public class YandexMusicClientAsync
    {
        #region Поля

        private YandexMusicApi api;
        private AuthStorage storage;

        #endregion Поля

        #region Свойства

        /// <summary>
        /// Аккаунт
        /// </summary>
        public YAccount Account => storage.User;

        /// <summary>
        /// Флаг авторизации
        /// </summary>
        public bool IsAuthorized => storage.IsAuthorized;

        #endregion Свойства

        #region Основные функции

        public YandexMusicClientAsync(DebugSettings settings = null)
        {
            api = new YandexMusicApi();
            storage = new AuthStorage(settings);
        }

        #region Авторизация

        /// <summary>
        /// Авторизация по токену
        /// </summary>
        /// <param name="token">Токен авторизации</param>
        /// <returns></returns>
        public Task<bool> Authorize(string token)
        {
            return api.User.AuthorizeAsync(storage, token)
                .ContinueWith(_ => storage.IsAuthorized);
        }

        /// <summary>
        /// Создание сеанса и получение доступных методов авторизации
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <returns></returns>
        public Task<YAuthTypes> CreateAuthSession(string userName)
        {
            return api.User.CreateAuthSessionAsync(storage, userName);
        }

        /// <summary>
        /// Получение ссылки на QR-код
        /// </summary>
        /// <returns></returns>
        public Task<string> GetAuthQRLink()
        {
            return api.User.GetAuthQRLinkAsync(storage);
        }

        /// <summary>
        /// Авторизация по QR-коду
        /// </summary>
        /// <returns></returns>
        public Task<YAuthQRStatus> AuthorizeByQR()
        {
            return api.User.AuthorizeByQRAsync(storage);
        }

        /// <summary>
        /// Получение <see cref="YAuthCaptcha"/>
        /// </summary>
        /// <returns></returns>
        public Task<YAuthCaptcha> GetCaptcha()
        {
            return api.User.GetCaptchaAsync(storage);
        }

        /// <summary>
        /// Авторизация по captcha
        /// </summary>
        /// <param name="captcha">Значение captcha</param>
        /// <returns></returns>
        public Task<YAuthBase> AuthorizeByCaptcha(string captcha)
        {
            return api.User.AuthorizeByCaptchaAsync(storage, captcha);
        }

        /// <summary>
        /// Получение письма авторизации на почту пользователя
        /// </summary>
        /// <returns></returns>
        public Task<YAuthLetter> GetAuthLetter()
        {
            return api.User.GetAuthLetterAsync(storage);
        }

        /// <summary>
        /// Авторизация после подтверждения входа через письмо
        /// </summary>
        /// <returns></returns>
        public Task<bool> AuthorizeByLetter()
        {
            return api.User.AuthorizeByLetterAsync(storage);
        }

        /// <summary>
        /// Авторизация с помощью пароля из приложения Яндекс
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public Task<YAuthBase> AuthorizeByAppPassword(string password)
        {
            return api.User.AuthorizeByAppPasswordAsync(storage, password);
        }

        /// <summary>
        /// Получение <see cref="YAccessToken"/> после авторизации с помощью QR, e-mail, пароля из приложения
        /// </summary>
        public Task<YAccessToken> GetAccessToken()
        {
            return api.User.GetAccessTokenAsync(storage);
        }

        #endregion Авторизация

        #region Треки

        /// <summary>
        /// Получение трека
        /// </summary>
        /// <param name="id">id трека</param>
        /// <returns></returns>
        public Task<YTrack> GetTrack(string id)
        {
            return api.Track.GetAsync(storage, id)
                .ContinueWith(t => t.Result.Result.FirstOrDefault());
        }

        /// <summary>
        /// Получение списка треков
        /// </summary>
        /// <param name="ids">Список id треков</param>
        /// <returns></returns>
        public Task<List<YTrack>> GetTracks(IEnumerable<string> ids)
        {
            return api.Track.GetAsync(storage, ids)
                .ContinueWith(t => t.Result.Result);
        }

        #endregion Треки

        #region Альбомы

        /// <summary>
        /// Получение альбома
        /// </summary>
        /// <param name="id">id альбома</param>
        /// <returns></returns>
        public Task<YAlbum> GetAlbum(string id)
        {
            return api.Album.GetAsync(storage, id)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Получение списка альбомов
        /// </summary>
        /// <param name="ids">Список id альбомов</param>
        /// <returns></returns>
        public Task<List<YAlbum>> GetAlbums(IEnumerable<string> ids)
        {
            return api.Album.GetAsync(storage, ids)
                .ContinueWith(t => t.Result.Result);
        }

        #endregion Альбомы

        #region Главная страница

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="blocks">Типы запрашиваемых блоков</param>
        /// <returns></returns>
        public Task<YLanding> GetLanding(params YLandingBlockType[] blocks)
        {
            return api.Landing.GetAsync(storage, blocks)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Получение ленты
        /// </summary>
        /// <returns></returns>
        public Task<YFeed> Feed()
        {
            return api.Landing.GetFeedAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        #endregion Главная страница

        #region Исполнители

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="id">id исполнителя</param>
        /// <returns></returns>
        public Task<YArtistBriefInfo> GetArtist(string id)
        {
            return api.Artist.GetAsync(storage, id)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Получение списка исполнителей
        /// </summary>
        /// <param name="ids">Список id исполнителей</param>
        /// <returns></returns>
        public Task<List<YArtist>> GetArtists(IEnumerable<string> ids)
        {
            return api.Artist.GetAsync(storage, ids)
                .ContinueWith(t => t.Result.Result);
        }

        #endregion Исполнители

        #region Плейлисты

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="id">id плейлиста</param>
        /// <returns></returns>
        public Task<YPlaylist> GetPlaylist(string user, string id)
        {
            return api.Playlist.GetAsync(storage, user, id)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Получение списка плейлистов
        /// </summary>
        /// <param name="ids">Список кортежей с пользователем и id плейлиста</param>
        /// <returns></returns>
        public Task<List<YPlaylist>> GetPlaylists(IEnumerable<(string user, string id)> ids)
        {
            return api.Playlist.GetAsync(storage, ids)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Получение списка персональных плейлистов
        /// </summary>
        /// <returns></returns>
        public Task<List<YPlaylist>> GetPersonalPlaylists()
        {
            return api.Playlist.GetPersonalPlaylistsAsync(storage)
                .ContinueWith(t => t.Result
                    .Select(r => r.Result)
                    .ToList()
                );
        }

        /// <summary>
        /// Избранное
        /// </summary>
        /// <returns></returns>
        public Task<List<YPlaylist>> GetFavorites()
        {
            return api.Playlist.FavoritesAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <returns></returns>
        public Task<YPlaylist> GetDejaVu()
        {
            return api.Playlist.DejaVuAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <returns></returns>
        public Task<YPlaylist> GetMissed()
        {
            return api.Playlist.MissedAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <returns></returns>
        public Task<YPlaylist> GetOfTheDay()
        {
            return api.Playlist.OfTheDayAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Подкасты
        /// </summary>
        /// <returns></returns>
        public Task<YPlaylist> GetPodcasts()
        {
            return api.Playlist.PodcastsAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Кинопоиск
        /// </summary>
        /// <returns></returns>
        public Task<YPlaylist> GetKinopoisk()
        {
            return api.Playlist.KinopoiskAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <returns></returns>
        public Task<YPlaylist> GetPremiere()
        {
            return api.Playlist.PremiereAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Создать плейлист
        /// </summary>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public Task<YPlaylist> CreatePlaylist(string name)
        {
            return api.Playlist.CreateAsync(storage, name)
                .ContinueWith(t => t.Result.Result);
        }

        #endregion Плейлисты

        #region Поиск

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="searchText">Поисковый запрос</param>
        /// <param name="searchType">Тип поиска</param>
        /// <param name="page">Страница</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YSearch> Search(string searchText, YSearchType searchType, int page = 0, int pageSize = 20)
        {
            return api.Search.SearchAsync(storage, searchText, searchType, page, pageSize)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Подсказка для поиска
        /// </summary>
        /// <param name="searchText">Поисковый запрос</param>
        /// <returns></returns>
        public Task<YSearchSuggest> GetSearchSuggestions(string searchText)
        {
            return api.Search.SuggestAsync(storage, searchText)
                .ContinueWith(t => t.Result.Result);
        }

        #endregion Поиск

        #region Библиотека

        /// <summary>
        /// Получение лайкнутых треков
        /// </summary>
        /// <returns></returns>
        public Task<List<YTrack>> GetLikedTracks()
        {
            return api.Library.GetLikedTracksAsync(storage)
                .ContinueWith(task => task.Result
                    .Result
                    .Library
                    .Tracks
                    .Select(t => t.Id)
                    .ToArray()
                )
                .ContinueWith(task => api.Track.Get(storage, task.Result))
                .ContinueWith(task => task.Result.Result);
        }

        /// <summary>
        /// Получение дизлайкнутых треков
        /// </summary>
        /// <returns></returns>
        public Task<List<YTrack>> GetDislikedTracks()
        {
            return api.Library.GetDislikedTracksAsync(storage)
                .ContinueWith(task => task.Result
                    .Result
                    .Library
                    .Tracks
                    .Select(t => t.Id)
                    .ToArray()
                )
                .ContinueWith(task => api.Track.Get(storage, task.Result))
                .ContinueWith(task => task.Result.Result);
        }

        /// <summary>
        /// Получение лайкнутых альбомов
        /// </summary>
        /// <returns></returns>
        public Task<List<YAlbum>> GetLikedAlbums()
        {
            return api.Library.GetLikedAlbumsAsync(storage)
                .ContinueWith(task => task.Result
                    .Result
                    .Select(t => t.Id)
                    .ToArray()
                )
                .ContinueWith(task => api.Album.Get(storage, task.Result))
                .ContinueWith(task => task.Result.Result);
        }

        /// <summary>
        /// Получение лайкнутых исполнителей
        /// </summary>
        /// <returns></returns>
        public Task<List<YArtist>> GetLikedArtists()
        {
            return api.Library.GetLikedArtistsAsync(storage)
                .ContinueWith(task => task.Result
                    .Result
                    .Select(t => t.Id)
                    .ToArray()
                )
                .ContinueWith(task => api.Artist.Get(storage, task.Result))
                .ContinueWith(task => task.Result.Result);
        }

        /// <summary>
        /// Получение дизлайкнутых исполнителей
        /// </summary>
        /// <returns></returns>
        public Task<List<YArtist>> GetDislikedArtists()
        {
            return api.Library.GetDislikedArtistsAsync(storage)
                .ContinueWith(task => task.Result
                    .Result
                    .Select(t => t.Id)
                    .ToArray()
                )
                .ContinueWith(task => api.Artist.Get(storage, task.Result))
                .ContinueWith(task => task.Result.Result);
        }

        /// <summary>
        /// Получение лайкнутых плейлистов
        /// </summary>
        /// <returns></returns>
        public Task<List<YPlaylist>> GetLikedPlaylists()
        {
            return api.Library.GetLikedPlaylistsAsync(storage)
                .ContinueWith(task => task.Result
                    .Result
                    .Select(a => (a.Playlist.Uid, a.Playlist.Kind))
                    .ToArray()
                )
                .ContinueWith(task => api.Playlist.Get(storage, task.Result))
                .ContinueWith(task => task.Result.Result);
        }

        #endregion Библиотека

        #region Радио

        /// <summary>
        /// Получение списка рекомендованных радиостанций
        /// </summary>
        /// <returns></returns>
        public Task<List<YStation>> GetRadioDashboard()
        {
            return api.Radio.GetStationsDashboardAsync(storage)
                .ContinueWith(t => t.Result.Result.Stations);
        }

        /// <summary>
        /// Получение списка радиостанций
        /// </summary>
        /// <returns></returns>
        public Task<List<YStation>> GetRadioStations()
        {
            return api.Radio.GetStationsAsync(storage)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Получение информации о радиостанции
        /// </summary>
        /// <param name="id">Идентификатор станции</param>
        /// <returns></returns>
        public Task<YStation> GetRadioStation(YStationId id)
        {
            return api.Radio.GetStationAsync(storage, id)
                .ContinueWith(t => t.Result.Result.FirstOrDefault());
        }

        #endregion Радио

        #region Очереди

        /// <summary>
        /// Получение всех очередей треков с разных устройств для синхронизации между ними
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public Task<YQueueItemsContainer> QueuesList(string device = null)
        {
            return api.Queue.ListAsync(storage, device)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Получение очереди
        /// </summary>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <returns></returns>
        public Task<YQueue> GetQueue(string queueId)
        {
            return api.Queue.GetAsync(storage, queueId)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Создание новой очереди треков
        /// </summary>
        /// <param name="queue">Очередь треков</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public Task<YNewQueue> CreateQueue(YQueue queue, string device = null)
        {
            return api.Queue.CreateAsync(storage, queue, device)
                .ContinueWith(t => t.Result.Result);
        }

        /// <summary>
        /// Установка текущего индекса проигрываемого трека в очереди треков
        /// </summary>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <param name="currentIndex">Текущий индекс</param>
        /// <param name="isInteractive">Флаг интерактивности</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public Task<YUpdatedQueue> QueueUpdatePosition(string queueId, int currentIndex, bool isInteractive, string device = null)
        {
            return api.Queue.UpdatePositionAsync(storage, queueId, currentIndex, isInteractive, device)
                .ContinueWith(t => t.Result.Result);
        }

        #endregion Очереди

        #endregion Основные функции
    }
}
