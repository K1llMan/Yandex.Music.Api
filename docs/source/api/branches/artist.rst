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