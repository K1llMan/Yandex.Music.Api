Yandex.Music API (Unofficial) for .Net Core
====

Форк [Yandex.Music API (Unofficial) for .Net Core](https://github.com/Winster332/Yandex.Music.Api)
API переделано под работу с API официального приложения, подобно [[Alpha] Неофициальная Python библиотека для API Yandex Music](https://github.com/MarshalX/yandex-music-api) 

Функционал
-------

Работа с API осуществляется через хранилище YAuthStorage, являющееся по сути сущностью для пользователя, поэтому его необходимо передавать в вызов каждой функции.

API для удобства разделено на следующие ветки:

```C#
YandexMusicApi
│
├── Users
│   ├── Authorize / Async (YAuthStorage storage, string username, string password)
│   ├── Authorize / Async (YAuthStorage storage, string token)
│   └──GetUserAuth / Async (YAuthStorage storage)
├── Track
│   ├── Get / Async (YAuthStorage storage, string trackId)
│   ├── GetMetadataForDownload / Async (YAuthStorage storage, string trackKey, bool direct)
│   ├── GetMetadataForDownload / Async (YAuthStorage storage, YTrack track, bool direct)
│   ├── GetDownloadFileInfo / Async (YAuthStorage storage, YTrackDownloadInfoResponse metadataInfo)
│   ├── GetFileLink (YAuthStorage storage, string trackKey)
│   ├── GetFileLink (YAuthStorage storage, YTrack track)
│   ├── ExtractToFile (YAuthStorage storage, string trackKey, string filePath)
│   ├── ExtractToFile (YAuthStorage storage, YTrack track, string filePath)
│   ├── ExtractData (YAuthStorage storage, string trackKey)
│   └── ExtractData (YAuthStorage storage, YTrack track)
├── Album
│   └── Get / Async (YAuthStorage storage, string albumId)
├── Artist
│   └── Get / Async (YAuthStorage storage, string artistId)
├── Playlist
│   ├── Get / Async (YAuthStorage storage, string user, string kinds)
│   ├── Get / Async (YAuthStorage storage, YPlaylist playlist)
│   ├── Favorites / Async (YAuthStorage storage)
│   ├── OfTheDay / Async (YAuthStorage storage)
│   ├── DejaVu / Async (YAuthStorage storage)
│   ├── Premiere / Async (YAuthStorage storage)
│   ├── Missed / Async (YAuthStorage storage)
│   ├── Alice / Async (YAuthStorage storage)
│   ├── Podcasts / Async (YAuthStorage storage)
│   ├── Create / Async (YAuthStorage storage, string name)
│   ├── Rename / Async (YAuthStorage storage, string kinds, string name)
│   ├── Rename / Async (YAuthStorage storage, YPlaylist playlist, string name)
│   ├── Delete / Async (YAuthStorage storage, string kinds)
│   ├── Delete / Async (YAuthStorage storage, YPlaylist playlist)
│   ├── InsertTracks / Async (YAuthStorage storage, YPlaylist playlist, List<YTrack> tracks)
│   └── DeleteTrack / Async (YAuthStorage storage, YPlaylist playlist, List<YTrack> tracks)
├── Library
│   ├── GetLikedTracks / Async (YAuthStorage storage)
│   ├── GetLikedAlbums / Async (YAuthStorage storage)
│   ├── GetLikedArtists / Async (YAuthStorage storage)
│   ├── GetLikedPlaylists / Async (YAuthStorage storage)
│   ├── GetDislikedTracks / Async (YAuthStorage storage)
│   ├── AddTrackLike / Async (YAuthStorage storage, YTrack track)
│   ├── RemoveTrackLike / Async (YAuthStorage storage, YTrack track)
│   ├── AddTrackDislike / Async (YAuthStorage storage, YTrack track)
│   ├── RemoveTrackDislike / Async (YAuthStorage storage, YTrack track)
│   ├── AddAlbumLike / Async (YAuthStorage storage, YAlbum album)
│   ├── RemoveAlbumLike / Async (YAuthStorage storage, YAlbum album)
│   ├── AddArtistLike / Async (YAuthStorage storage, YArtist artist)
│   ├── RemoveArtistLike / Async (YAuthStorage storage, YArtist artist)
│   ├── AddPlaylistLike / Async(YAuthStorage storage, YPlaylist playlist)
│   └── RemovePlaylistLike / Async(YAuthStorage storage, YPlaylist playlist)
├── Search
│   ├── Track / Async (YAuthStorage storage, string trackName, int pageNumber = 0)
│   ├── Albums / Async (YAuthStorage storage, string albumName, int pageNumber = 0)
│   ├── Artist / Async (YAuthStorage storage, string artistName, int pageNumber = 0)
│   ├── Playlist / Async (YAuthStorage storage, string playlistName, int pageNumber = 0)
│   ├── Videos / Async (YAuthStorage storage, string videoName, int pageNumber = 0) *
│   ├── Users / Async (YAuthStorage storage, string videoName, int pageNumber = 0) *
│   ├── Search / Async (YAuthStorage storage, string searchText, YSearchType searchType, int page = 0)
└── Future
    ...
```

Функции, помеченные звёздочкой, вероятно, не работают или передают неверные параметры.

Библиотека требует рефакторинга и переработки иерархии классов моделей. Также отсутствует функционал радио и подсказок для поиска.

LICENCE
-------
[GNU General Public License v3.0](https://github.com/K1llMan/Yandex.Music.Api/blob/master/LICENSE)
