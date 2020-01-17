using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Responses;

namespace Yandex.Music.Api
{
  public interface IYandexMusicApi
  {
    /// <summary>
    /// Authorize user to yandex
    /// </summary>
    /// <param name="username">User name</param>
    /// <param name="password">User password</param>
    /// <returns></returns>
    YAuthorizeResponse Authorize(string usernam, string password, bool saveCache = false);
    /// <summary>
    /// Authorize user to yandex
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<YAuthorizeResponse> AuthorizeAsync(string login, string password, bool saveCache = false);

    
    /// <summary>
    /// Return playlist track favorites
    /// </summary>
    /// <param name="userId">User id</param>
    /// <returns></returns>
    Task<YPlaylistFavoritesResponse> GetPlaylistFavoritesAsync(string login = null);
    /// <summary>
    /// Return playlist track favorites
    /// </summary>
    /// <param name="userId">User id</param>
    /// <returns></returns>
    YPlaylistFavoritesResponse GetPlaylistFavorites(string userId = null);
    
    
    /// <summary>
    /// Search by tracks
    /// </summary>
    /// <param name="trackName"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    Task<YSearchResponse> SearchTrackAsync(string trackName, int pageNumber = 0);
    /// <summary>
    /// Search by tracks
    /// </summary>
    /// <param name="trackName">Track name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    YSearchResponse SearchTrack(string trackName, int pageNumber = 0);

    
    /// <summary>
    /// Search by artists
    /// </summary>
    /// <param name="artistName">Artist name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    Task<YSearchResponse> SearchArtistAsync(string artistName, int pageNumber = 0);
    /// <summary>
    /// Search by artists
    /// </summary>
    /// <param name="artistName">Artist name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    YSearchResponse SearchArtist(string artistName, int pageNumber = 0);

    
    /// <summary>
    /// Search by albums
    /// </summary>
    /// <param name="albumName">Album name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    Task<YSearchResponse> SearchPlaylistAsync(string playlistName, int pageNumber = 0);
    /// <summary>
    /// Search by albums
    /// </summary>
    /// <param name="albumName">Album name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    YSearchResponse SearchAlbums(string albumName, int pageNumber = 0);

    
    /// <summary>
    /// Search by playlists
    /// </summary>
    /// <param name="playlistName">Playlist name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    Task<YSearchResponse> SearchAlbumsAsync(string albumName, int pageNumber = 0);
    /// <summary>
    /// Search by playlists
    /// </summary>
    /// <param name="playlistName">Playlist name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    YSearchResponse SearchPlaylist(string playlistName, int pageNumber = 0);

    
    /// <summary>
    /// Search by users
    /// </summary>
    /// <param name="userName">User name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    Task<YSearchResponse> SearchUsersAsync(string userName, int pageNumber = 0);
    /// <summary>
    /// Search by users
    /// </summary>
    /// <param name="userName">User name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    YSearchResponse SearchUsers(string userName, int pageNumber = 0);

    
    /// <summary>
    /// Return best playlist of day
    /// </summary>
    /// <returns></returns>
    Task<YPlaylistResponse> GetPlaylistOfDayAsync();
    /// <summary>
    /// Return best playlist of day
    /// </summary>
    /// <returns></returns>
    YPlaylistResponse GetPlaylistOfDay();

    
    /// <summary>
    /// Return play playlist deja vu
    /// </summary>
    /// <returns></returns>
    Task<YPlaylistResponse> GetPlaylistDejaVuAsync();
    /// <summary>
    /// Return play playlist deja vu
    /// </summary>
    /// <returns></returns>
    YPlaylistResponse GetPlaylistDejaVu();

    
    /// <summary>
    /// Return album from albumId
    /// </summary>
    /// <param name="albumId">Id album</param>
    /// <returns></returns>
    Task<YAlbumResponse> GetAlbumAsync(string albumId);
    /// <summary>
    /// Return album from albumId
    /// </summary>
    /// <param name="albumId">Id album</param>
    /// <returns></returns>
    YAlbumResponse GetAlbum(string albumId);

    
    /// <summary>
    /// Return track from trackId
    /// </summary>
    /// <param name="trackId">Id track</param>
    /// <returns></returns>
    Task<YTrackResponse> GetTrackAsync(string trackId);
    /// <summary>
    /// Return track from trackId
    /// </summary>
    /// <param name="trackId">Id track</param>
    /// <returns></returns>
    YTrackResponse GetTrack(string trackId);

    
    /// <summary>
    /// Search by yandex music
    /// </summary>
    /// <param name="searchText">Search text</param>
    /// <param name="searchType">Search type</param>
    /// <param name="page">Page number</param>
    /// <returns></returns>
    Task<YSearchResponse> SearchAsync(string searchText, YandexSearchType searchType, int page = 0);
    /// <summary>
    /// Search by yandex music
    /// </summary>
    /// <param name="searchText">Search text</param>
    /// <param name="searchType">Search type</param>
    /// <param name="page">Page number</param>
    /// <returns></returns>
    YSearchResponse Search(string searchText, YandexSearchType searchType, int page = 0);

    
    /// <summary>
    /// Use target proxy
    /// </summary>
    /// <param name="proxy">Proxy</param>
    /// <returns></returns>
    IYandexMusicApi UseWebProxy(IWebProxy proxy);

    
    /// <summary>
    /// Return metadata of track
    /// </summary>
    /// <param name="trackKey"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    Task<YTrackDownloadInfoResponse> GetMetadataTrackForDownloadAsync(string trackKey, long time);
    /// <summary>
    /// Return metadata of track
    /// </summary>
    /// <param name="trackKey"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    YTrackDownloadInfoResponse GetMetadataTrackForDownload(string trackKey, long time);

