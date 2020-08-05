Yandex.Music API (Unofficial) for .Net Core
====

Форк [Yandex.Music API (Unofficial) for .Net Core](https://github.com/Winster332/Yandex.Music.Api)
API переделано под работу с API официального приложения, подобно [[Alpha] Неофициальная Python библиотека для API Yandex Music](https://github.com/MarshalX/yandex-music-api) 

Функционал
-------

Работа с API осуществляется через хранилище AuthStorage, являющееся по сути сущностью для пользователя, поэтому его необходимо передавать в вызов каждой функции.

API для удобства разделено на следующие ветки:

```C#
YandexMusicApi
│
├── Users
│   ├── Authorize / Async (AuthStorage storage, string username, string password)
│   ├── Authorize / Async (AuthStorage storage, string token)
│   └── GetUserAuth / Async (AuthStorage storage)
├── Track
│   ├── Get / Async (AuthStorage storage, string trackId)
│   ├── GetMetadataForDownload / Async (AuthStorage storage, string trackKey, bool direct)
│   ├── GetMetadataForDownload / Async (AuthStorage storage, YTrack track, bool direct)
│   ├── GetDownloadFileInfo / Async (AuthStorage storage, YTrackDownloadInfoResponse metadataInfo)
│   ├── GetFileLink (AuthStorage storage, string trackKey)
│   ├── GetFileLink (AuthStorage storage, YTrack track)
│   ├── ExtractToFile (AuthStorage storage, string trackKey, string filePath)
│   ├── ExtractToFile (AuthStorage storage, YTrack track, string filePath)
│   ├── ExtractData (AuthStorage storage, string trackKey)
│   └── ExtractData (AuthStorage storage, YTrack track)
├── Album
│   └── Get / Async (AuthStorage storage, string albumId)
├── Artist
│   └── Get / Async (AuthStorage storage, string artistId)
├── Playlist
│   ├── Get / Async (AuthStorage storage, string user, string kinds)
│   ├── Get / Async (AuthStorage storage, YPlaylist playlist)
│   ├── Favorites / Async (AuthStorage storage)
│   ├── OfTheDay / Async (AuthStorage storage)
│   ├── DejaVu / Async (AuthStorage storage)
│   ├── Premiere / Async (AuthStorage storage)
│   ├── Missed / Async (AuthStorage storage)
│   ├── Alice / Async (AuthStorage storage)
│   ├── Podcasts / Async (AuthStorage storage)
│   ├── Create / Async (AuthStorage storage, string name)
│   ├── Rename / Async (AuthStorage storage, string kinds, string name)
│   ├── Rename / Async (AuthStorage storage, YPlaylist playlist, string name)
│   ├── Delete / Async (AuthStorage storage, string kinds)
│   ├── Delete / Async (AuthStorage storage, YPlaylist playlist)
│   ├── InsertTracks / Async (AuthStorage storage, YPlaylist playlist, List<YTrack> tracks)
│   └── DeleteTrack / Async (AuthStorage storage, YPlaylist playlist, List<YTrack> tracks)
├── Library
│   ├── GetLikedTracks / Async (AuthStorage storage)
│   ├── GetLikedAlbums / Async (AuthStorage storage)
│   ├── GetLikedArtists / Async (AuthStorage storage)
│   ├── GetLikedPlaylists / Async (AuthStorage storage)
│   ├── GetDislikedTracks / Async (AuthStorage storage)
│   ├── AddTrackLike / Async (AuthStorage storage, YTrack track)
│   ├── RemoveTrackLike / Async (AuthStorage storage, YTrack track)
│   ├── AddTrackDislike / Async (AuthStorage storage, YTrack track)
│   ├── RemoveTrackDislike / Async (AuthStorage storage, YTrack track)
│   ├── AddAlbumLike / Async (AuthStorage storage, YAlbum album)
│   ├── RemoveAlbumLike / Async (AuthStorage storage, YAlbum album)
│   ├── AddArtistLike / Async (AuthStorage storage, YArtist artist)
│   ├── RemoveArtistLike / Async (AuthStorage storage, YArtist artist)
│   ├── AddPlaylistLike / Async(AuthStorage storage, YPlaylist playlist)
│   └── RemovePlaylistLike / Async(AuthStorage storage, YPlaylist playlist)
├── Search
│   ├── Track / Async (AuthStorage storage, string trackName, int pageNumber = 0)
│   ├── Albums / Async (AuthStorage storage, string albumName, int pageNumber = 0)
│   ├── Artist / Async (AuthStorage storage, string artistName, int pageNumber = 0)
│   ├── Playlist / Async (AuthStorage storage, string playlistName, int pageNumber = 0)
│   ├── Videos / Async (AuthStorage storage, string videoName, int pageNumber = 0)
│   ├── Users / Async (AuthStorage storage, string videoName, int pageNumber = 0) *
│   ├── Search / Async (AuthStorage storage, string searchText, YSearchType searchType, int page = 0)
│   └── Suggest / Async (AuthStorage storage, string searchText)
├── Radio
│   ├── GetStationsDashboard / Async (AuthStorage storage)
│   ├── GetStations / Async (AuthStorage storage)
│   ├── GetStation / Async (AuthStorage storage, string type, string tag)
│   ├── GetStation / Async (AuthStorage storage, YStationId id)
│   ├── GetStationTracks / Async (AuthStorage storage, YStation station, string prevTrackId = "")
│   └── SetStationSettings2 / Async (AuthStorage storage, YStation station, YStationSettings2 settings)
└── Future
    ...
```

Функции, помеченные звёздочкой, вероятно, не работают или передают неверные параметры.

Библиотека требует рефакторинга и переработки иерархии классов моделей. Отсутствует функционал радио.

LICENCE
-------
[GNU General Public License v3.0](https://github.com/K1llMan/Yandex.Music.Api/blob/master/LICENSE)
