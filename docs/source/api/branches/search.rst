Search API
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<YSearch>> TrackAsync(AuthStorage storage, string trackName, int pageNumber = 0)

Поиск по трекам в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YSearch> Track(AuthStorage storage, string trackName, int pageNumber = 0)

Поиск по трекам.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> AlbumsAsync(AuthStorage storage, string albumName, int pageNumber = 0)

Поиск по альбомам в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YSearch> Albums(AuthStorage storage, string albumName, int pageNumber = 0)

Поиск по альбомам.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> ArtistAsync(AuthStorage storage, string artistName, int pageNumber = 0)

Поиск по исполнителям в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YSearch> Artist(AuthStorage storage, string artistName, int pageNumber = 0)

Поиск по исполнителям.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> PlaylistAsync(AuthStorage storage, string playlistName, int pageNumber = 0)

Поиск по плейлистам в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YSearch> Playlist(AuthStorage storage, string playlistName, int pageNumber = 0)

Поиск по плейлистам.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> VideosAsync(AuthStorage storage, string videoName, int pageNumber = 0)

Поиск по видеозаписям в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YSearch> Videos(AuthStorage storage, string videoName, int pageNumber = 0)

Поиск по видеозаписям.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> UsersAsync(AuthStorage storage, string userName, int pageNumber = 0)

Поиск по пользователям в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YSearch> Users(AuthStorage storage, string userName, int pageNumber = 0)

Поиск по пользователям.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> SearchAsync(AuthStorage storage, string searchText, YSearchType searchType, int page = 0)

Поиск в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YSearch> Search(AuthStorage storage, string searchText, YSearchType searchType, int page = 0)

Поиск.

.. code-block:: csharp

   public async Task<YResponse<YSearchSuggest>> SuggestAsync(AuthStorage storage, string searchText)

Получение подсказок по поиску в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YSearchSuggest> Suggest(AuthStorage storage, string searchText)

Получение подсказок по поиску.