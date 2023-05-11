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
    public partial class YSearchAPI : YCommonAPI
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
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YResponse<YSearch>> TrackAsync(AuthStorage storage, string trackName, int pageNumber = 0, int pageSize = 20)
        {
            return SearchAsync(storage, trackName, YSearchType.Track, pageNumber, pageSize);
        }

        /// <summary>
        /// Поиск по альбомам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumName">Имя альбома</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YResponse<YSearch>> AlbumsAsync(AuthStorage storage, string albumName, int pageNumber = 0, int pageSize = 20)
        {
            return SearchAsync(storage, albumName, YSearchType.Album, pageNumber, pageSize);
        }

        /// <summary>
        /// Поиск по артисту
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistName">Имя артиста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YResponse<YSearch>> ArtistAsync(AuthStorage storage, string artistName, int pageNumber = 0, int pageSize = 20)
        {
            return SearchAsync(storage, artistName, YSearchType.Artist, pageNumber, pageSize);
        }

        /// <summary>
        /// Поиск по плейлистам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlistName">Имя плейлиста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YResponse<YSearch>> PlaylistAsync(AuthStorage storage, string playlistName, int pageNumber = 0, int pageSize = 20)
        {
            return SearchAsync(storage, playlistName, YSearchType.Playlist, pageNumber, pageSize);
        }

        /// <summary>
        /// Поиск по плейлистам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="podcastName">Имя подкаста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YResponse<YSearch>> PodcastEpisodeAsync(AuthStorage storage, string podcastName, int pageNumber = 0, int pageSize = 20)
        {
            return SearchAsync(storage, podcastName, YSearchType.PodcastEpisode, pageNumber, pageSize);
        }

        /// <summary>
        /// Поиск по видео
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="videoName">Имя видео</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YResponse<YSearch>> VideosAsync(AuthStorage storage, string videoName, int pageNumber = 0, int pageSize = 20)
        {
            return SearchAsync(storage, videoName, YSearchType.Video, pageNumber, pageSize);
        }

        /// <summary>
        /// Поиск по пользователям
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YResponse<YSearch>> UsersAsync(AuthStorage storage, string userName, int pageNumber = 0, int pageSize = 20)
        {
            return SearchAsync(storage, userName, YSearchType.User, pageNumber, pageSize);
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="searchText">Поисковый запрос</param>
        /// <param name="searchType">Тип поиска</param>
        /// <param name="page">Страница</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public Task<YResponse<YSearch>> SearchAsync(AuthStorage storage, string searchText, YSearchType searchType, int page = 0, int pageSize = 20)
        {
            return new YSearchBuilder(api, storage)
                .Build((searchText, searchType, page, pageSize))
                .GetResponseAsync();
        }

        /// <summary>
        /// Подсказка
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="searchText">Поисковый запрос</param>
        /// <returns></returns>
        public Task<YResponse<YSearchSuggest>> SuggestAsync(AuthStorage storage, string searchText)
        {
            return new YSearchSuggestBuilder(api, storage)
                .Build(searchText)
                .GetResponseAsync();
        }

        #endregion Основные функции
    }
}