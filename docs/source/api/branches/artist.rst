YArtistAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<YArtistBriefInfo>> GetAsync(AuthStorage storage, string artistId)

Получение исполнителя в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YArtistBriefInfo> Get(AuthStorage storage, string artistId)

Получение исполнителя.