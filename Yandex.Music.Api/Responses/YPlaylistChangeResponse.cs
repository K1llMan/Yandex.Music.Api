using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Models;

namespace Yandex.Music.Api.Responses
{
  public class YPlaylistChangeResponse
  {
    public bool Success { get; set; }
    public YLibraryResponse.YandexLibraryPlaylist Playlist { get; set; }

    public static YPlaylistChangeResponse FromJson(JToken json)
    {
      var x = json["playlist"];

      var playlistOwner = new YandexOwner
      {
        Uid = x["owner"]["uid"].ToObject<string>(),
        Login = x["owner"]["login"].ToObject<string>(),
        Name = x["owner"]["name"].ToObject<string>(),
        Sex = x["owner"]["sex"]?.ToObject<string>(),
        Verified = x["owner"]["verified"]?.ToObject<bool>()
      };

      var tracks = x.SelectToken("tracks")?.Select(f =>
        new YLibraryResponse.YandexLibraryPlaylist.YandexLibraryPlaylistTrack
        {
          Id = f["id"]?.ToObject<long?>(),
          Timestamp = f["timestamp"]?.ToObject<string>(),
          AlbumId = f["albumId"]?.ToObject<long?>()
        }).ToList();

      var libraryCover = default(YLibraryResponse.YandexLibraryPlaylist.YandexLibraryPlaylistCover);

      if (x.SelectToken("cover")?.SelectToken("error") != null)
      {
        libraryCover = new YLibraryResponse.YandexLibraryPlaylist.YandexLibraryPlaylistCoverError
        {
          Error = x["cover"]["error"].ToObject<string>()
        };
      }
      else if (x.SelectToken("cover")?.SelectToken("type").ToObject<string>() == "mosaic")
      {
        libraryCover = new YLibraryResponse.YandexLibraryPlaylist.YandexLibraryPlaylistCoverMosaic
        {
          Type = x["cover"]["type"].ToObject<string>(),
          ItemsUri = x["cover"]["itemsUri"].Select(f => f.ToObject<string>()).ToList(),
          Custom = x["cover"]["custom"].ToObject<bool>()
        };
      }
      else if (x.SelectToken("cover")?.SelectToken("type").ToObject<string>() == "pic")
      {
        libraryCover = new YLibraryResponse.YandexLibraryPlaylist.YandexLibraryPlaylistCoverPic
        {
          Type = x["cover"]["type"].ToObject<string>(),
          Dir = x["cover"]["dir"].ToObject<string>(),
          Version = x["cover"]["version"].ToObject<string>(),
          Uri = x["cover"]["uri"].ToObject<string>(),
          Custom = x["cover"]["custom"].ToObject<bool>()
        };
      }

      var playlist = new YLibraryResponse.YandexLibraryPlaylist
      {
        Owner = playlistOwner,
        Available = x["available"]?.ToObject<bool>(),
        Uid = x["uid"]?.ToObject<long>(),
        Kind = x["kind"]?.ToObject<long>(),
        Title = x["title"]?.ToObject<string>(),
        Revision = x["revision"]?.ToObject<long>(),
        Snapshot = x["snapshot"]?.ToObject<long>(),
        TrackCount = x["trackCount"]?.ToObject<long>(),
        Visibility = x["visibility"]?.ToObject<string>(),
        Collective = x["collective"]?.ToObject<bool>(),
        Created = x["created"]?.ToObject<string>(),
        Modified = x["modified"]?.ToObject<string>(),
        IsBanner = x["isBanner"]?.ToObject<bool>(),
        IsPremiere = x["isPremiere"]?.ToObject<bool>(),
        DurationMs = x["durationMs"]?.ToObject<long>(),
        Cover = libraryCover,
        OgImage = x["ogImage"]?.ToObject<string>(),
        Tracks = tracks,
        Tags = x["tags"]?.ToString(),
        Prerolls = x["prerolls"]?.ToString(),
      };

      return new YPlaylistChangeResponse
      {
        Success = json["success"].ToObject<bool>(),
        Playlist = playlist
      };
    }
  }
}
