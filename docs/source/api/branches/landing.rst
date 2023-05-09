YLandingAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp
   
   public Task<YResponse<YLanding>> GetAsync(AuthStorage storage, params YLandingBlockType[] blocks)

Получение блоков главной страницы.

.. code-block:: csharp

   public Task<YResponse<YFeed>> GetFeedAsync(AuthStorage storage)

Получение ленты.