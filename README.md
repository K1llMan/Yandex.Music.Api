Yandex.Music API (Unofficial) for .Net Core
====

[![Build Status](https://travis-ci.com/Winster332/Yandex.Music.Api.svg?branch=master)](https://travis-ci.com/Winster332/Yandex.Music.Api)
![NuGet version (Yandex.Music.Api)](https://img.shields.io/nuget/v/Yandex.Music.Api.svg?style=flat-square)

This is wrapper for the [Yandex.Music](http://music.yandex.ru/) API

Solution allows you to work with Yandex music based on the client.

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
│   ├── Authorize (string username, string password)
│   ├── SearchUsers (string userName, int pageNumber = 0)
│   └── UseProxy (IWebProxy proxy)
├── Music
│   ├── GetListFavorites (string userId = null)
│   ├── ExtractTrackToFile (YandexTrack track, string filder = "data")
│   ├── ExtractStreamTrack (YandexTrack track)
│   ├── ExtractDataTrack (YandexTrack track)
│   ├── SearchTrack (string trackName, int pageNumber = 0)
│   └── GetTrack (string trackId)
├── Playlist
│   ├── GetPlaylistOfDay ()
│   ├── GetPlaylistDejaVu ()
│   ├── SearchPlaylist (string playlistName, int pageNumber = 0)
│   ├── SearchArtist (string artistName, int pageNumber = 0)
│   ├── SearchAlbums (string albumName, int pageNumber = 0)
│   └── GetAlbum (string albumId)
└── Future
```

Contents
-------
* [Roadmap](https://github.com/Winster332/Yandex.Music.Api/#roadmap)
* [Users](https://github.com/Winster332/Yandex.Music.Api#users)
	* [Authorize](https://github.com/Winster332/Yandex.Music.Api#authorize)
	* [Use proxy](https://github.com/Winster332/Yandex.Music.Api#use-proxy)
* [Download track](https://github.com/Winster332/Yandex.Music.Api#download-track)
	* [Download to file](https://github.com/Winster332/Yandex.Music.Api#download-to-file)
	* [Download to stream](https://github.com/Winster332/Yandex.Music.Api#download-to-stream)

### Roadmap

This solution is experimental. Therefore, it may have various bugs. To work, the solution uses the https protocol.

### Users

##### Authorize

```C#
 var yandexApi = new YandexMusicApi();
 
 yandexApi.Authorize("yourLogin", "yourPassword");
```

##### Use proxy

Documentation in progress...

### Download track

##### Download to file

```C#
 var track = yandexApi.SearchTrack("I Don't Care").First();
 var fileName = $"{track.Title}.mp3";
 yandexApi.ExtractTrackToFile(track, fileName);
```

##### Download to stream

```C#
 var track = yandexApi.SearchTrack("I Don't Care").First();
 var streamTrack = yandexApi.ExtractStreamTrack(track);
 var artistName = track.Artists.FirstOrDefault()?.Name;

 streamTrack.Complated += (o, track1) =>
 {
    var fileName = $"{artistName} - {track.Title}";
    
    streamTrack.SaveToFile(fileName);
 };
```

LICENCE
-------
[GNU General Public License v3.0](https://github.com/Winster332/Yandex.Music.Api/blob/master/LICENSE)
