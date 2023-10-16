YLibraryAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<YLibraryTracks>> GetLikedTracksAsync(AuthStorage storage)

Получение списка лайкнутых треков.

.. code-block:: csharp

   public async Task<YResponse<List<YLibraryAlbum>>> GetLikedAlbumsAsync(AuthStorage storage)

Получение списка лайкнутых альбомов.

.. code-block:: csharp

   public async Task<YResponse<List<YArtist>>> GetLikedArtistsAsync(AuthStorage storage)

Получение списка лайкнутых исполнителей.

.. code-block:: csharp

   public async Task<YResponse<List<YLibraryPlaylists>>> GetLikedPlaylistsAsync(AuthStorage storage)

Получение списка лайкнутых плейлистов.

.. code-block:: csharp

   public async Task<YResponse<YLibraryTrack>> GetDislikedTracksAsync(AuthStorage storage)

Получение списка дизлайкнутых треков.

.. code-block:: csharp

   public async Task<YResponse<YPlaylist>> AddTrackLikeAsync(AuthStorage storage, YTrack track)

Добавление трека в список лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<YRevision>> RemoveTrackLikeAsync(AuthStorage storage, YTrack track)

Удаление трека из списка лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<YRevision>> AddTrackDislikeAsync(AuthStorage storage, YTrack track)

Добавление трека в список дизлайкнутых.

.. code-block:: csharp

   public async Task<YResponse<YRevision>> RemoveTrackDislikeAsync(AuthStorage storage, YTrack track)

Удаление трека из списка дизлайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> AddAlbumLikeAsync(AuthStorage storage, YAlbum album)

Добавление альбома в список лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> RemoveAlbumLikeAsync(AuthStorage storage, YAlbum album)

Удаление альбома из списка лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> AddArtistLikeAsync(AuthStorage storage, YArtist artist)

Добавление исполнителя в список лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> RemoveArtistLikeAsync(AuthStorage storage, YArtist artist)

Удаление исполнителя из списка лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> AddPlaylistLikeAsync(AuthStorage storage, YPlaylist playlist)

Добавление плейлиста в список лайкнутых.

.. code-block:: csharp

   public async Task<YResponse<string>> RemovePlaylistLikeAsync(AuthStorage storage, YPlaylist playlist)

Удаление плейлиста из списка лайкнутых.