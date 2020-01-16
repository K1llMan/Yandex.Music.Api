using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models;
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
    YAuthorizeResponse Authorize(string username, string password);

    Task<YAuthorizeResponse> AuthorizeAsync(string login, string password);
    
    /// <summary>
    /// Return list track favorites
    /// </summary>
    /// <param name="userId">User id</param>
    /// <returns></returns>
    List<YTrackResponse> GetListFavorites(string userId = null);
    
    /// <summary>
    /// Save track to file
    /// </summary>
    /// <param name="track">Track instance</param>
    /// <param name="filder">Folder for save file</param>
    /// <returns></returns>
//    bool ExtractTrackToFile(YandexTrack track, string filder = "data");
    
    /// <summary>
    /// Return track stram
    /// </summary>
    /// <param name="track">Track instance</param>
    /// <returns></returns>
//    YandexStreamTrack ExtractStreamTrack(YandexTrack track);
    
    /// <summary>
    /// Return bytes from track
    /// </summary>
    /// <param name="track">Track instance</param>
    /// <returns></returns>
//    byte[] ExtractDataTrack(YandexTrack track);

    /// <summary>
    /// Search by tracks
    /// </summary>
    /// <param name="trackName">Track name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    List<YTrackResponse> SearchTrack(string trackName, int pageNumber = 0);

    /// <summary>
    /// Search by artists
    /// </summary>
    /// <param name="artistName">Artist name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    List<YArtistResponse> SearchArtist(string artistName, int pageNumber = 0);

    /// <summary>
    /// Search by albums
    /// </summary>
    /// <param name="albumName">Album name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    List<YAlbumResponse> SearchAlbums(string albumName, int pageNumber = 0);

    /// <summary>
    /// Search by playlists
    /// </summary>
    /// <param name="playlistName">Playlist name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    List<YPlaylistResponse> SearchPlaylist(string playlistName, int pageNumber = 0);

    /// <summary>
    /// Search by users
    /// </summary>
    /// <param name="userName">User name</param>
    /// <param name="pageNumber">Page number</param>
    /// <returns></returns>
    List<YUserResponse> SearchUsers(string userName, int pageNumber = 0);

    /// <summary>
    /// Return best playlist of day
    /// </summary>
    /// <returns></returns>
    YPlaylistResponse GetPlaylistOfDay();

    /// <summary>
    /// Return play list deja vu
    /// </summary>
    /// <returns></returns>
    YPlaylistResponse GetPlaylistDejaVu();

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
    YTrackResponse GetTrack(string trackId);

    /// <summary>
    /// Search by yandex music
    /// </summary>
    /// <param name="searchText">Search text</param>
    /// <param name="searchType">Search type</param>
    /// <param name="page">Page number</param>
    /// <returns></returns>
    List<IYandexSearchable> Search(string searchText, YandexSearchType searchType, int page = 0);

    /// <summary>
    /// Use target proxy
    /// </summary>
    /// <param name="proxy">Proxy</param>
    /// <returns></returns>
    IYandexMusicApi UseWebProxy(IWebProxy proxy);

    YTrackDownloadInfoResponse GetMetadataTrackForDownload(string trackKey, Int64 time);
    YStorageDownloadFileResponse GetDownloadFilInfo(YTrackDownloadInfoResponse metadataInfo, Int64 time);

    YAccountResponse GetAccounts();
    YPlaylistChangeResponse CreatePlaylist(string name);
    bool RemovePlaylist(long kind);
    YGetCookieResponse GetYandexCookie();
    void ExtractTrackToFile(string trackDownloadKey, string filePath);
    byte[] ExtractDataTrack(string trackKey);
    YAuthInfoUserResponse GetUserAuthDetails();
    Task<YAuthInfoUserResponse> GetUserAuthDetailsAsync();
    YAuthInfoResponse GetUserAuth();
    Task<YAuthInfoResponse> GetUserAuthAsync();
    YLibraryResponse GetLibrary(string ownerUid);
    YSetLikedTrackResponse SetLikedTrack(string trackKey, bool value);
  }
}