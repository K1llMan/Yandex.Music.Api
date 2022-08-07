using System.Threading.Tasks;

using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search;
using Yandex.Music.Api.Requests.Search;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для поиска
    /// </summary>
    public class YSearchAPI : YCommonAPI
    {
        #region Основные функции

        public YSearchAPI(YandexMusicApi yandex): base(yandex)
        {
        }

        /// <summary>
        /// Поиск по трекам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackName">Имя трека</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YResponse<YSearch>> TrackAsync(AuthStorage storage, string trackName, int pageNumber = 0)
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
        public YResponse<YSearch> Track(AuthStorage storage, string trackName, int pageNumber = 0)
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
        public async Task<YResponse<YSearch>> AlbumsAsync(AuthStorage storage, string albumName, int pageNumber = 0)
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
        public YResponse<YSearch> Albums(AuthStorage storage, string albumName, int pageNumber = 0)
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
        public async Task<YResponse<YSearch>> ArtistAsync(AuthStorage storage, string artistName, int pageNumber = 0)
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
        public YResponse<YSearch> Artist(AuthStorage storage, string artistName, int pageNumber = 0)
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
        public async Task<YResponse<YSearch>> PlaylistAsync(AuthStorage storage, string playlistName, int pageNumber = 0)
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
        public YResponse<YSearch> Playlist(AuthStorage storage, string playlistName, int pageNumber = 0)
        {
            return PlaylistAsync(storage, playlistName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по плейлистам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="podcastName">Имя подкаста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YResponse<YSearch>> PodcastEpisodeAsync(AuthStorage storage, string podcastName, int pageNumber = 0)
        {
            return await SearchAsync(storage, podcastName, YSearchType.PodcastEpisode, pageNumber);
        }

        /// <summary>
        /// Поиск по плейлистам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="podcastName">Имя подкаста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public YResponse<YSearch> PodcastEpisode(AuthStorage storage, string podcastName, int pageNumber = 0)
        {
            return PodcastEpisodeAsync(storage, podcastName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по видео
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="videoName">Имя видео</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YResponse<YSearch>> VideosAsync(AuthStorage storage, string videoName, int pageNumber = 0)
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
        public YResponse<YSearch> Videos(AuthStorage storage, string videoName, int pageNumber = 0)
        {
            return VideosAsync(storage, videoName, pageNumber).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по пользователям
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns></returns>
        public async Task<YResponse<YSearch>> UsersAsync(AuthStorage storage, string userName, int pageNumber = 0)
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
        public YResponse<YSearch> Users(AuthStorage storage, string userName, int pageNumber = 0)
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
        public async Task<YResponse<YSearch>> SearchAsync(AuthStorage storage, string searchText, YSearchType searchType, int page = 0)
        {
            return await new YSearchRequest(api, storage)
                .Create(searchText, searchType, page)
                .GetResponseAsync();
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="searchText">Поисковый запрос</param>
        /// <param name="searchType">Тип поиска</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        public YResponse<YSearch> Search(AuthStorage storage, string searchText, YSearchType searchType, int page = 0)
        {
            return SearchAsync(storage, searchText, searchType, page).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Подсказка
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="searchText">Поисковый запрос</param>
        /// <returns></returns>
        public async Task<YResponse<YSearchSuggest>> SuggestAsync(AuthStorage storage, string searchText)
        {
            return await new YSearchSuggestRequest(api, storage)
                .Create(searchText)
                .GetResponseAsync();
        }

        /// <summary>
        /// Подсказка
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="searchText">Поисковый запрос</param>
        /// <returns></returns>
        public YResponse<YSearchSuggest> Suggest(AuthStorage storage, string searchText)
        {
            return SuggestAsync(storage, searchText).GetAwaiter().GetResult();
        }

        #endregion Основные функции
    }
}