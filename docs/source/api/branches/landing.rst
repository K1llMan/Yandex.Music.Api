YLandingAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp
   
   public Task<YResponse<YLanding>> GetAsync(AuthStorage storage, params YLandingBlockType[] blocks)

Получение блоков главной страницы в асинхронном режиме.

.. code-block:: csharp
   
   public YResponse<YLanding> Get(AuthStorage storage, params YLandingBlockType[] blocks)

Получение блоков главной страницы.

.. code-block:: csharp

   public Task<YResponse<YFeed>> GetFeedAsync(AuthStorage storage)

Получение ленты в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YFeed> GetFeed(AuthStorage storage)

Получение ленты.