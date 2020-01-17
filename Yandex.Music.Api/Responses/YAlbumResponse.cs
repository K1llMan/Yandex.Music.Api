using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Responses
{
  public class YAlbumResponse
  {
    public List<YArtistResponse> Artists { get; set; }
    public bool? Available { get; set; }
    public bool? AvailableForPremiumUsers { get; set; }
    public string CoverUri { get; set; }
    public string Genre { get; set; }
    public string Id { get; set; }
    public string OriginalReleaseYear { get; set; }
    public List<string> Regions { get; set; }
    public string StorageDir { get; set; }
    public string Title { get; set; }
    public int? TrackCount { get; set; }
    public string Year { get; set; }
    public List<string> Bests { get; set; }
    public string Type { get; set; }
    public List<List<YTrackResponse>> Volumes { get; set; }

    public static YAlbumResponse FromJson(JToken jAlbum)
    {
      var album = new YAlbumResponse
      {
        Artists = YArtistResponse.FromJsonArray(jAlbum["artists"].ToObject<JArray>()),
        Available = jAlbum.GetBool("available"),
        AvailableForPremiumUsers = jAlbum.GetBool("availableForPremiumUsers"),
        CoverUri = jAlbum.GetString("coverUri"),
        Genre = jAlbum.GetString("genre"),
        Id = jAlbum.GetString("id"),
        OriginalReleaseYear = jAlbum.GetString("originalReleaseYear"),
        Regions = jAlbum.Contains("regions")
          ? jAlbum["regions"].ToObject<JArray>().Select(x => (string) x).ToList()
          : null,
        StorageDir = jAlbum.GetString("storageDir"),
        Title = jAlbum.GetString("title"),
        TrackCount = jAlbum.GetInt("trackCount"),
        Year = jAlbum.GetString("year"),
        Bests = jAlbum.ContainField("bests")
          ? jAlbum["bests"].ToObject<JArray>().Select(x => x.ToString()).ToList()
          : null,
        Type = jAlbum.GetString("type"),
      };

      if (jAlbum.ContainField("volumes"))
      {
        if (jAlbum["volumes"].ToString() != String.Empty)
        {
          var fieldVolumes = jAlbum["volumes"].ToObject<JArray>().FirstOrDefault();
          if (fieldVolumes != null)
          {
            var jVolumes = fieldVolumes.ToObject<JArray>();
            var tracks = YTrackResponse.FromJsonArray(jVolumes);
            album.Volumes = new List<List<YTrackResponse>> {tracks};
          }
          else
          {
            album.Volumes = null;
          }
        }
      }
//      album.Volumes = jAlbum.ContainField("volumes")
//        ? new List<List<Track>>
//        {
//          Track.FromJsonArray(jAlbum["volumes"].ToObject<JArray>().First().ToObject<JArray>())
//        }
//        : null;

      return album;
    }

    public static List<YAlbumResponse> FromJsonArray(JArray jAlbums)
    {
      return jAlbums.Select(FromJson).ToList();
    }
  }
}
