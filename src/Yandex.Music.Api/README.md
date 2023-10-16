Yandex.Music API (Unofficial) for .Net
====

Изначально было форком [Yandex.Music API (Unofficial) for .Net Core](https://github.com/Winster332/Yandex.Music.Api), отсоединено по причине отсутствия поддержки родительского проекта и полном переписывании функционала библиотеки.

API переделано под работу с API официального приложения, подобно [API Yandex Music - неофициальная Python библиотека](https://github.com/MarshalX/yandex-music-api) 

[Документация](https://yandexmusicapicsharp.readthedocs.io/ru/latest/index.html)

[История версий](https://github.com/K1llMan/Yandex.Music.Api/blob/master/CHANGELOG.md)

[Telegram-чат](https://t.me/yandex_music_api)

Функционал
-------

Работа с API осуществляется через хранилище AuthStorage, являющееся по сути сущностью для пользователя, поэтому его необходимо передавать в вызов каждой функции.

API для удобства разделено на следующие ветки:

```C#
YandexMusicApi
│
├── Users
│   ├── Authorize / Async (AuthStorage storage, string token)
│   ├── GetUserAuth / Async (AuthStorage storage)
│   ├── CreateAuthSession / Async (AuthStorage storage, string userName)
│   ├── GetAuthQRLink / Async (AuthStorage storage)
│   ├── AuthorizeByQR / Async (AuthStorage storage)
│   ├── GetCaptcha / Async (AuthStorage storage)
│   ├── AuthorizeByCaptcha / Async (AuthStorage storage, string captchaValue)
│   ├── GetAuthLetter / Async (AuthStorage storage)
│   ├── AuthorizeByLetter / Async (AuthStorage storage)
│   ├── AuthorizeByAppPassword / Async (AuthStorage storage, string password)
│   ├── GetAccessToken / Async (AuthStorage storage)
│   └── GetLoginInfo / Async (AuthStorage storage)
├── Track
│   ├── Get / Async (AuthStorage storage, string trackId)
│   ├── Get / Async (AuthStorage storage, IEnumerable<string> trackIds)
│   ├── GetMetadataForDownload / Async (AuthStorage storage, string trackKey, bool direct)
│   ├── GetMetadataForDownload / Async (AuthStorage storage, YTrack track, bool direct)
│   ├── GetDownloadFileInfo / Async (AuthStorage storage, YTrackDownloadInfoResponse metadataInfo)
│   ├── GetFileLink / Async (AuthStorage storage, string trackKey)
│   ├── GetFileLink / Async (AuthStorage storage, YTrack track)
│   ├── ExtractToFile / Async (AuthStorage storage, string trackKey, string filePath)
│   ├── ExtractToFile / Async (AuthStorage storage, YTrack track, string filePath)
│   ├── ExtractData / Async (AuthStorage storage, string trackKey)
│   ├── ExtractData / Async (AuthStorage storage, YTrack track)
│   ├── ExtractStream / Async (AuthStorage storage, string trackKey)
│   ├── ExtractStream / Async (AuthStorage storage, YTrack track)
│   ├── GetSupplement / Async (AuthStorage storage, string trackId)
│   ├── GetSupplement / Async (AuthStorage storage, YTrack track)
│   ├── GetSimilar / Async (AuthStorage storage, string trackId)
│   └── GetSimilar / Async (AuthStorage storage, YTrack track)
├── Album
│   ├── Get / Async (AuthStorage storage, string albumId)
│   └── Get / Async (AuthStorage storage, IEnumerable<string> albumIds)
├── Artist
│   ├── Get / Async (AuthStorage storage, string artistId)
│   ├── Get / Async (AuthStorage storage, IEnumerable<string> artistIds)
│   ├── GetTracks / Async (AuthStorage storage, string artistId, int page = 0, int pageSize = 20)
│   └── GetAllTracks / Async (AuthStorage storage, string artistId)
├── Landing
│   ├── Get / Async (AuthStorage storage, params YLandingBlockType[] blocks)
│   └── Feed / Async (AuthStorage storage)
├── Playlist
│   ├── Get / Async (AuthStorage storage, string user, string kinds)
│   ├── Get / Async (AuthStorage storage, IEnumerable<(string user, string kind)> ids)
│   ├── GetPersonalPlaylists / Async (AuthStorage storage)
│   ├── Favorites / Async (AuthStorage storage)
│   ├── OfTheDay / Async (AuthStorage storage)
│   ├── DejaVu / Async (AuthStorage storage)
│   ├── Premiere / Async (AuthStorage storage)
│   ├── Missed / Async (AuthStorage storage)
│   ├── Kinopoisk / Async (AuthStorage storage)
│   ├── Create / Async (AuthStorage storage, string name)
│   ├── Rename / Async (AuthStorage storage, string kinds, string name)
│   ├── Rename / Async (AuthStorage storage, YPlaylist playlist, string name)
│   ├── Delete / Async (AuthStorage storage, string kinds)
│   ├── Delete / Async (AuthStorage storage, YPlaylist playlist)
│   ├── InsertTracks / Async (AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)
│   └── DeleteTrack / Async (AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)
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
│   ├── Track / Async (AuthStorage storage, string trackName, int pageNumber = 0, int pageSize = 20)
│   ├── Albums / Async (AuthStorage storage, string albumName, int pageNumber = 0, int pageSize = 20)
│   ├── Artist / Async (AuthStorage storage, string artistName, int pageNumber = 0, int pageSize = 20)
│   ├── Playlist / Async (AuthStorage storage, string playlistName, int pageNumber = 0, int pageSize = 20)
│   ├── PodcastEpisode / Async (AuthStorage storage, string podcastName, int pageNumber = 0, int pageSize = 20)
│   ├── Videos / Async (AuthStorage storage, string videoName, int pageNumber = 0, int pageSize = 20)
│   ├── Users / Async (AuthStorage storage, string videoName, int pageNumber = 0, int pageSize = 20) *
│   ├── Search / Async (AuthStorage storage, string searchText, YSearchType searchType, int page = 0, int pageSize = 20)
│   └── Suggest / Async (AuthStorage storage, string searchText)
├── Radio
│   ├── GetStationsDashboard / Async (AuthStorage storage)
│   ├── GetStations / Async (AuthStorage storage)
│   ├── GetStation / Async (AuthStorage storage, string type, string tag)
│   ├── GetStation / Async (AuthStorage storage, YStationId id)
│   ├── GetStationTracks / Async (AuthStorage storage, YStation station, string prevTrackId = "")
│   └── SetStationSettings2 / Async (AuthStorage storage, YStation station, YStationSettings2 settings)
├── Queue
│   ├── List / Async (AuthStorage storage, string device = null)
│   ├── Get / Async (AuthStorage storage, string queueId)
│   ├── Create / Async (AuthStorage storage, YQueue queue, string device = null)
│   └── UpdatePosition / Async (AuthStorage storage, string queueId, int currentIndex, bool isInteractive, string device = null)
└── Future
    ...
```

Функции, помеченные звёздочкой, вероятно, не работают или передают неверные параметры.

## LICENCE
[GNU General Public License v3.0](https://github.com/K1llMan/Yandex.Music.Api/blob/master/LICENSE)