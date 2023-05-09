YAlbumAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

``` csharp
public async Task<YResponse<YAlbum>> GetAsync(AuthStorage storage, string albumId)
```  

Получение альбома.

``` csharp
public Task<YResponse<List<YAlbum>>> GetAsync(AuthStorage storage, <string> albumIds)
```

Получение списка альбомов.