    /// <summary>
    /// Return info for download
    /// </summary>
    /// <param name="metadataInfo"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    Task<YStorageDownloadFileResponse> GetDownloadFilInfoAsync(YTrackDownloadInfoResponse metadataInfo, long time);
    /// <summary>
    /// Return info for download
    /// </summary>
    /// <param name="metadataInfo"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    YStorageDownloadFileResponse GetDownloadFilInfo(YTrackDownloadInfoResponse metadataInfo, long time);

    
    /// <summary>
    /// Return account
    /// </summary>
    /// <returns></returns>
    Task<YAccountResponse> GetAccountsAsync();
    /// <summary>
    /// Return account
    /// </summary>
    /// <returns></returns>
    YAccountResponse GetAccounts();

    
    /// <summary>
    /// Create playlist
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<YPlaylistChangeResponse> CreatePlaylistAsync(string name);
    /// <summary>
    /// Create playlist
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    YPlaylistChangeResponse CreatePlaylist(string name);

    
    /// <summary>
    /// Remove playlist by kind
    /// </summary>
    /// <param name="kind"></param>
    /// <returns></returns>
    Task<bool> RemovePlaylistAsync(long kind);
    /// <summary>
    /// Remove playlist by kind
    /// </summary>
    /// <param name="kind"></param>
    /// <returns></returns>
    bool RemovePlaylist(long kind);

    
    /// <summary>
    /// Return yandex cookie
    /// </summary>
    /// <returns></returns>
    Task<YGetCookieResponse> GetYandexCookieAsync();
    /// <summary>
    /// Return yandex cookie
    /// </summary>
    /// <returns></returns>
    YGetCookieResponse GetYandexCookie();
    
    
    /// <summary>
    /// Download track to file
    /// </summary>
    /// <param name="trackDownloadKey"></param>
    /// <param name="filePath"></param>
    void ExtractTrackToFile(string trackDownloadKey, string filePath);
    
    
    /// <summary>
    /// Extract track as bytes array
    /// </summary>
    /// <param name="trackKey"></param>
    /// <returns></returns>
    byte[] ExtractDataTrack(string trackKey);

