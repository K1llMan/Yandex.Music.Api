using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Extensions;
using Yandex.Music.Api.Models;

namespace Yandex.Music.Api.Responses
{
  public class YPlaylistResponse : IYandexSearchable
  {
    public bool? Collective { get; set; }
    public YandexCover Cover { get; set; }
    public string Description { get; set; }
    public string DescriptionFormatted { get; set; }
    public int? Duration { get; set; }
    public string GeneratedPlaylistType { get; set; }
    public string IdForFrom { get; set; }
    public int? Kind { get; set; }
    public int? LikesCount { get; set; }
    public string Modified { get; set; }
    public string OgImage { get; set; }
    public YandexOwner Owner { get; set; }
    public int? Revision { get; set; }
    public string Title { get; set; }
    public int? TrackCount { get; set; }
    public List<int> TrackIds { get; set; }
    public List<YTrackResponse> Tracks { get; set; }
    public string Visibility { get; set; }

    public static YPlaylistResponse FromJson(JToken jList)
    {
      var playlist = new YPlaylistResponse
      {
        Collective = jList.GetBool("collective"),
        Cover = jList.ContainField("cover") ? YandexCover.FromJson(jList["cover"]) : null,
        Description = jList.GetString("description"),
        DescriptionFormatted = jList.GetString("descriptionFormatted"),
        Duration = jList.GetInt("Duration"),
        GeneratedPlaylistType = jList.GetString("generatedPlaylistType"),
        IdForFrom = jList.GetString("IdForFrom"),
        Kind = jList.GetInt("kind"),
        LikesCount = jList.GetInt("likesCount"),
        Modified = jList.GetString("modified"),
        OgImage = jList.GetString("ogImage"),
        Owner = jList.ContainField("owner") ? YandexOwner.FromJson(jList["owner"]) : null,
        Revision = jList.GetInt("revision"),
        Title = jList.GetString("title"),
        TrackCount = jList.GetInt("trackCount"),
        Visibility = jList.GetString("visibility"),
        TrackIds = jList.ContainField("trackIds")
          ? jList["trackIds"].Select(x => int.Parse(x.ToString())).ToList()
          : null,
        Tracks = jList.ContainField("tracks")
          ? YTrackResponse.FromJsonArray(jList["tracks"].ToObject<JArray>())
          : null
      };

      return playlist;
    }

    public static List<YPlaylistResponse> FromJsonArray(JArray array)
    {
      return array.Select(FromJson).ToList();
    }
  }
}
