Yandex.Music API (Unofficial) for .Net Core
====

[![Build Status](https://travis-ci.com/Winster332/Yandex.Music.Api.svg?branch=master)](https://travis-ci.com/Winster332/Yandex.Music.Api)
![NuGet version (Yandex.Music.Api)](https://img.shields.io/nuget/v/Yandex.Music.Api.svg?style=flat-square)
[![Documentation Status](https://readthedocs.org/projects/yandexmusicapi/badge/?version=latest)](https://yandexmusicapi.readthedocs.io/en/latest/?badge=latest)

This is wrapper for the [Yandex.Music](http://music.yandex.ru/) API

Solution allows you to work with Yandex music based on the client.

The project is divided into 2 parts, Yandex.Music.Client and Yandex.Music.Api.

[Yandex.Music.Api]("https://github.com/Winster332/Yandex.Music.Api/Yandex.Music.Api") - contains pure api Yandex \
[Yandex.Music.Client]("https://github.com/Winster332/Yandex.Music.Api/Yandex.Music.Client) - ready client for working with Yandex Api

The difference between Yandex.Music.Api and Yandex.Music.Client is 
that Yandex.Music.Api contains pure api, but when we 
add a song to your favorites in the web version 
of yandex music, for example, several queries may 
be performed (adding a song to a playlist, adding a radio to 
recommendations, like / dislike, updating the list songs). 
Using Yandex.Music.Api, you take this moment under your control. 
Yandex.Music.Client takes it upon himself and repeats the 
functionality of Yandex music. Client works on top of Yandex.Music.Api.

[Here is the documentation](https://readthedocs.org/projects/yandexmusicapi/)

 Install
-------

- [NuGet Package](https://www.nuget.org/packages/Yandex.Music.Api/1.0.0)

 How use
-------

[Yandex.Music.Api]("https://github.com/Winster332/Yandex.Music.Api/Yandex.Music.Api") \
[Yandex.Music.Client]("https://github.com/Winster332/Yandex.Music.Api/Yandex.Music.Client)

##### Examples

- [Yandex.Music.Terminal](https://github.com/Winster332/Yandex.Music.Terminal)
- [Lofi](https://github.com/Winster332/Lofi)

LICENCE
-------
[GNU General Public License v3.0](https://github.com/Winster332/Yandex.Music.Api/blob/master/LICENSE)
