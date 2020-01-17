using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yandex.Music.Api.Common;
using Yandex.Music.Api.Models.Playlist;

namespace Yandex.Music.Api.Responses
{
  public class YPlaylistResponse
  {
    public int? Revision { get; set; }
    public string Kind { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string DescriptionFormatted { get; set; }
    public int? TrackCount { get; set; }
    public string Visibility { get; set; }
    public YPlaylistCover Cover { get; set; }
    public YOwner Owner { get; set; }
    public List<YTrack> Tracks { get; set; }
    public string Modified { get; set; }
    public List<int> TrackIds { get; set; }
    public string OgImage { get; set; }
    public List<string> Tags { get; set; }
    public int? LikesCount { get; set; }
    public long? Duration { get; set; }
    public bool? Collective { get; set; }
    public List<YPlaylistPrerolls> Prerolls { get; set; }
    public YPlaylistPlayCounter PlayCounter { get; set; }
    public string IdForFrom { get; set; }
    public string GeneratedPlaylistType { get; set; }
    public string UrlPart { get; set; }
    public YPlaylistMadeFor MadeFor { get; set; }
    public string OgTitle { get; set; }
    public bool? DoNotIndex { get; set; }

    public static YPlaylistResponse FromJson(JToken json)
    {
      var playlist = new YPlaylistResponse
      {
        Revision = json.SelectToken("revision")?.ToObject<int>(),
        Kind = json.SelectToken("kind")?.ToObject<string>(),
        Title = json.SelectToken("title")?.ToObject<string>(),
        Description = json.SelectToken("description")?.ToObject<string>(),
        DescriptionFormatted = json.SelectToken("descriptionFormatted")?.ToObject<string>(),
        TrackCount = json.SelectToken("trackCount")?.ToObject<int>(),
        Visibility = json.SelectToken("visibility")?.ToObject<string>(),
        Cover = YPlaylistCover.FromJson(json.SelectToken("cover")),
        Owner = YOwner.FromJson(json["owner"]),
        Tracks = json.SelectToken("tracks")?.Select(x => YTrack.FromJson(x)).ToList(),
        Modified = json.SelectToken("modified")?.ToObject<string>(),
        TrackIds = json.SelectToken("trackIds")?.Select(x => x.ToObject<int>()).ToList(),
        OgImage = json.SelectToken("ogImage")?.ToObject<string>(),
        Tags = json.SelectToken("tags")?.Select(x => x.ToObject<string>()).ToList(),
        LikesCount = json.SelectToken("likesCount")?.ToObject<int>(),
        Duration = json.SelectToken("duration")?.ToObject<long>(),
        Collective = json.SelectToken("collective")?.ToObject<bool>(),
        Prerolls = json.SelectToken("prerolls")?.Select(x => YPlaylistPrerolls.FromJson(x)).ToList(),
        PlayCounter = YPlaylistPlayCounter.FromJson(json.SelectToken("playCounter")),
        IdForFrom = json.SelectToken("idForFrom")?.ToObject<string>(),
        GeneratedPlaylistType = json.SelectToken("generatedPlaylistType")?.ToObject<string>(),
        UrlPart = json.SelectToken("urlPart")?.ToObject<string>(),
        MadeFor = YPlaylistMadeFor.FromJson(json.SelectToken("madeFor")),
        OgTitle = json.SelectToken("ogTitle")?.ToObject<string>(),
        DoNotIndex = json.SelectToken("doNotIndex")?.ToObject<bool>()
      };

      return playlist;
    }

    public static List<YPlaylistResponse> FromJsonArray(JArray array)
    {
      return array.Select(FromJson).ToList();
    }
  }
}
