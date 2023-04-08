Playlist API
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public Task<List<YResponse<YPlaylist>>> GetPersonalPlaylistsAsync(AuthStorage storage)

Получение списка персональных плейлистов в асинхронном режиме.

.. code-block:: csharp

   public List<YResponse<YPlaylist>> GetPersonalPlaylists(AuthStorage storage)

Получение списка персональных плейлистов.

.. code-block:: csharp

   public async Task<YResponse<List<YPlaylist>>> FavoritesAsync(AuthStorage storage)

Получение списка избранных плейлистов в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YPlaylist>> Favorites(AuthStorage storage)

Получение списка избранных плейлистов.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> OfTheDayAsync(AuthStorage storage)

Получение плейлиста дня в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> OfTheDay(AuthStorage storage)

Получение плейлиста дня.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> DejaVuAsync(AuthStorage storage)

Получение плейлиста Дежавю в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> DejaVu(AuthStorage storage)

Получение плейлиста Дежавю.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> PremiereAsync(AuthStorage storage)

Получение плейлиста Премьера в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> Premiere(AuthStorage storage)

Получение плейлиста Премьера.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> MissedAsync(AuthStorage storage)

Получение плейлиста Тайник в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> Missed(AuthStorage storage)

Получение плейлиста Тайник.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> PodcastsAsync(AuthStorage storage)

Получение плейлиста Подкасты в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> Podcasts(AuthStorage storage)

Получение плейлиста Подкасты.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> KinopoiskAsync(AuthStorage storage)

Получение плейлиста Кинопоиск в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> Kinopoisk(AuthStorage storage)

Получение плейлиста Кинопоиск.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, string user, string kinds)

Получение плейлиста в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> Get(AuthStorage storage, string user, string kinds)

Получение плейлиста.

.. code-block:: csharp

   public Task<YResponse<List<YPlaylist>>> GetAsync(AuthStorage storage, IEnumerable<(string user, string kind)> ids)

Получение списка плейлистов в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YPlaylist>> Get(AuthStorage storage, IEnumerable<(string user, string kind)> ids)

Получение списка плейлистов.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, YPlaylist playlist)

Получение плейлиста в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> Get(AuthStorage storage, YPlaylist playlist)

Получение плейлиста.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> CreateAsync(AuthStorage storage, string name)

Создание плейлиста в асинхронном режиме.

.. note:: Следующие операции можно выполнять только над собственными плейлистами

.. code-block:: csharp

   public YResponse<YPlaylist> Create(AuthStorage storage, string name)

Создание плейлиста.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> RenameAsync(AuthStorage storage, string kinds, string name)

Переименование плейлиста в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> Rename(AuthStorage storage, string kinds, string name)

Переименование плейлиста.

.. code-block:: csharp

   public Task<YResponse<YPlaylist>> RenameAsync(AuthStorage storage, YPlaylist playlist, string name)

Переименование плейлиста в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> Rename(AuthStorage storage, YPlaylist playlist, string name)

Переименование плейлиста.

.. code-block:: csharp

   public async Task<bool> DeleteAsync(AuthStorage storage, string kinds)

Удаление плейлиста в асинхронном режиме.

.. code-block:: csharp

   public bool Delete(AuthStorage storage, string kinds)

Удаление плейлиста.

.. code-block:: csharp

   public Task<bool> DeleteAsync(AuthStorage storage, YPlaylist playlist)

Удаление плейлиста в асинхронном режиме.

.. code-block:: csharp

   public bool Delete(AuthStorage storage, YPlaylist playlist)

Удаление плейлиста.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> InsertTracksAsync(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)

Добавление треков в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> InsertTracks(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)

Добавление треков.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> DeleteTracksAsync(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)

Удаление треков в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> DeleteTracks(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)

Удаление треков.