    /// <summary>
    /// Stream extract track
    /// </summary>
    /// <param name="trackKey"></param>
    /// <param name="fileSize"></param>
    /// <returns></returns>
    YandexStreamTrack ExtractStreamTrack(string trackKey, int fileSize);
    
    
    /// <summary>
    /// Return user auth information
    /// </summary>
    /// <returns></returns>
    Task<YAuthInfoUserResponse> GetUserAuthDetailsAsync();
    /// <summary>
    /// Return user auth information
    /// </summary>
    /// <returns></returns>
    YAuthInfoUserResponse GetUserAuthDetails();
    
    
    /// <summary>
    /// Return auth information
    /// </summary>
    /// <returns></returns>
    Task<YAuthInfoResponse> GetUserAuthAsync();
    /// <summary>
    /// Return auth information
    /// </summary>
    /// <returns></returns>
    YAuthInfoResponse GetUserAuth();

    
    /// <summary>
    /// Return library
    /// </summary>
    /// <returns></returns>
    Task<YLibraryPlaylistResponse> GetLibraryPlaylistAsync();
    /// <summary>
    /// Return library
    /// </summary>
    /// <returns></returns>
    YLibraryPlaylistResponse GetLibraryPlaylist();

    
    /// <summary>
    /// Return library history
    /// </summary>
    /// <returns></returns>
    Task<YLibraryHistoryResponse> GetLibraryHistoryAsync();
    /// <summary>
    /// Return library history
    /// </summary>
    /// <returns></returns>
    YLibraryHistoryResponse GetLibraryHistory();
    
    /// <summary>
    /// Set track as liked. Before ChangeLikedTrackAsync
    /// </summary>
    /// <param name="trackKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task<YSetLikedTrackResponse> SetLikedTrackAsync(string trackKey, bool value);
    /// <summary>
    /// Set track as liked. Before ChangeLikedTrack
    /// </summary>
    /// <param name="trackKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    YSetLikedTrackResponse SetLikedTrack(string trackKey, bool value);

    
    /// <summary>
    /// Change track as liked. After SetLikedTrack
    /// </summary>
    /// <param name="trackKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task<YAddLikedTrackResponse> ChangeLikedTrackAsync(string trackKey, bool value);
    /// <summary>
    /// Change track as liked. After SetLikedTrack
    /// </summary>
    /// <param name="trackKey"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    YAddLikedTrackResponse ChangeLikedTrack(string trackKey, bool value);


    /// <summary>
    /// Insert track to playlist
    /// </summary>
    /// <param name="trackId">Track id</param>
    /// <param name="albumId">Album in track id</param>
    /// <param name="playlistKind">Playlist kind</param>
    /// <returns></returns>
    YInsertTrackToPlaylistResponse InsertTrackToPlaylist(string trackId, string albumId, string playlistKind);

    /// <summary>
    /// Insert track to playlist
    /// </summary>
    /// <param name="trackId">Track id</param>
    /// <param name="albumId">Album in track id</param>
    /// <param name="playlistKind">Playlist kind</param>
    /// <returns></returns>
    Task<YInsertTrackToPlaylistResponse> InsertTrackToPlaylistAsync(string trackId, string albumId, string playlistKind);


    /// <summary>
    /// Delete track from playlist
    /// </summary>
    /// <param name="from">Begin track index</param>
    /// <param name="to">End track index</param>
    /// <param name="revision">Current revision playlist</param>
    /// <param name="playlistKind">Kind playlist</param>
    /// <returns></returns>
    Task<YDeleteTrackFromPlaylistResponse> DeleteTrackFromPlaylistAsync(int from, int to, int revision, string playlistKind);
    /// <summary>
    /// Delete track from playlist
    /// </summary>
    /// <param name="from">Begin track index</param>
    /// <param name="to">End track index</param>
    /// <param name="revision">Current revision playlist</param>
    /// <param name="playlistKind">Kind playlist</param>
    /// <returns></returns>
    YDeleteTrackFromPlaylistResponse DeleteTrackFromPlaylist(int from, int to, int revision, string playlistKind);


    /// <summary>
    /// Dislike on track
    /// </summary>
    /// <param name="trackKey">Track key</param>
    /// <returns></returns>
    Task<YNotRecommendTrackResponse> NotRecommendTrackAsync(string trackKey);
    /// <summary>
    /// Dislike on track
    /// </summary>
    /// <param name="trackKey">Track key</param>
    /// <returns></returns>
    YNotRecommendTrackResponse NotRecommendTrack(string trackKey);

    
    /// <summary>
    /// Under not recommend
    /// </summary>
    /// <param name="trackKey"></param>
    /// <returns></returns>
    Task<YUnDislikeTrackResponse> UnderNotRecommendTrackAsync(string trackKey);
    /// <summary>
    /// Under not recommend
    /// </summary>
    /// <param name="trackKey"></param>
    /// <returns></returns>
    YUnDislikeTrackResponse UnderNotRecommendTrack(string trackKey);
  }
}