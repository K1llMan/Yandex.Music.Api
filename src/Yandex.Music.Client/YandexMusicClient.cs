using System.Collections.Generic;
using System.Linq;

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
    /// Клиент Яндекс.Музыка
    /// </summary>
    public class YandexMusicClient
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

        public YandexMusicClient(DebugSettings settings = null)
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
        public bool Authorize(string token)
        {
            api.User.Authorize(storage, token);

            return storage.IsAuthorized;
        }

        /// <summary>
        /// Создание сеанса и получение доступных методов авторизации
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        public YAuthTypes CreateAuthSession(string userName)
        {
            return api.User.CreateAuthSession(storage, userName);
        }

        /// <summary>
        /// Получение ссылки на QR-код
        /// </summary>
        /// <returns></returns>
        public string GetAuthQRLink()
        {
            return api.User.GetAuthQRLink(storage);
        }

        /// <summary>
        /// Авторизация по QR-коду
        /// </summary>
        /// <returns></returns>
        public YAuthQRStatus AuthorizeByQR()
        {
            return api.User.AuthorizeByQR(storage);
        }

        /// <summary>
        /// Получение <see cref="YAuthCaptcha"/>
        /// </summary>
        /// <returns></returns>
        public YAuthCaptcha GetCaptcha()
        {
            return api.User.GetCaptcha(storage);
        }

        /// <summary>
        /// Авторизация по captcha
        /// </summary>
        /// <param name="captcha">Значение captcha</param>
        /// <returns></returns>
        public YAuthBase AuthorizeByCaptcha(string captcha)
        {
            return api.User.AuthorizeByCaptcha(storage, captcha);
        }

        /// <summary>
        /// Получение письма авторизации на почту пользователя
        /// </summary>
        /// <returns></returns>
        public YAuthLetter GetAuthLetter()
        {
            return api.User.GetAuthLetter(storage);
        }

        /// <summary>
        /// Авторизация после подтверждения входа через письмо
        /// </summary>
        /// <returns></returns>
        public bool AuthorizeByLetter()
        {
            return api.User.AuthorizeByLetter(storage);
        }

        /// <summary>
        /// Авторизация с помощью пароля из приложения Яндекс
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public YAuthBase AuthorizeByAppPassword(string password)
        {
            return api.User.AuthorizeByAppPassword(storage, password);
        }

        /// <summary>
        /// Получение <see cref="YAccessToken"/> после авторизации с помощью QR, e-mail, пароля из приложения
        /// </summary>
        public YAccessToken GetAccessToken()
        {
            return api.User.GetAccessToken(storage);
        }

        /// <summary>
        /// Получение информации о пользователе через логин Яндекса
        /// </summary>
        public YLoginInfo GetLoginInfo()
        {
            return api.User.GetLoginInfo(storage);
        }

        #endregion Авторизация

        #region Треки

        /// <summary>
        /// Получение трека
        /// </summary>
        /// <param name="id">id трека</param>
        /// <returns></returns>
        public YTrack GetTrack(string id)
        {
            return api.Track.Get(storage, id).Result.FirstOrDefault();
        }

        /// <summary>
        /// Получение списка треков
        /// </summary>
        /// <param name="ids">Список id треков</param>
        /// <returns></returns>
        public List<YTrack> GetTracks(IEnumerable<string> ids)
        {
            return api.Track.Get(storage, ids).Result;
        }

        #endregion Треки

        #region Альбомы

        /// <summary>
        /// Получение альбома
        /// </summary>
        /// <param name="id">id альбома</param>
        /// <returns></returns>
        public YAlbum GetAlbum(string id)
        {
            return api.Album.Get(storage, id).Result;
        }

        /// <summary>
        /// Получение списка альбомов
        /// </summary>
        /// <param name="ids">Список id альбомов</param>
        /// <returns></returns>
        public List<YAlbum> GetAlbums(IEnumerable<string> ids)
        {
            return api.Album.Get(storage, ids).Result;
        }

        #endregion Альбомы

        #region Главная страница

        /// <summary>
        /// Получение персональных списков
        /// </summary>
        /// <param name="blocks">Типы запрашиваемых блоков</param>
        /// <returns></returns>
        public YLanding GetLanding(params YLandingBlockType[] blocks)
        {
            return api.Landing.Get(storage, blocks).Result;
        }

        /// <summary>
        /// Получение ленты
        /// </summary>
        /// <returns></returns>
        public YFeed Feed()
        {
            return api.Landing.GetFeed(storage).Result;
        }

        #endregion Главная страница

        #region Исполнители

        /// <summary>
        /// Получение исполнителя
        /// </summary>
        /// <param name="id">id исполнителя</param>
        /// <returns></returns>
        public YArtistBriefInfo GetArtist(string id)
        {
            return api.Artist.Get(storage, id).Result;
        }

        /// <summary>
        /// Получение списка исполнителей
        /// </summary>
        /// <param name="ids">Список id исполнителей</param>
        /// <returns></returns>
        public List<YArtist> GetArtists(IEnumerable<string> ids)
        {
            return api.Artist.Get(storage, ids).Result;
        }

        #endregion Исполнители

        #region Плейлисты

        /// <summary>
        /// Получение плейлиста
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <param name="id">id плейлиста</param>
        /// <returns></returns>
        public YPlaylist GetPlaylist(string user, string id)
        {
            return api.Playlist.Get(storage, user, id).Result;
        }

        /// <summary>
        /// Получение списка плейлистов
        /// </summary>
        /// <param name="ids">Список кортежей с пользователем и id плейлиста</param>
        /// <returns></returns>
        public List<YPlaylist> GetPlaylists(IEnumerable<(string user, string id)> ids)
        {
            return api.Playlist.Get(storage, ids).Result;
        }

        /// <summary>
        /// Получение списка персональных плейлистов
        /// </summary>
        /// <returns></returns>
        public List<YPlaylist> GetPersonalPlaylists()
        {
            return api.Playlist.GetPersonalPlaylists(storage)
                .Select(r => r.Result)
                .ToList();
        }

        /// <summary>
        /// Избранное
        /// </summary>
        /// <returns></returns>
        public List<YPlaylist> GetFavorites()
        {
            return api.Playlist.Favorites(storage).Result;
        }

        /// <summary>
        /// Дежавю
        /// </summary>
        /// <returns></returns>
        public YPlaylist GetDejaVu()
        {
            return api.Playlist.DejaVu(storage).Result;
        }

        /// <summary>
        /// Тайник
        /// </summary>
        /// <returns></returns>
        public YPlaylist GetMissed()
        {
            return api.Playlist.Missed(storage).Result;
        }

        /// <summary>
        /// Плейлист дня
        /// </summary>
        /// <returns></returns>
        public YPlaylist GetOfTheDay()
        {
            return api.Playlist.OfTheDay(storage).Result;
        }

        /// <summary>
        /// Кинопоиск
        /// </summary>
        /// <returns></returns>
        public YPlaylist GetKinopoisk()
        {
            return api.Playlist.Kinopoisk(storage).Result;
        }

        /// <summary>
        /// Премьера
        /// </summary>
        /// <returns></returns>
        public YPlaylist GetPremiere()
        {
            return api.Playlist.Premiere(storage).Result;
        }

        /// <summary>
        /// Создать плейлист
        /// </summary>
        /// <param name="name">Заголовок</param>
        /// <returns></returns>
        public YPlaylist CreatePlaylist(string name)
        {
            return api.Playlist.Create(storage, name).Result;
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
        public YSearch Search(string searchText, YSearchType searchType, int page = 0, int pageSize = 20)
        {
            return api.Search.Search(storage, searchText, searchType, page, pageSize).Result;
        }

        /// <summary>
        /// Подсказка для поиска
        /// </summary>
        /// <param name="searchText">Поисковый запрос</param>
        /// <returns></returns>
        public YSearchSuggest GetSearchSuggestions(string searchText)
        {
            return api.Search.Suggest(storage, searchText).Result;
        }

        #endregion Поиск

        #region Библиотека

        /// <summary>
        /// Получение лайкнутых треков
        /// </summary>
        /// <returns></returns>
        public List<YTrack> GetLikedTracks()
        {
            string[] ids = api.Library.GetLikedTracks(storage)
                .Result
                .Library
                .Tracks
                .Select(t => t.Id)
                .ToArray();

            return api.Track.Get(storage, ids).Result;
        }

        /// <summary>
        /// Получение дизлайкнутых треков
        /// </summary>
        /// <returns></returns>
        public List<YTrack> GetDislikedTracks()
        {
            string[] ids = api.Library.GetDislikedTracks(storage)
                .Result
                .Library
                .Tracks
                .Select(t => t.Id)
                .ToArray();

            return api.Track.Get(storage, ids).Result;
        }

        /// <summary>
        /// Получение лайкнутых альбомов
        /// </summary>
        /// <returns></returns>
        public List<YAlbum> GetLikedAlbums()
        {
            string[] ids = api.Library.GetLikedAlbums(storage)
                .Result
                .Select(a => a.Id)
                .ToArray();

            return api.Album.Get(storage, ids).Result;
        }

        /// <summary>
        /// Получение лайкнутых исполнителей
        /// </summary>
        /// <returns></returns>
        public List<YArtist> GetLikedArtists()
        {
            string[] ids = api.Library.GetLikedArtists(storage)
                .Result
                .Select(a => a.Id)
                .ToArray();

            return api.Artist.Get(storage, ids).Result;
        }

        /// <summary>
        /// Получение дизлайкнутых исполнителей
        /// </summary>
        /// <returns></returns>
        public List<YArtist> GetDislikedArtists()
        {
            string[] ids = api.Library.GetDislikedArtists(storage)
                .Result
                .Select(a => a.Id)
                .ToArray();

            return api.Artist.Get(storage, ids).Result;
        }

        /// <summary>
        /// Получение лайкнутых плейлистов
        /// </summary>
        /// <returns></returns>
        public List<YPlaylist> GetLikedPlaylists()
        {
            (string, string)[] ids = api.Library.GetLikedPlaylists(storage)
                .Result
                .Select(a => (a.Playlist.Uid, a.Playlist.Kind))
                .ToArray();

            return api.Playlist.Get(storage, ids).Result;
        }

        #endregion Библиотека

        #region Радио

        /// <summary>
        /// Получение списка рекомендованных радиостанций
        /// </summary>
        /// <returns></returns>
        public List<YStation> GetRadioDashboard()
        {
            return api.Radio.GetStationsDashboard(storage).Result.Stations;
        }

        /// <summary>
        /// Получение списка радиостанций
        /// </summary>
        /// <returns></returns>
        public List<YStation> GetRadioStations()
        {
            return api.Radio.GetStations(storage).Result;
        }

        /// <summary>
        /// Получение информации о радиостанции
        /// </summary>
        /// <param name="id">Идентификатор станции</param>
        /// <returns></returns>
        public YStation GetRadioStation(YStationId id)
        {
            return api.Radio.GetStation(storage, id).Result.FirstOrDefault();
        }

        #endregion Радио

        #region Очереди

        /// <summary>
        /// Получение всех очередей треков с разных устройств для синхронизации между ними
        /// </summary>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public YQueueItemsContainer QueuesList(string device = null)
        {
            return api.Queue.List(storage, device).Result;
        }

        /// <summary>
        /// Получение очереди
        /// </summary>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <returns></returns>
        public YQueue GetQueue(string queueId)
        {
            return api.Queue.Get(storage, queueId).Result;
        }

        /// <summary>
        /// Создание новой очереди треков
        /// </summary>
        /// <param name="queue">Очередь треков</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public YNewQueue CreateQueue(YQueue queue, string device = null)
        {
            return api.Queue.Create(storage, queue, device).Result;
        }

        /// <summary>
        /// Установка текущего индекса проигрываемого трека в очереди треков
        /// </summary>
        /// <param name="queueId">Идентификатор очереди</param>
        /// <param name="currentIndex">Текущий индекс</param>
        /// <param name="isInteractive">Флаг интерактивности</param>
        /// <param name="device">Устройство</param>
        /// <returns></returns>
        public YUpdatedQueue QueueUpdatePosition(string queueId, int currentIndex, bool isInteractive, string device = null)
        {
            return api.Queue.UpdatePosition(storage, queueId, currentIndex, isInteractive, device).Result;
        }

        #endregion Очереди

        #endregion Основные функции
    }
}
