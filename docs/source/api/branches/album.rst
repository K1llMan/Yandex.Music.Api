YAlbumAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<YAlbum>> GetAsync(AuthStorage storage, string albumId)

Получение альбома в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YAlbum> Get(AuthStorage storage, string albumId)

Получение альбома.

.. code-block:: csharp

   public Task<YResponse<List<YAlbum>>> GetListAsync(AuthStorage storage, params string[] albumIds)

Получение списка альбомов.

.. code-block:: csharp

   public YResponse<List<YAlbum>> GetList(AuthStorage storage, params string[] albumIds)

Получение списка альбомов.