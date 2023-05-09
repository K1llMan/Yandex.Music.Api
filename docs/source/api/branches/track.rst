Track API
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public Task<YResponse<List<YTrack>>> GetAsync(AuthStorage storage, string trackId)

Получение трека.

.. code-block:: csharp

   public Task<YResponse<List<YTrack>>> GetAsync(AuthStorage storage, IEnumerable<string> trackIds)

Получение списка треков.

.. note:: Здесь и далее trackKey формируется в формате "<id альбома>:<id трека>".


.. code-block:: csharp

   public async Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, string trackKey, bool direct)

Получение метаданных для загрузки.

.. code-block:: csharp

   public async Task<YResponse<List<YTrackDownloadInfo>>> GetMetadataForDownloadAsync(AuthStorage storage, YTrack track, bool direct = false)

Получение метаданных для загрузки.

.. code-block:: csharp

   public async Task<YStorageDownloadFile> GetDownloadFileInfoAsync(AuthStorage storage, YTrackDownloadInfo metadataInfo)

Получение данных для формирования ссылки.

.. code-block:: csharp

   public string GetFileLinkAsync(AuthStorage storage, string trackKey)

Получение ссылки.

.. code-block:: csharp

   public string GetFileLinkAsync(AuthStorage storage, YTrack track)

Получение ссылки.

.. code-block:: csharp

   public void ExtractToFileAsync(AuthStorage storage, string trackKey, string filePath)

Сохранение в файл.

.. code-block:: csharp

   public void ExtractToFileAsync(AuthStorage storage, YTrack track, string filePath)

Сохранение в файл.

.. code-block:: csharp

   public byte[] ExtractDataAsync(AuthStorage storage, string trackKey)

Получение данных в виде двоичного массива.

.. code-block:: csharp

   public byte[] ExtractDataAsync(AuthStorage storage, YTrack track)

Получение данных в виде двоичного массива.

.. code-block:: csharp

   public byte[] ExtractStreamAsync(AuthStorage storage, string trackKey)

Получение данных в виде потока.

.. code-block:: csharp

   public byte[] ExtractStreamAsync(AuthStorage storage, YTrack track)

Получение данных в виде потока.

.. code-block:: csharp

   public Task<YResponse<YTrackSupplement>> GetSupplementAsync(AuthStorage storage, string trackId)

Получение дополнительной информации для трека.

.. code-block:: csharp

   public Task<YResponse<YTrackSupplement>> GetSupplementAsync(AuthStorage storage, YTrack track)

Получение дополнительной информации для трека.

.. code-block:: csharp

   public Task<YResponse<YTrackSimilar>> GetSimilarAsync(AuthStorage storage, string trackId)

Получение похожих треков.

.. code-block:: csharp

   public Task<YResponse<YTrackSimilar>> GetSimilarAsync(AuthStorage storage, YTrack track)

Получение похожих треков.