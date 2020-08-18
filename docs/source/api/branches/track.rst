Track API
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public async Task<YResponse<List<YTrack>>> GetAsync(AuthStorage storage, string trackId)

Получение трека в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YTrack>> Get(AuthStorage storage, string trackId)

Получение трека.

.. note:: Здесь и далее trackKey формируется в формате "<id альбома>:<id трека>".


.. code-block:: csharp

   public async Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, string trackKey, bool direct)

Получение метаданных для загрузки в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YTrackDownloadInfo>> GetMetadataForDownload(AuthStorage storage, string trackKey, bool direct = false)

Получение метаданных для загрузки.

.. code-block:: csharp

   public async Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, YTrack track, bool direct = false)

Получение метаданных для загрузки в асинхронном режиме.

.. code-block:: csharp

   public YResponse<List<YTrackDownloadInfo>> GetMetadataForDownload(AuthStorage storage, YTrack track, bool direct = false)

Получение метаданных для загрузки.

.. code-block:: csharp

   public async Task<YStorageDownloadFile> GetDownloadFileInfoAsync(AuthStorage storage, YTrackDownloadInfo metadataInfo)

Получение данных для формирования ссылки в асинхронном режиме.

.. code-block:: csharp

   public YStorageDownloadFile GetDownloadFileInfo(AuthStorage storage, YTrackDownloadInfo metadataInfo)

Получение данных для формирования ссылки.

.. code-block:: csharp

   public string GetFileLink(AuthStorage storage, string trackKey)

Получение ссылки.

.. code-block:: csharp

   public string GetFileLink(AuthStorage storage, YTrack track)

Получение ссылки.

.. code-block:: csharp

   public void ExtractToFile(AuthStorage storage, string trackKey, string filePath)

Сохранение в файл.

.. code-block:: csharp

   public void ExtractToFile(AuthStorage storage, YTrack track, string filePath)

Сохранение в файл.

.. code-block:: csharp

   public byte[] ExtractData(AuthStorage storage, string trackKey)

Получение данных в виде двоичного массива.

.. code-block:: csharp

   public byte[] ExtractData(AuthStorage storage, YTrack track)

Получение данных в виде двоичного массива.