YArtistAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<YArtistBriefInfo>> GetAsync(AuthStorage storage, string artistId)

Получение исполнителя.

.. code-block:: csharp

   public Task<YResponse<List<YArtist>>> GetAsync(AuthStorage storage, IEnumerable<string> artistIds)

Получение списка исполнителей.

.. code-block:: csharp

   public Task<YResponse<YTracksPage>> GetTracksAsync(AuthStorage storage, string artistId, int page = 0, int pageSize = 20)

Получение списка треков исполнителя с пагинацией.

.. code-block:: csharp

   public Task<YResponse<YTracksPage>> GetAllTracksAsync(AuthStorage storage, string artistId)

Получение списка всех треков исполнителя.