Yandex.Music API (Unofficial) for .Net Core
====

[![Build Status](https://travis-ci.com/Winster332/Yandex.Music.Api.svg?branch=master)](https://travis-ci.com/Winster332/Yandex.Music.Api)
![NuGet version (Yandex.Music.Api)](https://img.shields.io/nuget/v/Yandex.Music.Api.svg?style=flat-square)
[![Documentation Status](https://readthedocs.org/projects/yandexmusicapi/badge/?version=latest)](https://yandexmusicapi.readthedocs.io/en/latest/?badge=latest)

This is wrapper for the [Yandex.Music](http://music.yandex.ru/) API

Solution allows you to work with Yandex music based on the client.

[Here is the documentation](https://readthedocs.org/projects/yandexmusicapi/)

 Install
-------

- [NuGet Package](https://www.nuget.org/packages/Yandex.Music.Api/1.0.0)

```bash
Install-Package Yandex.Music.Api -Version 1.0.0
```

Functional
-------

This library provides following functions:

```C#
YandexMusicApi
│
├── Users
│   ├── Authorize / Async (string username, string password, bool saveCache)
│   ├── GetAccounts / Async ()
│   ├── GetYandexCookie / Async ()
│   ├── GetUserAuthDetails / Async ()
│   ├── GetUserAuth / Async ()
│   ├── SearchUsers / Async (string userName, int pageNumber = 0)
│   └── UseProxy (IWebProxy proxy)
├── Music
│   ├── ExtractTrackToFile (YandexTrack track, string filder = "data")
│   ├── ExtractStreamTrack (YandexTrack track, fileSize)
│   ├── ExtractDataTrack (YandexTrack track)
│   ├── SearchTrack / Async (string trackName, int pageNumber = 0)
│   ├── GetDownloadFilInfo / Async ()
│   ├── ChangeLikedTrack / Async (string trackKey, bool value)
│   ├── SetLikedTrack / Async (string trackKey, bool value)
│   ├── NotRecommendTrack / Async (string trackKey)
│   ├── UnderNotRecommendTrack / Async (string trackKey)
│   ├── InsertTrackToPlaylist / Async (string trackId, string albumId, string playListKind)
│   ├── DeleteTrackFromPlaylist / Async (int indexFrom, int indexTo, int playlistRevision, string playListKind)
│   └── GetTrack / Async (string trackId)
├── Playlist
│   ├── GetPlaylistOfDay / Async ()
│   ├── GetPlaylistDejaVu / Async ()
│   ├── GetPlaylistFavorites / Async (string userId = null)
│   ├── GetLibraryPlaylist / Async ()
│   ├── GetLibraryHistory / Async ()
│   ├── CreatePlaylist / Async (name)
│   ├── RemovePlaylist / Async (kind)
│   ├── SearchPlaylist / Async (string playlistName, int pageNumber = 0)
│   ├── SearchArtist / Async (string artistName, int pageNumber = 0)
│   ├── SearchAlbums / Async (string albumName, int pageNumber = 0)
│   └── GetAlbum / Async (string albumId)
└── Future
    ├── Remove track ()
    └── Radio-functions ()
```

Quick start
-------
* [Roadmap](https://github.com/Winster332/Yandex.Music.Api/#roadmap)
* [Users](https://github.com/Winster332/Yandex.Music.Api#users)
	* [Authorize](https://github.com/Winster332/Yandex.Music.Api#authorize)
	* [Search users](https://github.com/Winster332/Yandex.Music.Api#search-users)
	* [Use proxy](https://github.com/Winster332/Yandex.Music.Api#use-proxy)
* [Music](https://github.com/Winster332/Yandex.Music.Api#download-track)
	* [Download track to file](https://github.com/Winster332/Yandex.Music.Api#download-to-file)
	* [Download track to stream](https://github.com/Winster332/Yandex.Music.Api#download-to-stream)
	* [Download track to bytes](https://github.com/Winster332/Yandex.Music.Api#download-to-bytes)
	* [Get favorites playlist](https://github.com/Winster332/Yandex.Music.Api#get-favorites-playlist)
	* [Search track](https://github.com/Winster332/Yandex.Music.Api#search-track)
* [Playlist](https://github.com/Winster332/Yandex.Music.Api#playlist)
	* [Get playlist of day](https://github.com/Winster332/Yandex.Music.Api#get-playlist-of-day)
	* [Get playlist deja vu](https://github.com/Winster332/Yandex.Music.Api#get-playlist-deja-vu)
	* [Search playlist](https://github.com/Winster332/Yandex.Music.Api#search-playlist)
	
### Roadmap

This solution is experimental. Therefore, it may have various bugs. To work, the solution uses the https protocol.

### Users

##### Authorize

This step is optional. But it is necessary to consider that not authorized users get on captcha with which the user needs to cope by own strength. Therefore, it is better to use authorization.

```C#
 var yandexApi = new YandexMusicApi();
 
 // Your login and password in Yandex.Music
 yandexApi.Authorize("yourLogin", "yourPassword");
```

##### Search users

```C#
 var yandexApi = new YandexMusicApi();
 var pageNumber = 0;
 
 // Yandex search text and page
 var users = Api.SearchUsers("a", pageNumber);
```

##### Use proxy

Documentation in progress...

### Music

##### Download track to file

```C#
 var yandexApi = new YandexMusicApi();
 var track = yandexApi.SearchTrack("I Don't Care").First();
 var fileName = $"{track.Title}.mp3";
 yandexApi.ExtractTrackToFile(track.GetKey(), fileName);
```

##### Download track to stream

Stream for streaming music

```C#
 var yandexApi = new YandexMusicApi();
 var track = yandexApi.SearchTrack("I Don't Care").First();
 var streamTrack = yandexApi.ExtractStreamTrack(track.GetKey(), track.FileSize);
 var artistName = track.Artists.FirstOrDefault()?.Name;

 streamTrack.Complated += (o, track1) =>
 {
    var fileName = $"{artistName} - {track.Title}";
    
    streamTrack.SaveToFile(fileName);
 };
```

##### Download track to bytes

```C#
 var yandexApi = new YandexMusicApi();
 var track = yandexApi.SearchTrack("I Don't Care").First();
 var byteData = yandexApi.ExtractDataTrack(track.GetKey());
```

##### Get favorites playlist

```C#
 var yandexApi = new YandexMusicApi();
 yandexApi.Authorize("yourLogin", "yourPassword");
 var list = yandexApi.GetPlaylistFavorites();
```

##### Search track

```C#
 var yandexApi = new YandexMusicApi();
 var pageNumber = 0;
 var tracks = yandexApi.SearchTrack("I Don't Care", pageNumber);
```

### Playlist

##### Get playlist of day

```C#
 var yandexApi = new YandexMusicApi();
 yandexApi.Authorize("yourLogin", "yourPassword");
 var playlist = yandexApi.GetPlaylistOfDay();
```

##### Get playlist deja vu

```C#
 var yandexApi = new YandexMusicApi();
 yandexApi.Authorize("yourLogin", "yourPassword");
 var playlist = yandexApi.GetPlaylistDejaVu();
```
var playlist = yandexApi.GetPlaylistDejaVu();

##### Search playlist

```C#
  var yandexApi = new YandexMusicApi();
  yandexApi.Authorize("yourLogin", "yourPassword");
  var pageNumber = 0;
  var playlists = Api.SearchPlaylist("a", pageNumber);
```

##### Examples

- [Yandex.Music.Terminal](https://github.com/Winster332/Yandex.Music.Terminal)
- [Lofi](https://github.com/Winster332/Lofi)

LICENCE
-------
[GNU General Public License v3.0](https://github.com/Winster332/Yandex.Music.Api/blob/master/LICENSE)
