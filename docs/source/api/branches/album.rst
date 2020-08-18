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