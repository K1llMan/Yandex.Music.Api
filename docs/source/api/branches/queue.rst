YQueueAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public Task<YResponse<YQueueItemsContainer>> ListAsync(AuthStorage storage, string device = null)

Получение всех очередей треков с разных устройств для синхронизации между ними в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YQueueItemsContainer> List(AuthStorage storage, string device = null)

Получение всех очередей треков с разных устройств для синхронизации между ними.

.. code-block:: csharp

   public Task<YResponse<YQueue>> GetAsync(AuthStorage storage, string queueId)

Получение очереди в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YQueue> Get(AuthStorage storage, string queueId)

Получение очереди.

.. code-block:: csharp

   public Task<YResponse<YNewQueue>> CreateAsync(AuthStorage storage, YQueue queue, string device = null)

Создание новой очереди треков в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YNewQueue> Create(AuthStorage storage, YQueue queue, string device = null)

Создание новой очереди треков.

.. code-block:: csharp

   public Task<YResponse<YUpdatedQueue>> UpdatePositionAsync(AuthStorage storage, string queueId, int currentIndex, bool isInteractive, string device = null)

Установка текущего индекса проигрываемого трека в очереди треков в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YUpdatedQueue> UpdatePosition(AuthStorage storage, string queueId, int currentIndex, bool isInteractive, string device = null)

Установка текущего индекса проигрываемого трека в очереди треков.