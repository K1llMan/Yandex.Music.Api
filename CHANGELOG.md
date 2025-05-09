# История изменений

## 2.0.3
* Актуализированы модели. ([BloodyBaRGaIn](https://github.com/BloodyBaRGaIn))
## 2.0.2
* Добавлен метод получения плейлиста по uuid.
* Актуализированы модели.
## 2.0.1
* Актуализированы модели.
## 2.0.0
* Добавлена базовая поддержка Унисон. Спасибо ([Yaroslav](https://github.com/asnct)) за gist с примером подключения.
## 1.10.1
* Актуализированы модели. (feat. [BloodyBaRGaIn](https://github.com/BloodyBaRGaIn))
## 1.10.0
* Добавлено получение списка последних прослушиваний и лэндинга детского раздела. ([PrepConcedeITIS](https://github.com/PrepConcedeITIS))
* Актуализированы модели.
## 1.9.0
* Добавлено получение информации по лейблам. ([PrepConcedeITIS](https://github.com/PrepConcedeITIS))
## 1.8.0
* Добавлена загрузка пользовательских треков. ([PrepConcedeITIS](https://github.com/PrepConcedeITIS))
* Методы-расширения перемещены в модуль с API.
* Внутренний рефакторинг.
## 1.7.2
* Актуализированы модели.
## 1.7.1
* Добавлено значение для метода авторизации.
## 1.7.0
* Методы для для отправки текущего состояния трека и обратной связи для радио. ([martin211](https://github.com/martin211))
## 1.6.0
* Версии .Net подняты до актуальных, соответственно подняты версии зависимостей.
* Актуализированы модели.
## 1.5.0
* Актуализированы модели.
* Тип плейлиста теперь является строкой.
* Удален метод для плейлиста подкастов.
## 1.4.2
* Актуализированы модели.
## 1.4.1
* Актуализированы модели.
## 1.4.0
* Удалена авторизация по логину и паролю, как устаревшая.
* Классы API для удобства разбиты на асинхронную и синхронную части.
* Добавлены асинхронные методы-расширения.
* Добавлен асинхронный клиент (требует тестирования).
* Добавлены методы получения треков по исполнителю. ([Lauriero](https://github.com/Lauriero))
* Для методов поиска добавлен параметр с размером страницы.
* Добавлен метод получения информации о пользователе через логин Яндекса.
## 1.3.6
* Добавлены асинхронные методы для получения ссылки на файл, для сохранения, получения массива байт и потока.
* Актуализированы модели.
## 1.3.5
* Актуализированы модели.
## 1.3.4
* Добавлен тип Notification для сообщения ленты.
* Исправлена обработка ошибок десериализации.
* Актуализированы модели.
## 1.3.3
* Исправления для корректной работы с пользовательскими треками. ([PrepConcedeITIS](https://github.com/PrepConcedeITIS))
## 1.3.2
* Дополнены модели авторизации.
* Вынесен интерфейс IDebugWriter для реализации пользовательского отладочного логирования.
## 1.3.1
* Дополнен список методов авторизации YAuthMethod.
## 1.3.0
* API для работы c очередями. ([shuryak](https://github.com/shuryak))
* Актуализированы модели.
## 1.2.1
* Исправление авторизаций.
## 1.2.0
* Добавлены различные варианты авторизации. ([martin211](https://github.com/martin211))
## 1.1.1
* Актуализированы модели.
* Поддержка netstandard2.0.
## 1.1.0
* Актуализированы модели.
* Удалены ненужные async/await.
* Новый механизм описания запросов к API.
* Механизм провайдеров для выполнения запросов к API.
* Методы и модели для запроса ленты.
* Методы для запроса блоков главной страницы.
* Методы для получения похожих треков и дополнительной информации для трека.
* Методы для запроса списка треков, альбомов, исполнителей и плейлистов.
* На клиенте синхронизирован функционал с API, добавлены методы-расширения.
## 1.0.1
* Актуализированы модели.
* Исправлены ошибки десериализации поля Labels модели YAlbum.
* Рефакторинг под Net 5.0.
* Поиск по подкастам.
* При получении ссылки на трек выбирается версия с максимальным битрейтом.
## 1.0.0
Начальный коммит.
