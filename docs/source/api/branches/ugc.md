YUgcAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

``` csharp
public Task<YUgcUpload> GetUgcUploadLinkAsync(AuthStorage storage, YPlaylist playlist, string fileName)
```  

Получение ссылки на загрузчик трека.

``` csharp
public Task<YResponse<string>> UploadUgcTrackAsync(AuthStorage storage, string uploadLink, string filePath)
```

Загрузка трека из файла.

``` csharp
public Task<YResponse<string>> UploadUgcTrackAsync(AuthStorage storage, string uploadLink, Stream stream)
```

Загрузка трека из потока.

``` csharp
public Task<YResponse<string>> UploadUgcTrackAsync(AuthStorage storage, string uploadLink, byte[] file)
```

Загрузка трека из массива.