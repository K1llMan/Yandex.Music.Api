Radio API
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<YStationsDashboard>> GetStationsDashboardAsync(AuthStorage storage)

Получение списка рекомендованных радиостанций в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YStationsDashboard> GetStationsDashboard(AuthStorage storage)

Получение списка рекомендованных радиостанций.

.. code-block:: csharp

   public async Task<YResponse<List<YStation>>> GetStationsAsync(AuthStorage storage)

Получение списка радиостанций в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YStation>> GetStations(AuthStorage storage)

Получение списка радиостанций.

.. code-block:: csharp

   public async Task<YResponse<List<YStation>>> GetStationAsync(AuthStorage storage, string type, string tag)

Получение информации о радиостанции в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YStation>> GetStation(AuthStorage storage, string type, string tag)

Получение информации о радиостанции.

.. code-block:: csharp

   public Task<YResponse<List<YStation>>> GetStationAsync(AuthStorage storage, YStationId id)

Получение информации о радиостанции в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YStation>> GetStation(AuthStorage storage, YStationId id)

Получение информации о радиостанции.

.. code-block:: csharp

   public async Task<YResponse<YStationSequence>> GetStationTracksAsync(AuthStorage storage, YStation station, string prevTrackId = "")

Получение треков радиостанции в асинхронном режиме.

.. code-block:: csharp

   public YResponse<YStationSequence> GetStationTracks(AuthStorage storage, YStation station, string prevTrackId = "")

Получение треков радиостанции.

.. code-block:: csharp

   public async Task<YResponse<string>> SetStationSettings2Async(AuthStorage storage, YStation station, YStationSettings2 settings)

Установка настроек радиостанции в асинхронном режиме.

.. code-block:: csharp

   public YResponse<string> SetStationSettings2(AuthStorage storage, YStation station, YStationSettings2 settings)

Установка настроек радиостанции.