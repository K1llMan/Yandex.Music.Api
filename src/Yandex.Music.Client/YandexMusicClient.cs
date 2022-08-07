using System.Collections.Generic;
using System.Linq;

using Yandex.Music.Api;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Account;
using Yandex.Music.Api.Models.Album;
using Yandex.Music.Api.Models.Artist;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Landing;
using Yandex.Music.Api.Models.Playlist;
using Yandex.Music.Api.Models.Radio;
using Yandex.Music.Api.Models.Search;
using Yandex.Music.Api.Models.Track;

namespace Yandex.Music.Client
{
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
        public YAccount Account
        {
            get { return storage.User; }
        }

        /// <summary>
        /// Флаг авторизации
        /// </summary>
        public bool IsAuthorized
        {
            get { return storage.IsAuthorized; }
        }

        #endregion Свойства

        #region Основные функции

        public YandexMusicClient(DebugSettings settings = null)
        {
            api = new YandexMusicApi();
            storage = new AuthStorage(settings);
        }

        #region Авторизация

        public bool Authorize(string login, string password)
        {
            api.User.Authorize(storage, login, password);

            return storage.IsAuthorized;
        }

        public bool Authorize(string token)
        {
            api.User.Authorize(storage, token);

            return storage.IsAuthorized;
        }

        #endregion Авторизация

        #region Треки

        public YTrack GetTrack(string id)
        {
            return api.Track.Get(storage, id).Result.FirstOrDefault();
        }

        #endregion Треки

        #region Альбомы

        public YAlbum GetAlbum(string id)
        {
            return api.Album.Get(storage, id).Result;
        }

        #endregion Альбомы

        #region Исполнители

        public YArtistBriefInfo GetArtist(string id)
        {
            return api.Artist.Get(storage, id).Result;
        }

        #endregion Исполнители

        #region Плейлисты

        public YPlaylist GetPlaylist(string user, string id)
        {
            return api.Playlist.Get(storage, user,id).Result;
        }

        public List<YPlaylist> GetPersonalPlaylists()
        {
            YLanding landing = api.Playlist.Landing(storage).Result;

            return landing.Blocks
                .FirstOrDefault(b => b.Type == "personal-playlists")
                ?.Entities
                .Select(e => api.Playlist.Get(storage, e.Data?.Data).Result)
                .ToList();
        }

        public List<YPlaylist> GetFavorites()
        {
            return api.Playlist.Favorites(storage).Result;
        }

        public YPlaylist GetAlice()
        {
            return api.Playlist.Alice(storage).Result;
        }

        public YPlaylist GetDejaVu()
        {
            return api.Playlist.DejaVu(storage).Result;
        }

        public YPlaylist GetMissed()
        {
            return api.Playlist.Missed(storage).Result;
        }

        public YPlaylist GetOfTheDay()
        {
            return api.Playlist.OfTheDay(storage).Result;
        }

        public YPlaylist GetPodcasts()
        {
            return api.Playlist.Podcasts(storage).Result;
        }

        public YPlaylist GetRewind()
        {
            return api.Playlist.Kinopoisk(storage).Result;
        }

        public YPlaylist GetPremiere()
        {
            return api.Playlist.Premiere(storage).Result;
        }

        public YPlaylist CreatePlaylist(string name)
        {
            return api.Playlist.Create(storage, name).Result;
        }

        #endregion Плейлисты

        #region Поиск

        public YSearch Search(string searchText, YSearchType searchType, int page = 0)
        {
            return api.Search.Search(storage, searchText, searchType, page).Result;
        }

        public YSearchSuggest GetSearchSuggestions(string searchText)
        {
            return api.Search.Suggest(storage, searchText).Result;
        }

        #endregion Поиск

        #region Радио

        public List<YStation> GetRadioDashboard()
        {
            return api.Radio.GetStationsDashboard(storage).Result.Stations;
        }

        public List<YStation> GetRadioStations()
        {
            return api.Radio.GetStations(storage).Result;
        }

        public YStation GetRadioStation(YStationId id)
        {
            return api.Radio.GetStation(storage, id).Result.FirstOrDefault();
        }

        #endregion Радио

        #endregion Основные функции
    }
}
