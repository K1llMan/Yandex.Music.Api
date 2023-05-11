using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Common;
using Yandex.Music.Api.Models.Search;

namespace Yandex.Music.Api.API
{
    /// <summary>
    /// API для поиска
    /// </summary>
    public partial class YSearchAPI
    {
        #region Основные функции

        /// <summary>
        /// Поиск по трекам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="trackName">Имя трека</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public YResponse<YSearch> Track(AuthStorage storage, string trackName, int pageNumber = 0, int pageSize = 20)
        {
            return TrackAsync(storage, trackName, pageNumber, pageSize).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по альбомам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="albumName">Имя альбома</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public YResponse<YSearch> Albums(AuthStorage storage, string albumName, int pageNumber = 0, int pageSize = 20)
        {
            return AlbumsAsync(storage, albumName, pageNumber, pageSize).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по артисту
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="artistName">Имя артиста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public YResponse<YSearch> Artist(AuthStorage storage, string artistName, int pageNumber = 0, int pageSize = 20)
        {
            return ArtistAsync(storage, artistName, pageNumber, pageSize).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по плейлистам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="playlistName">Имя плейлиста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public YResponse<YSearch> Playlist(AuthStorage storage, string playlistName, int pageNumber = 0, int pageSize = 20)
        {
            return PlaylistAsync(storage, playlistName, pageNumber, pageSize).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по плейлистам
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="podcastName">Имя подкаста</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public YResponse<YSearch> PodcastEpisode(AuthStorage storage, string podcastName, int pageNumber = 0, int pageSize = 20)
        {
            return PodcastEpisodeAsync(storage, podcastName, pageNumber, pageSize).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по видео
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="videoName">Имя пользователя</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public YResponse<YSearch> Videos(AuthStorage storage, string videoName, int pageNumber = 0, int pageSize = 20)
        {
            return VideosAsync(storage, videoName, pageNumber, pageSize).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Поиск по пользователям
        /// </summary>
        /// <param name="storage">Хранилище</param>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns></returns>
        public YResponse<YSearch> Users(AuthStorage storage, string userName, int pageNumber = 0, int pageSize = 20)
        {
            return UsersAsync(storage, userName, pageNumber, pageSize).GetAwaiter().GetResult();
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
        public YResponse<YSearch> Search(AuthStorage storage, string searchText, YSearchType searchType, int page = 0, int pageSize = 20)
        {
            return SearchAsync(storage, searchText, searchType, page, pageSize).GetAwaiter().GetResult();
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