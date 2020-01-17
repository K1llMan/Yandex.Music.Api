using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Extensions;

namespace Yandex.Music.Api.Responses
{
  public class YTrackResponse
  {
    public string Id { get; set; }
    public List<YAlbumResponse> Albums { get; set; }
    public string RealId { get; set; }
    public string Title { get; set; }
    public YMajor Major { get; set; }
    public bool? Available { get; set; }
    public bool? AvailableForPremiumUsers { get; set; }
    public int? DurationMS { get; set; }
    public string StorageDir { get; set; }
    public int? FileSize { get; set; }
    public List<YArtistResponse> Artists { get; set; }
    public string OgImage { get; set; }
    
    

    public string GetKey()
    {
      return $"{Id}:{Albums.FirstOrDefault().Id}";
    }

    public static YTrackResponse FromJson(JToken jTrack)
    {
      try
      {
        var track = new YTrackResponse
        {
          Id = jTrack.GetString("id"),
          RealId = jTrack.GetString("realId"),
          Title = jTrack.GetString("title"),
          Major = YMajor.FromJson(jTrack.Contains("major")),
          Available = jTrack.GetBool("available"),
          AvailableForPremiumUsers = jTrack.GetBool("availableForPremiumUsers"),
          Albums = jTrack.ContainField("albums")
            ? YAlbumResponse.FromJsonArray(jTrack["albums"].ToObject<JArray>())
            : null,
          DurationMS = jTrack["durationMs"].ToObject<int>(),
          StorageDir = jTrack.GetString("storageDir"),
          FileSize = jTrack.GetInt("fileSize"),
          Artists = YArtistResponse.FromJsonArray(jTrack["artists"].ToObject<JArray>()),
          OgImage = jTrack.GetString("ogImage")
        };
        return track;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }

      return null;
    }

    public static List<YTrackResponse> FromJsonArray(JArray jTracks)
    {
      var list = new List<YTrackResponse>();

      for (var i = 0; i < jTracks.Count; i++)
      {
        var jTrack = jTracks[i];
        var track = FromJson(jTrack);


        list.Add(track);
      }

      return list;
    }
  }
}
