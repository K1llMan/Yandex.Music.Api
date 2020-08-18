YLibraryAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<YLibraryTracks>> GetLikedTracksAsync(AuthStorage storage)

Получение списка лайкнутых треков в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YLibraryTracks> GetLikedTracks(AuthStorage storage)

Получение списка лайкнутых треков.

.. code-block:: csharp

   public async Task<YResponse<List<YLibraryAlbum>>> GetLikedAlbumsAsync(AuthStorage storage)

Получение списка лайкнутых альбомов в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YLibraryAlbum>> GetLikedAlbums(AuthStorage storage)

Получение списка лайкнутых альбомов.

.. code-block:: csharp

   public async Task<YResponse<List<YArtist>>> GetLikedArtistsAsync(AuthStorage storage)

Получение списка лайкнутых исполнителей в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YArtist>> GetLikedArtists(AuthStorage storage)

Получение списка лайкнутых исполнителей.

.. code-block:: csharp

   public async Task<YResponse<List<YLibraryPlaylists>>> GetLikedPlaylistsAsync(AuthStorage storage)

Получение списка лайкнутых плейлистов в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YLibraryPlaylists>> GetLikedPlaylists(AuthStorage storage)

Получение списка лайкнутых плейлистов.

.. code-block:: csharp

   public async Task<YResponse<YLibraryTrack>> GetDislikedTracksAsync(AuthStorage storage)

Получение списка дизлайкнутых треков в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YLibraryTrack> GetDislikedTracks(AuthStorage storage)

Получение списка дизлайкнутых треков.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> AddTrackLikeAsync(AuthStorage storage, YTrack track)

Добавление трека в список лайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YPlaylist> AddTrackLike(AuthStorage storage, YTrack track)

Добавление трека в список лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<YRevision>> RemoveTrackLikeAsync(AuthStorage storage, YTrack track)

Удаление трека из списка лайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YRevision> RemoveTrackLike(AuthStorage storage, YTrack track)

Удаление трека из списка лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<YRevision>> AddTrackDislikeAsync(AuthStorage storage, YTrack track)

Добавление трека в список дизлайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YRevision> AddTrackDislike(AuthStorage storage, YTrack track)

Добавление трека в список дизлайкнутых.

.. code-block:: csharp

   public async Task<YResponse<int>> RemoveTrackDislikeAsync(AuthStorage storage, YTrack track)

Удаление трека из списка дизлайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YRevision> RemoveTrackDislike(AuthStorage storage, YTrack track)

Удаление трека из списка дизлайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> AddAlbumLikeAsync(AuthStorage storage, YAlbum album)

Добавление альбома в список лайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<string> AddAlbumLike(AuthStorage storage, YAlbum album)

Добавление альбома в список лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> RemoveAlbumLikeAsync(AuthStorage storage, YAlbum album)

Удаление альбома из списка лайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<string> RemoveAlbumLike(AuthStorage storage, YAlbum album)

Удаление альбома из списка лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> AddArtistLikeAsync(AuthStorage storage, YArtist artist)

Добавление исполнителя в список лайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<string> AddArtistLike(AuthStorage storage, YArtist artist)

Добавление исполнителя в список лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> RemoveArtistLikeAsync(AuthStorage storage, YArtist artist)

Удаление исполнителя из списка лайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<string> RemoveArtistLike(AuthStorage storage, YArtist artist)

Удаление исполнителя из списка лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> AddPlaylistLikeAsync(AuthStorage storage, YPlaylist playlist)

Добавление плейлиста в список лайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<string> AddPlaylistLike(AuthStorage storage, YPlaylist playlist)

Добавление плейлиста в список лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> RemovePlaylistLikeAsync(AuthStorage storage, YPlaylist playlist)

Удаление плейлиста из списка лайкнутых в асинхронном режиме.

.. code-block:: csharp

   public YResponse<string> RemovePlaylistLike(AuthStorage storage, YPlaylist playlist)

Удаление плейлиста из списка лайкнутых.