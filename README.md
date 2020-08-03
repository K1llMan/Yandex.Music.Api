[![Build Status](https://travis-ci.com/K1llMan/Yandex.Music.Api.svg?branch=master)](https://travis-ci.com/K1llMan/Yandex.Music.Api)
 
 Yandex.Music API (Unofficial) for .Net Core
====

Форк [Yandex.Music API (Unofficial) for .Net Core](https://github.com/Winster332/Yandex.Music.Api)
API переделано под работу с API официального приложения, подобно [[Alpha] Неофициальная Python библиотека для API Yandex Music](https://github.com/MarshalX/yandex-music-api) 

Проекты для API и клиента. Примеры использования можно посмотреть в тестах. Тесты для API и клиента запускаются одинаково.

Для запуска тестов необходимо добавить в директорию /bin/ собранного проекта добавить appSettings.json следующей структуры:

```Json
{
    "login": "",
    "password": "",
    "token": ""
}
```

По умолчанию авторизация производится по токену, но если он не указан, то произойдёт попытка авторизации по логину и паролю.
Для тестов настроен порядок выполнения, т.к. для функций используются зависимые данные.

LICENCE
-------
[GNU General Public License v3.0](https://github.com/Winster332/Yandex.Music.Api/blob/master/LICENSE)
