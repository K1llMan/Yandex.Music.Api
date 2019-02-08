Yandex.Music API (Unofficial) for .Net Core
====

[![Build Status](https://travis-ci.com/Winster332/Yandex.Music.Api.svg?branch=master)](https://travis-ci.com/Winster332/Yandex.Music.Api)

This is wrapper for the [Yandex.Music](http://music.yandex.ru/) API

 Install
-------

Link on nuget:
https://www.nuget.org/packages/Yandex.Music.Api/1.0.0

#### NuGet

Install-Package Yandex.Music.Api -Version 1.0.0

#### .NET CLI

dotnet add package Yandex.Music.Api --version 1.0.0

#### Paket-CLI

paket add Yandex.Music.Api --version 1.0.0

Usage
-------

```C#
 var yandexApi = new LofiYandexMusicApi();
 
 yandexApi.Authorize("login", "password");
 // place code here
 
 var track = Api.SearchTrack("I Don't Care").First();
 var streamTrack = yandexApi.ExtractStreamTrack(track);
 var artistName = track.Artists.FirstOrDefault()?.Name;

 streamTrack.Complated += (o, track1) =>
 {
    var fileName = $"{artistName} - {track.Title}";
    
    streamTrack.SaveToFile(fileName);
 };
```

This library provides following functions:

#### Users

- Authorize
- SearchUsers
- UseProxy

#### Music

- GetListFavorites
- ExtractTrackToFile
- ExtractStreamTrack
- ExtractDataTrack
- SearchTrack
- GetTrack

#### Playlist

- GetPlaylistOfDay
- GetPlaylistDejaVu
- SearchPlaylist
- SearchArtist
- SearchAlbums
- GetAlbum
