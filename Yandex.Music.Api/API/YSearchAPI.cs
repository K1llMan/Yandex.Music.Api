using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Requests.Search;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для поиска
    /// </summary>
    public class YSearchAPI
    {
        #region Основные функции

        /// <summary>
        /// Поиск по трекам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackName">Имя трека</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YSearchResponse> TrackAsync(YAuthStorage storage, string trackName, int pageNumber = 0)
        {
            return await SearchAsync(storage, trackName, YSearchType.Track, pageNumber);
        }

        /// <summary>
        /// Поиск по трекам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackName">Имя трека</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public YSearchResponse Track(YAuthStorage storage, string trackName, int pageNumber = 0)
        {
            return TrackAsync(storage, trackName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по альбомам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumName">Имя альбома</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YSearchResponse> AlbumsAsync(YAuthStorage storage, string albumName, int pageNumber = 0)
        {
            return await SearchAsync(storage, albumName, YSearchType.Album, pageNumber);
        }

        /// <summary>
        /// Поиск по альбомам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumName">Имя альбома</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public YSearchResponse Albums(YAuthStorage storage, string albumName, int pageNumber = 0)
        {
            return AlbumsAsync(storage, albumName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по артисту
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistName">Имя артиста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YSearchResponse> ArtistAsync(YAuthStorage storage, string artistName, int pageNumber = 0)
        {
            return await SearchAsync(storage, artistName, YSearchType.Artist, pageNumber);
        }

        /// <summary>
        /// Поиск по артисту
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistName">Имя артиста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public YSearchResponse Artist(YAuthStorage storage, string artistName, int pageNumber = 0)
        {
            return ArtistAsync(storage, artistName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по плейлистам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlistName">Имя плейлиста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YSearchResponse> PlaylistAsync(YAuthStorage storage, string playlistName, int pageNumber = 0)
        {
            return await SearchAsync(storage, playlistName, YSearchType.Playlist, pageNumber);
        }

        /// <summary>
        /// Поиск по плейлистам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlistName">Имя плейлиста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public YSearchResponse Playlist(YAuthStorage storage, string playlistName, int pageNumber = 0)
        {
            return PlaylistAsync(storage, playlistName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по видео
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="videoName">Имя видео</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YSearchResponse> VideosAsync(YAuthStorage storage, string videoName, int pageNumber = 0)
        {
            return await SearchAsync(storage, videoName, YSearchType.Video, pageNumber);
        }

        /// <summary>
        /// Поиск по видео
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="videoName">Имя пользователя</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public YSearchResponse Videos(YAuthStorage storage, string videoName, int pageNumber = 0)
        {
            return UsersAsync(storage, videoName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по пользователям
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YSearchResponse> UsersAsync(YAuthStorage storage, string userName, int pageNumber = 0)
        {
            return await SearchAsync(storage, userName, YSearchType.User, pageNumber);
        }

        /// <summary>
        /// Поиск по пользователям
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public YSearchResponse Users(YAuthStorage storage, string userName, int pageNumber = 0)
        {
            return UsersAsync(storage, userName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="searchText">Поисковый запрос</param>
        /// <param name="searchType">Тип поиска</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        public async Task<YSearchResponse> SearchAsync(YAuthStorage storage, string searchText, YSearchType searchType, int page = 0)
        {
            return await new YSearchRequest(storage)
                .Create(searchText, searchType, page)
                .GetResponseAsync<YSearchResponse>();
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="searchText">Поисковый запрос</param>
        /// <param name="searchType">Тип поиска</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        public YSearchResponse Search(YAuthStorage storage, string searchText, YSearchType searchType, int page = 0)
        {
            return SearchAsync(storage, searchText, searchType, page).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}