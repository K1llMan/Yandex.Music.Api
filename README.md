Yandex.Music API (Unofficial) for .Net Core
====

[![Build Status](https://travis-ci.com/Winster332/Lofi.svg?token=9RFGGw1id2424svMxqyZ&branch=master)](https://travis-ci.com/Winster332/Lofi)

This is wrapper for the [Yandex.Music](http://music.yandex.ru/) API

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
