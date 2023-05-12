YandexMusicClient
==================================================================

Класс клиента для работы с API Яндекс.Музыки. Реализует основной функционал получения
объектов для взаимодействия с API. Для самих объектов функционал реализован в виде
методов-расширений.

------------------------------------------------------------------
Свойства
------------------------------------------------------------------

**Context**
   Account, с которым работает клиент.

   **Type**: YAccount

**IsAuthorized**
   Флаг авторизации

   **Type**: bool

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public YandexMusicClient(DebugSettings settings = null)

Конструктор.

.. code-block:: csharp

   public bool Authorize(string token)

Авторизация с использованием токена.


.. code-block:: csharp

   public YAuthTypes CreateAuthSession(string userName)

Создание сеанса и получение доступных методов авторизации.

.. code-block:: csharp

   public string GetAuthQRLink()

Получение ссылки на QR-код.

.. code-block:: csharp

   public YAuthQRStatus AuthorizeByQR()

Авторизация по QR-коду.

.. code-block:: csharp

   public YAuthCaptcha GetCaptcha()

Получение данных captcha.

.. code-block:: csharp

   public YAuthBase AuthorizeByCaptcha(string captcha)

Авторизация по captcha.

.. code-block:: csharp

   public YAuthLetter GetAuthLetter()

Получение письма авторизации на почту пользователя.

.. code-block:: csharp

   public bool AuthorizeByLetter()

Авторизация после подтверждения входа через письмо.

.. code-block:: csharp

   public YAuthBase AuthorizeByAppPassword(string password)

Авторизация с помощью пароля из приложения Яндекс.

.. code-block:: csharp

   public YLoginInfo GetLoginInfo()

Получение информации о пользователе через логин Яндекса.

.. code-block:: csharp

   public YTrack GetTrack(string id)

Получение трека по идентификатору.

.. code-block:: csharp

   public List<YTrack> GetTracks(IEnumerable<string> ids)

Получение списка треков по идентификаторам.

.. code-block:: csharp

   public YAlbum GetAlbum(string id)

Получение альбома по идентификатору.

.. code-block:: csharp

   public List<YAlbum> GetAlbums(IEnumerable<string> ids)

Получение списка альбомов по идентификаторам.

.. code-block:: csharp

   public YLanding GetLanding(params YLandingBlockType[] blocks)

Получение блоков главной страницы.   

.. code-block:: csharp

   public YFeed Feed()

Получение ленты.   

.. code-block:: csharp

   public YArtistBriefInfo GetArtist(string id)

Получение исполнителя по идентификатору.

.. code-block:: csharp

   public List<YArtist> GetArtists(IEnumerable<string> ids)

Получение списка исполнителей по идентификаторам.

.. code-block:: csharp

   public YPlaylist GetPlaylist(string user, string id)

Получение плейлиста по пользователю и идентификатору.

.. code-block:: csharp

   public List<YPlaylist> GetPlaylists(IEnumerable<(string user, string id)> ids)

Получение списка плейлистов по пользователю и идентификатору.

.. code-block:: csharp

   public List<YPlaylist> GetPersonalPlaylists()

Получение персональных плейлистов.

.. code-block:: csharp

   public List<YPlaylist> GetFavorites()

Получение списка избранных плейлистов.

.. code-block:: csharp

   public YPlaylist GetDejaVu()

Получение плейлиста Дежавю.

.. code-block:: csharp

   public YPlaylist GetMissed()

Получение плейлиста Тайник.

.. code-block:: csharp

   public YPlaylist GetOfTheDay()

Получение плейлиста дня.

.. code-block:: csharp

   public YPlaylist GetPodcasts()

Получение плейлиста Подкасты.

.. code-block:: csharp

   public YPlaylist GetKinopoisk()

Получение плейлиста Кинопоиск.

.. code-block:: csharp

   public YPlaylist GetPremiere()

Получение плейлиста Премьера.

.. code-block:: csharp

   public YPlaylist CreatePlaylist(string name)

Создание плейлиста.

.. code-block:: csharp

   public YSearch Search(string searchText, YSearchType searchType, int page = 0, int pageSize = 20)

Поиск.

.. code-block:: csharp

   public YSearchSuggest GetSearchSuggestions(string searchText)

Подсказки по поиску.

.. code-block:: csharp

   public List<YTrack> GetLikedTracks()

Получение списка понравившихся треков.

.. code-block:: csharp

   public List<YTrack> GetDislikedTracks()

Получение списка непонравившихся треков.

.. code-block:: csharp

   public List<YAlbum> GetLikedAlbums()

Получение списка понравившихся альбомов.

.. code-block:: csharp

   public List<YArtist> GetLikedArtists()

Получение списка понравившихся исполнителей.

.. code-block:: csharp

   public List<YArtist> GetDislikedArtists()

Получение списка непонравившихся исполнителей.

.. code-block:: csharp

   public List<YPlaylist> GetLikedPlaylists()

Получение списка понравившихся плейлистов.

.. code-block:: csharp

   public List<YStation> GetRadioDashboard()

Получение списка рекомендованных радиостанций.

.. code-block:: csharp

   public List<YStation> GetRadioStations()

Получение списка радиостанций.

.. code-block:: csharp

   public YStation GetRadioStation(YStationId id)

Получение радиостанции по идентификатору.

.. code-block:: csharp

   public YQueueItemsContainer QueuesList(string device = null)

Получение всех очередей треков с разных устройств для синхронизации между ними.

.. code-block:: csharp

   public YQueue GetQueue(string queueId)

Получение очереди.

.. code-block:: csharp

   public YNewQueue CreateQueue(YQueue queue, string device = null)

Создание новой очереди треков.

.. code-block:: csharp

   public YUpdatedQueue QueueUpdatePosition(string queueId, int currentIndex, bool isInteractive, string device = null)

Установка текущего индекса проигрываемого трека в очереди треков.