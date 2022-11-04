YArtistAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public Task<YResponse<YFeed>> GetFeedAsync(AuthStorage storage)

Получение ленты в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YFeed> GetFeed(AuthStorage storage)

Получение ленты.