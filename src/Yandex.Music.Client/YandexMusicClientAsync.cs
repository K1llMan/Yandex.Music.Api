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
using Yandex.Music.Api.Models.Library;
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
        public async Task<bool> Authorize(string token)
        {
            await api.User.AuthorizeAsync(storage, token);
            return storage.IsAuthorized;
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

        /// <summary>
        /// Получение информации о пользователе через логин Яндекса
        /// </summary>
        public Task<YLoginInfo> GetLoginInfo()
        {
            return api.User.GetLoginInfoAsync(storage);
        }

        #endregion Авторизация

        #region Треки

        /// <summary>
        /// Получение трека
        /// </summary>
        /// <param name="id">id трека</param>
        /// <returns></returns>
        public async Task<YTrack> GetTrack(string id)
        {
            return (await api.Track.GetAsync(storage, id))
                .Result.FirstOrDefault();
        }

        /// <summary>
        /// Получение списка треков
        /// </summary>
        /// <param name="ids">Список id треков</param>
        /// <returns></returns>
        public async Task<List<YTrack>> GetTracks(IEnumerable<string> ids)
        {
            return (await api.Track.GetAsync(storage, ids))
                .Result;
        }

        #endregion Треки

        #region Альбомы

        /// <summary>
        /// Получение альбома
        /// </summary>
        /// <param name="id">id альбома</param>
        /// <returns></returns>
        public async Task<YAlbum> GetAlbum(string id)
        {
            return (await api.Album.GetAsync(storage, id))
                .Result;
        }

        /// <summary>
        /// Получение списка альбомов
        /// </summary>
        /// <param name="ids">Список id альбомов</param>
        /// <returns></returns>
        public async Task<List<YAlbum>> GetAlbums(IEnumerable<string> ids)
        {
            return (await api.Album.GetAsync(storage, ids))
                .Result;
        }

        #endregion Альбомы

        #region Главная страница

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="blocks">Типы запрашиваемых блоков</param>
        /// <returns></returns>
        public async Task<YLanding> GetLanding(params YLandingBlockType[] blocks)
        {
            return (await api.Landing.GetAsync(storage, blocks))
                .Result;
        }

        /// <summary>
        /// Получение ленты
        /// </summary>
        /// <returns></returns>
        public async Task<YFeed> Feed()
        {
            return (await api.Landing.GetFeedAsync(storage))
                .Result;
        }

        #endregion Главная страница

        #region Исполнители

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="id">id исполнителя</param>
        /// <returns></returns>
        public async Task<YArtistBriefInfo> GetArtist(string id)
        {
            return (await api.Artist.GetAsync(storage, id))
                .Result;
        }

        /// <summary>
        /// Получение списка исполнителей
        /// </summary>
        /// <param name="ids">Список id исполнителей</param>
        /// <returns></returns>
        public async Task<List<YArtist>> GetArtists(IEnumerable<string> ids)
        {
            return (await api.Artist.GetAsync(storage, ids))
                .Result;
        }

        #endregion Исполнители

        #region Плейлисты

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="id">id плейлиста</param>
        /// <returns></returns>
        public async Task<YPlaylist> GetPlaylist(string user, string id)
        {
            return (await api.Playlist.GetAsync(storage, user, id))
                .Result;
        }

        /// <summary>
        /// Получение списка плейлистов
        /// </summary>
        /// <param name="ids">Список кортежей с пользователем и id плейлиста</param>
        /// <returns></returns>
        public async Task<List<YPlaylist>> GetPlaylists(IEnumerable<(string user, string id)> ids)
        {
            return (await api.Playlist.GetAsync(storage, ids))
                .Result;
        }

        /// <summary>
        /// Получение списка персональных плейлистов
        /// </summary>
        /// <returns></returns>
        public async Task<List<YPlaylist>> GetPersonalPlaylists()
        {
            List<YResponse<YPlaylist>> playlists = await api.Playlist.GetPersonalPlaylistsAsync(storage);
            return playlists
                .Select(r => r.Result)
                .ToList();
        }

        /// <summary>
        /// Избранное
        /// </summary>
        /// <returns></returns>
        public async Task<List<YPlaylist>> GetFavorites()
        {
            return (await api.Playlist.FavoritesAsync(storage))
                .Result;
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <returns></returns>
        public async Task<YPlaylist> GetDejaVu()
        {
            return (await api.Playlist.DejaVuAsync(storage))
                .Result;
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <returns></returns>
        public async Task<YPlaylist> GetMissed()
        {
            return (await api.Playlist.MissedAsync(storage))
                .Result;
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <returns></returns>
        public async Task<YPlaylist> GetOfTheDay()
        {
            return (await api.Playlist.OfTheDayAsync(storage))
                .Result;
        }

        /// <summary>
        /// Кинопоиск
        /// </summary>
        /// <returns></returns>
        public async Task<YPlaylist> GetKinopoisk()
        {
            return (await api.Playlist.KinopoiskAsync(storage))
                .Result;
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <returns></returns>
        public async Task<YPlaylist> GetPremiere()
        {
            return (await api.Playlist.PremiereAsync(storage))
                .Result;
        }

        /// <summary>
        /// Создать плейлист
        /// </summary>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public async Task<YPlaylist> CreatePlaylist(string name)
        {
            return (await api.Playlist.CreateAsync(storage, name))
                .Result;
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
        public async Task<YSearch> Search(string searchText, YSearchType searchType, int page = 0, int pageSize = 20)
        {
            return (await api.Search.SearchAsync(storage, searchText, searchType, page, pageSize))
                .Result;
        }

        /// <summary>
        /// Подсказка для поиска
        /// </summary>
        /// <param name="searchText">Поисковый запрос</param>
        /// <returns></returns>
        public async Task<YSearchSuggest> GetSearchSuggestions(string searchText)
        {
            return (await api.Search.SuggestAsync(storage, searchText))
                .Result;
        }

        #endregion Поиск

        #region Библиотека

        /// <summary>
        /// Получение лайкнутых треков
        /// </summary>
        /// <returns></returns>
        public async Task<List<YTrack>> GetLikedTracks()
        {
            YResponse<YLibraryTracks> likes = await api.Library.GetLikedTracksAsync(storage);
            string[] ids = likes
                .Result
                .Library
                .Tracks
                .Select(t => t.Id)
                .ToArray();

            return (await api.Track.GetAsync(storage, ids))
                .Result;
        }

        /// <summary>
        /// Получение дизлайкнутых треков
        /// </summary>
        /// <returns></returns>
        public async Task<List<YTrack>> GetDislikedTracks()
        {
            YResponse<YLibraryTracks> likes = await api.Library.GetDislikedTracksAsync(storage);
            string[] ids = likes
                .Result
                .Library
                .Tracks
                .Select(t => t.Id)
                .ToArray();

            return (await api.Track.GetAsync(storage, ids))
                .Result;
        }

        /// <summary>
        /// Получение лайкнутых альбомов
        /// </summary>
        /// <returns></returns>
        public async Task<List<YAlbum>> GetLikedAlbums()
        {
            YResponse<List<YLibraryAlbum>> albums = await api.Library.GetLikedAlbumsAsync(storage);
            string[] ids = albums
                .Result
                .Select(t => t.Id)
                .ToArray();

            return (await api.Album.GetAsync(storage, ids))
                .Result;
        }

        /// <summary>
        /// Получение лайкнутых исполнителей
        /// </summary>
        /// <returns></returns>
        public async Task<List<YArtist>> GetLikedArtists()
        {
            YResponse<List<YArtist>> artists = await api.Library.GetLikedArtistsAsync(storage);
            string[] ids = artists
                .Result
                .Select(t => t.Id)
                .ToArray();

            return (await api.Artist.GetAsync(storage, ids))
                .Result;
        }

        /// <summary>
        /// Получение дизлайкнутых исполнителей
        /// </summary>
        /// <returns></returns>
        public async Task<List<YArtist>> GetDislikedArtists()
        {
            YResponse<List<YArtist>> artists = await api.Library.GetDislikedArtistsAsync(storage);
            string[] ids = artists
                .Result
                .Select(t => t.Id)
                .ToArray();

            return (await api.Artist.GetAsync(storage, ids))
                .Result;
        }

        /// <summary>
        /// Получение лайкнутых плейлистов
        /// </summary>
        /// <returns></returns>
        public async Task<List<YPlaylist>> GetLikedPlaylists()
        {
            YResponse<List<YLibraryPlaylists>> playlists = await api.Library.GetLikedPlaylistsAsync(storage);
            (string, string)[] ids = playlists
                .Result
                .Select(a => (a.Playlist.Uid, a.Playlist.Kind))
                .ToArray();
            return (await api.Playlist.GetAsync(storage, ids))
                .Result;
        }

        #endregion Библиотека

        #region Радио

        /// <summary>
        /// Получение списка рекомендованных радиостанций
        /// </summary>
        /// <returns></returns>
        public async Task<List<YStation>> GetRadioDashboard()
        {
            return (await api.Radio.GetStationsDashboardAsync(storage))
                .Result.Stations;
        }

        /// <summary>
        /// Получение списка радиостанций
        /// </summary>
        /// <returns></returns>
        public async Task<List<YStation>> GetRadioStations()
        {
            return (await api.Radio.GetStationsAsync(storage))
                .Result;
        }

        /// <summary>
        /// Получение информации о радиостанции
        /// </summary>
        /// <param name="id">Идентификатор станции</param>
        /// <returns></returns>
        public async Task<YStation> GetRadioStation(YStationId id)
        {
            return (await api.Radio.GetStationAsync(storage, id))
                .Result.FirstOrDefault();
        }

        #endregion Радио

        #region Очереди

        /// <summary>
        /// Получение всех очередей треков с разных устройств для синхронизации между ними
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public async Task<YQueueItemsContainer> QueuesList(string device = null)
        {
            return (await api.Queue.ListAsync(storage, device))
                .Result;
        }

        /// <summary>
        /// Получение очереди
        /// </summary>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <returns></returns>
        public async Task<YQueue> GetQueue(string queueId)
        {
            return (await api.Queue.GetAsync(storage, queueId))
                .Result;
        }

        /// <summary>
        /// Создание новой очереди треков
        /// </summary>
        /// <param name="queue">Очередь треков</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public async Task<YNewQueue> CreateQueue(YQueue queue, string device = null)
        {
            return (await api.Queue.CreateAsync(storage, queue, device))
                .Result;
        }

        /// <summary>
        /// Установка текущего индекса проигрываемого трека в очереди треков
        /// </summary>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <param name="currentIndex">Текущий индекс</param>
        /// <param name="isInteractive">Флаг интерактивности</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public async Task<YUpdatedQueue> QueueUpdatePosition(string queueId, int currentIndex, bool isInteractive, string device = null)
        {
            return (await api.Queue.UpdatePositionAsync(storage, queueId, currentIndex, isInteractive, device))
                .Result;
        }

        #endregion Очереди

        #endregion Основные функции
    }
}
