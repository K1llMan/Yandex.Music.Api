Search API
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<YSearch>> TrackAsync(AuthStorage storage, string trackName, int pageNumber = 0, int pageSize = 20)

Поиск по трекам.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> AlbumsAsync(AuthStorage storage, string albumName, int pageNumber = 0, int pageSize = 20)

Поиск по альбомам.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> ArtistAsync(AuthStorage storage, string artistName, int pageNumber = 0, int pageSize = 20)

Поиск по исполнителям.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> PlaylistAsync(AuthStorage storage, string playlistName, int pageNumber = 0, int pageSize = 20)

Поиск по плейлистам.

.. code-block:: csharp

   public YResponse<YSearch> PodcastEpisodeAsync(AuthStorage storage, string podcastName, int pageNumber = 0, int pageSize = 20)

Поиск по подкастам.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> VideosAsync(AuthStorage storage, string videoName, int pageNumber = 0, int pageSize = 20)

Поиск по видеозаписям.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> UsersAsync(AuthStorage storage, string userName, int pageNumber = 0, int pageSize = 20)

Поиск по пользователям.

.. code-block:: csharp

   public async Task<YResponse<YSearch>> SearchAsync(AuthStorage storage, string searchText, YSearchType searchType, int page = 0, int pageSize = 20)

Поиск.

.. code-block:: csharp

   public async Task<YResponse<YSearchSuggest>> SuggestAsync(AuthStorage storage, string searchText)

Получение подсказок по поиску.