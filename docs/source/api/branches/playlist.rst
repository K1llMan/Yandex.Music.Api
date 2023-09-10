Playlist API
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public Task<List<YResponse<YPlaylist>>> GetPersonalPlaylistsAsync(AuthStorage storage)

Получение списка персональных плейлистов.

.. code-block:: csharp

   public async Task<YResponse<List<YPlaylist>>> FavoritesAsync(AuthStorage storage)

Получение списка избранных плейлистов.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> OfTheDayAsync(AuthStorage storage)

Получение плейлиста дня.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> DejaVuAsync(AuthStorage storage)

Получение плейлиста Дежавю.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> PremiereAsync(AuthStorage storage)

Получение плейлиста Премьера .

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> MissedAsync(AuthStorage storage)

Получение плейлиста Тайник.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> KinopoiskAsync(AuthStorage storage)

Получение плейлиста Кинопоиск.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, string user, string kinds)

Получение плейлиста.

.. code-block:: csharp

   public Task<YResponse<List<YPlaylist>>> GetAsync(AuthStorage storage, IEnumerable<(string user, string kind)> ids)

Получение списка плейлистов.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> GetAsync(AuthStorage storage, YPlaylist playlist)

Получение плейлиста.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> CreateAsync(AuthStorage storage, string name)

Создание плейлиста.

.. note:: Следующие операции можно выполнять только над собственными плейлистами

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> RenameAsync(AuthStorage storage, string kinds, string name)

Переименование плейлиста.

.. code-block:: csharp

   public Task<YResponse<YPlaylist>> RenameAsync(AuthStorage storage, YPlaylist playlist, string name)

Переименование плейлиста.

.. code-block:: csharp

   public async Task<bool> DeleteAsync(AuthStorage storage, string kinds)

Удаление плейлиста.

.. code-block:: csharp

   public Task<bool> DeleteAsync(AuthStorage storage, YPlaylist playlist)

Удаление плейлиста.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> InsertTracksAsync(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)

Добавление треков.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> DeleteTracksAsync(AuthStorage storage, YPlaylist playlist, IEnumerable<YTrack> tracks)

Удаление треков.