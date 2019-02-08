using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Extensions;

namespace Yandex.Music
{
  public class YandexTrack : IYandexSearchable
  {
    public string Id { get; set; }
    public List<YandexAlbum> Albums { get; set; }
    public string RealId { get; set; }
    public string Title { get; set; }
    public YandexMajor Major { get; set; }
    public bool? Available { get; set; }
    public bool? AvailableForPremiumUsers { get; set; }
    public int? DurationMS { get; set; }
    public string StorageDir { get; set; }
    public int? FileSize { get; set; }
    public List<YandexArtist> Artists { get; set; }
    public string OgImage { get; set; }

    public static YandexTrack FromJson(JToken jTrack)
    {
      try
      {
        var track = new YandexTrack
        {
          Id = jTrack.GetString("id"),
          RealId = jTrack.GetString("realId"),
          Title = jTrack.GetString("title"),
          Major = YandexMajor.FromJson(jTrack.Contains("major")),
          Available = jTrack.GetBool("available"),
          AvailableForPremiumUsers = jTrack.GetBool("availableForPremiumUsers"),
          Albums = jTrack.ContainField("albums") ? YandexAlbum.FromJsonArray(jTrack["albums"].ToObject<JArray>()) : null,
          DurationMS = jTrack["durationMs"].ToObject<int>(),
          StorageDir = jTrack.GetString("storageDir"),
          FileSize = jTrack.GetInt("fileSize"),
          Artists = YandexArtist.FromJsonArray(jTrack["artists"].ToObject<JArray>()),
          OgImage = jTrack.GetString("ogImage")
        };
        return track;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }

      return null;
    }

    public static List<YandexTrack> FromJsonArray(JArray jTracks)
    {
      var list = new List<YandexTrack>();

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